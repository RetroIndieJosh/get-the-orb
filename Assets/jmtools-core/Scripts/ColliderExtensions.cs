// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    static public class ColliderExtensions
    {
        static public Vector2 GetExtents( this Collider2D a_collider ) {
            var boxCollider = a_collider as BoxCollider2D;
            if ( boxCollider != null ) return boxCollider.size * 0.5f;

            var capsuleCollider = a_collider as CapsuleCollider2D;
            if ( capsuleCollider != null ) return capsuleCollider.size * 0.5f;

            var circleCollider = a_collider as CircleCollider2D;
            if ( circleCollider != null ) return Vector2.one * circleCollider.radius;

            var polygonCollider = a_collider as PolygonCollider2D;
            if ( polygonCollider != null ) throw new System.NotImplementedException();

            return Vector2.zero;
        }

        static public Vector2 GetSize( this Collider2D a_collider ) {
            return a_collider.GetExtents() * 2.0f;
        }
    }
}
