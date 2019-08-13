using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent, RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, Controls.IMovementActions
{
    [SerializeField] private float m_doubleTapTimeSec = 0.1f;
    [SerializeField] private float m_maxForwardSpeed = 1.3f;
    [SerializeField] private float m_strafeSpeed = 1f;
    [SerializeField] private float m_rotateSpeed = 1f;
    [SerializeField] private float m_secToFullSpeed = 0.2f;

    [SerializeField] private float m_groundDistance = 0.1f;
    [SerializeField] private bool m_invertLookY = true;
    [SerializeField] private float m_lookHoldTime = 0.3f;

    [SerializeField] private float m_gravityAccel = 9.8f;
    //[SerializeField] private float m_jumpPeakHeight = 5f;
    [SerializeField] private float m_jumpSpeedMax = 2f;
    [SerializeField] private float m_jumpTimeMaxSec = 0.4f;
    [SerializeField] private float m_jumpTimeMinSec = 0.2f;

    [SerializeField] private float m_maxCamJumpTilt = 30f;
    [SerializeField] private float m_camJumpTiltSec = 0.5f;

    private float m_initialJumpLookAngleX = 0f;

    private CharacterController m_controller = null;
    private Controls m_controls = null;

    private float m_gravityVel = 0f;

    private float m_forwardSpeed = 0f;

    private bool m_isLooking = false;
    private bool m_isStrafing = false;

    private Vector3 m_eulerRotation = Vector3.zero;
    private Vector3 m_move = Vector3.zero;

    private float m_timeSinceDirectionPress = Mathf.Infinity;
    private Vector2 m_forwardMove = Vector2.zero;
    private Vector2 m_dashStartDir = Vector2.zero;

    private bool m_buttonDownA = false;
    private bool m_buttonDownB = false;

    private float m_buttonTimeA = 0f;
    private float m_buttonTimeB = 0f;

    private bool m_isGrounded = false;
    private bool m_isJumping = false;
    private float m_jumpSpeed = 0f;

    private bool m_canJump = true;

    private Vector3 m_prevPos = Vector3.zero;

    public void OnButtonA(InputAction.CallbackContext context)
    {
        m_buttonDownA = !context.canceled;
    }

    public void OnButtonB(InputAction.CallbackContext context)
    {
        m_buttonDownB = !context.canceled;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        // ignore context.performed since we only want beginning of press
        if (context.started == false)
            return;

        if (m_timeSinceDirectionPress <= m_doubleTapTimeSec) {
            if( m_dashStartDir == context.ReadValue<Vector2>())
                Debug.Log("Dash: " + m_dashStartDir);
        }

        m_dashStartDir = context.ReadValue<Vector2>();
        m_timeSinceDirectionPress = 0f;
    }

    public void OnForward(InputAction.CallbackContext context)
    {
        m_forwardMove.y = context.ReadValue<float>();
        Debug.Log("Move: " + m_forwardMove.y);
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        m_forwardMove.x = context.ReadValue<float>();
        Debug.Log("Turn: " + m_forwardMove.x);
    }

    private void OnDisable()
    {
        m_controls.Disable();
    }

    private void OnDrawGizmos()
    {
        var angles = transform.eulerAngles;
        angles.x = 0f;
        var forward = Quaternion.Euler(angles) * Vector3.forward;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + forward * 10f);
    }

    private void OnEnable()
    {
        if (m_controls == null) {
            m_controls = new Controls();
            m_controls.Movement.SetCallbacks(this);
        }

        m_controls.Enable();
    }

    private void Start()
    {
        m_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleButtonA();
        HandleButtonB();

        HandleTurn();
        HandleForward();

        HandleDash();

        HandleJump();
        HandleGravity();

        UpdateController();
    }

    private float m_jumpTime = 0f;

    private void HandleJump()
    {
        if (m_isJumping == false)
            return;

        var jumpDecel = m_jumpSpeed / m_jumpTimeMaxSec;
        m_jumpSpeed -= jumpDecel * Time.deltaTime;
        if (m_jumpSpeed < Mathf.Epsilon) {
            m_jumpSpeed = 0;
            m_isJumping = false;
            return;
        }

        m_move += Vector3.up * m_jumpSpeed * Time.deltaTime;
        m_jumpTime += Time.deltaTime;
        if (m_jumpTime > m_jumpTimeMaxSec)
            m_isJumping = false;
    }

    private void UpdateController()
    {
        transform.rotation = Quaternion.Euler(m_eulerRotation);

        var collisionFlags = m_controller.Move(m_move);
        if (collisionFlags == CollisionFlags.Below)
            m_isGrounded = true;
        if (collisionFlags == CollisionFlags.Above && m_isJumping)
            m_isJumping = false;

        m_move = Vector3.zero;
    }

    private void HandleGravity()
    {
        if (m_isGrounded || m_isJumping) {
            m_gravityVel = 0f;
            return;
        }

        m_gravityVel += m_gravityAccel * Time.deltaTime;
        m_move += Vector3.down * m_gravityVel * Time.deltaTime;
    }

    private void HandleButtonA()
    {
        if (m_buttonDownA) {
            if (m_isJumping == false && m_isGrounded) {
                StartJump();
                m_canJump = false;
            }

            m_buttonTimeA += Time.deltaTime;
            var t = Mathf.Min(1f, m_buttonTimeA / m_camJumpTiltSec);
            m_eulerRotation.x = Mathf.Lerp(m_initialJumpLookAngleX, m_initialJumpLookAngleX + m_maxCamJumpTilt, t);
        } else {
            if (m_buttonTimeA > Mathf.Epsilon) {
                m_canJump = true;
                m_buttonTimeA = 0f;
                StartCoroutine(RevertLookAngleX());
                //m_eulerRotation.x = m_initialJumpLookAngleX;
            }

            if (m_isJumping && m_jumpTime >= m_jumpTimeMinSec)
                m_isJumping = false;
        }
    }

    IEnumerator RevertLookAngleX()
    {
        var timeElapsed = 0f;
        var curAngle = m_eulerRotation.x;
        while (timeElapsed < m_camJumpTiltSec) {
            timeElapsed += Time.deltaTime;
            var t = Mathf.Min(1f, timeElapsed / m_camJumpTiltSec);
            m_eulerRotation.x = Mathf.Lerp(curAngle, m_initialJumpLookAngleX, t);
            yield return null;
        }
    }

    // if we tap B for < look hold time, toggle strafing
    // if we hold B for > look hold time, look around
    private void HandleButtonB()
    {
        m_isLooking = false;

        if (m_buttonDownB) {
            m_buttonTimeB += Time.deltaTime;
            if (m_buttonTimeB > m_lookHoldTime)
                m_isLooking = true;
        } else if( m_buttonTimeB > Mathf.Epsilon ) {
            if (m_buttonTimeB < m_lookHoldTime)
                m_isStrafing = !m_isStrafing;
            m_buttonTimeB = 0f;
        }
    }

    private void HandleDash()
    {
        m_timeSinceDirectionPress += Time.deltaTime;

        // TODO dash
        var dash3d = new Vector3(m_dashStartDir.x, 0f, m_dashStartDir.y);
    }

    private void HandleForward()
    {
        var move = m_forwardMove.y;

        if (m_isLooking) {
            var turn = move * m_rotateSpeed * Time.deltaTime;
            if (m_invertLookY == false)
                turn = -turn;
            m_eulerRotation.x += turn;
            return;
        }

        var speedIncrement = m_maxForwardSpeed / m_secToFullSpeed * Time.deltaTime;

        // decelerate
        if (Mathf.Abs(move) < Mathf.Epsilon) {
            m_forwardSpeed -= speedIncrement;
            if (m_forwardSpeed <= Mathf.Epsilon) {
                m_forwardSpeed = 0f;
                return;
            }

        // accelerate
        } else if (m_forwardSpeed < m_maxForwardSpeed) {
            m_forwardSpeed += m_maxForwardSpeed / m_secToFullSpeed * Time.deltaTime;
        }

        // TODO smooth lerpy goodness
        var angles = transform.eulerAngles;
        angles.x = 0f;
        var forward = Quaternion.Euler(angles) * Vector3.forward;
        var move3d = forward * Mathf.Sign(move) * m_forwardSpeed * Time.deltaTime;
        m_move += move3d;

        //var move3d = Vector3.forward * Mathf.Sign(move) * m_forwardSpeed * Time.deltaTime;
        //transform.Translate(move3d);
    }

    private void HandleTurn()
    {
        var turn = m_forwardMove.x;

        // TODO separate strafe speed
        if (m_isStrafing && m_isLooking == false && Mathf.Abs(turn) > float.Epsilon) {
            var move3d = transform.right * Mathf.Sign(turn) * m_strafeSpeed * Time.deltaTime;
            m_move += move3d;
            return;
        }

        m_eulerRotation.y += turn * m_rotateSpeed * Time.deltaTime;
    }

    private void StartJump()
    {
        if (m_canJump == false)
            return;

        m_jumpTime = 0f;
        m_isGrounded = false;
        m_isJumping = true;
        m_jumpSpeed = m_jumpSpeedMax;

        m_initialJumpLookAngleX = m_eulerRotation.x;
    }
}
