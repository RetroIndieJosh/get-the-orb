// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GizmoArrow : MonoBehaviour
    {
        [SerializeField, Tooltip( "If true, always draw; otherwise, only when selected." )]
        private bool m_drawUnselected = false;

        [SerializeField] private bool m_relativeOrigin = true;
        [SerializeField] private Vector3 m_origin = Vector3.zero;
        [SerializeField] private Vector3 m_direction = Vector3.zero;
        [SerializeField] private float m_length = 1f;

        [SerializeField] private Color m_color = Color.white;

        [SerializeField, Tooltip( "Angle of lines at tip of arrow" )]
        private float m_headAngle = 30f;

        private void OnDrawGizmos() {
            if ( m_drawUnselected )
                Draw();
        }

        private void OnDrawGizmosSelected() {
            if ( m_drawUnselected == false )
                Draw();
        }

        private void Draw() {
            var direction = m_direction.normalized;
            Gizmos.color = m_color;
            var origin = m_relativeOrigin ? transform.position + m_origin : m_origin;
            Gizmos.DrawRay( origin, direction * m_length );

            Gizmos.color = Color.red;
            var end = origin + direction * m_length;
            var headLength = 0.1f * m_length;

            var top = Quaternion.AngleAxis( 180f + m_headAngle, Vector3.up ) * direction * headLength;
            //top = Quaternion.LookRotation( m_direction ) * top;
            //var top = Quaternion.LookRotation( m_direction ) * Quaternion.AngleAxis( 180f + m_headAngle, Vector3.up ) * direction * headLength;
            Gizmos.DrawRay( end, top );

            var bottom = Quaternion.AngleAxis( 180f - m_headAngle, Vector3.up ) * direction * headLength;
            Gizmos.DrawRay( end, bottom );
        }
    }
}
