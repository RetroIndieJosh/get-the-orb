// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    static public class RectExtensions
    {
        /*
        static public Vector2 EdgeIntersectPoint(this Rect a_rect, Vector2 a_vecStart, Vector2 a_vecEnd) {
            var diff = a_vecEnd - a_vecStart;
            var direction = diff.ToDirectionCardinal();

            //Debug.LogFormat( "Target is {0} of start (diff {1})", direction, diff );

            var camRect = CameraManager.instance.Rectangle;
            var min = Vector2.zero;
            var max = Vector2.zero;
            switch (direction) {
                case Direction.East:
                    min = new Vector2( camRect.xMax, camRect.yMin );
                    max = new Vector2( camRect.xMax, camRect.yMax );
                    break;
                case Direction.North:
                    min = new Vector2( camRect.xMin, camRect.yMax );
                    max = new Vector2( camRect.xMax, camRect.yMax );
                    break;
                case Direction.South:
                    min = new Vector2( camRect.xMin, camRect.yMin );
                    max = new Vector2( camRect.xMax, camRect.yMin );
                    break;
                case Direction.West:
                    min = new Vector2( camRect.xMin, camRect.yMin );
                    max = new Vector2( camRect.xMin, camRect.yMax );
                    break;
            }

            var a1 = a_vecEnd.y -  a_vecStart.y;
            var b1 = a_vecStart.x - a_vecEnd.x;
            var c1 = a1 * a_vecStart.x + b1 * a_vecStart.y;

            var a2 = max.y - min.y;
            var b2 = min.x - max.x;
            var c2 = a2 * min.x + b2 * min.y;

            var det = a1 * b2 - a2 * b1;
            var x = ( b2 * c1 - b1 * c2 ) / det;
            var y = ( a1 * c2 - a2 * c1 ) / det;

            return new Vector2( x, y );
        }
        */
    }
}
