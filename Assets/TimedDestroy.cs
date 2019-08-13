using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField] float m_timeToDestroy = 1f;

    float m_timeElapsed = 0f;

    private void Update()
    {
        m_timeElapsed += Time.deltaTime;
        if (m_timeElapsed >= m_timeToDestroy)
            Destroy(gameObject);
    }
}
