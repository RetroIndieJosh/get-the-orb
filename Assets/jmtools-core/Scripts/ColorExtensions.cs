// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;
    using UnityEngine;

    static public class ColorExtensions
    {
        static public Color ERROR_COLOR = Color.magenta;

        static public Color RandomColor( float a_alpha = 1f ) {
            if ( Utility.CheckRange( a_alpha, 0f, 1f, "alpha" ) == false )
                return ERROR_COLOR;

            return RandomColor( 0f, 1f, a_alpha );
        }

        public static Color RandomColor( float a_minBrightness = 0f, float a_maxBrightness = 1f, float a_alpha = 1f ) {
            if( Utility.CheckRange(a_minBrightness, 0f, 1f, "min brightness") == false
                || Utility.CheckRange(a_maxBrightness, 0f, 1f, "max brightness") == false
                || Utility.CheckMinMax( a_minBrightness, a_maxBrightness, "brightness" ) == false
                || Utility.CheckRange( a_alpha, 0f, 1f, "alpha" ) == false ) {

                return ERROR_COLOR;
            }

            var r = Random.Range( a_minBrightness, a_maxBrightness );
            var g = Random.Range( a_minBrightness, a_maxBrightness );
            var b = Random.Range( a_minBrightness, a_maxBrightness );
            return new Color( r, g, b, a_alpha );
        }

        public static Color RandomGray( float a_minBrightness = 0f, float a_maxBrightness = 1f, float a_alpha = 1f ) {
            if( Utility.CheckRange(a_minBrightness, 0f, 1f, "min brightness") == false
                || Utility.CheckRange(a_maxBrightness, 0f, 1f, "max brightness") == false
                || Utility.CheckMinMax( a_minBrightness, a_maxBrightness, "brightness" ) == false
                || Utility.CheckRange( a_alpha, 0f, 1f, "alpha" ) == false ) {

                return ERROR_COLOR;
            }

            var brightness = Random.Range( a_minBrightness, a_maxBrightness );
            return new Color( brightness, brightness, brightness );
        }
    }
}
