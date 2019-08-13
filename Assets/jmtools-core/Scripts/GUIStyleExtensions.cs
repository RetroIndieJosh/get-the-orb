// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    static public class GUIStyleExtensions
    {
        static public void SetAllColors( this GUIStyle a_style, Color a_color ) {
            a_style.normal.textColor = a_color;
            a_style.active.textColor = a_color;
            a_style.focused.textColor = a_color;
            a_style.hover.textColor = a_color;
            a_style.onActive.textColor = a_color;
            a_style.onFocused.textColor = a_color;
            a_style.onHover.textColor = a_color;
            a_style.onNormal.textColor = a_color;
        }
    }
}
