// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    static public class SpriteRendererExtensions
    {
        static public Vector2 GetActualSize( this SpriteRenderer a_renderer ) {
            var x = a_renderer.transform.localScale.x;
            var y = a_renderer.transform.localScale.y;

            if ( a_renderer.drawMode == SpriteDrawMode.Simple ) {
                x *= a_renderer.sprite.bounds.size.x;
                y *= a_renderer.sprite.bounds.size.y;
            } else {
                x *= a_renderer.size.x;
                y *= a_renderer.size.y;
            }

            var size = new Vector2( x, y );
            return size;
        }
    }
}
