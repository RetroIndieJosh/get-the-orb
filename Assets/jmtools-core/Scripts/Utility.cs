// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    static public class Utility
    {
        static public bool CheckMinMax(float a_min, float a_max, string a_label = "value" ) {
            if( a_min > a_max ) {
                Debug.LogError( $"Minimum {a_label} {a_min} is greater than maximum {a_label} {a_max}." );
                return false;
            }

            return true;
        }

        static public bool CheckRange(float a_val, float a_min, float a_max, string a_label = "value" ) {
            if( a_val < a_min || a_val > a_max ) {
                Debug.LogError( $"Value for {a_label} {a_val} out of range [{a_min}, {a_max}]" );
                return false;
            }

            return true;
        }
    }

    // TODO split everything in here into class extensions or migrate to other classes 

    // use DateTime instead?
    /*
public class TimeStringConstructor
{
    static public bool includeMilliseconds = false;
    static public bool includeSeconds = true;
    static public bool includeMinutes = true;
    static public bool includeHours = false;

    public static string getTimeString( float a_seconds ) {
        float timeLeft = a_seconds;
        int hours = 0;
        int minutes = 0;
        int seconds = 0;
        int ms = 0;

        if ( includeHours ) {
            hours = Mathf.FloorToInt( a_seconds / 3600.0f );
            timeLeft -= 3600.0f * hours;
        }

        if ( includeMinutes ) {
            minutes = Mathf.FloorToInt( timeLeft / 60.0f );
            timeLeft -= 60.0f * minutes;
        }

        if ( includeSeconds ) {
            seconds = Mathf.FloorToInt( timeLeft );
            timeLeft -= seconds;
        }

        if ( includeMilliseconds ) {
            ms = Mathf.FloorToInt( timeLeft );
        }

        string ret = "";
        if ( includeHours )
            ret += string.Format( "{0:00}:", hours );
        if ( includeMinutes )
            ret += string.Format( "{0:00}:", minutes );
        if ( includeSeconds )
            ret += string.Format( "{0:00}", seconds );
        if ( includeMilliseconds )
            ret += string.Format( "{0:000}", ms );

        return ret;
    }
}
*/
}
