// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable] public enum Axis { X, Y, Z }

    static public class VectorExtensions
    {
        static public Vector2 GetRotated( this Vector2 a_vector, float a_angle ) {
            float sin = Mathf.Sin( a_angle * Mathf.Deg2Rad );
            float cos = Mathf.Cos( a_angle * Mathf.Deg2Rad );

            float tx = a_vector.x;
            float ty = a_vector.y;
            a_vector.x = ( cos * tx ) - ( sin * ty );
            a_vector.y = ( sin * tx ) + ( cos * ty );
            return a_vector;
        }

        /*
        static public Direction ToDirection( this Vector2 a_vector, bool a_cardinalOnly = false ) {
            if ( a_cardinalOnly ) return a_vector.ToDirectionCardinal();
            return a_vector.ToDirection();
        }
        */
    }
}
