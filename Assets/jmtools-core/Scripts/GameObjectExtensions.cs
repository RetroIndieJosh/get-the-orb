// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    namespace JoshuaMcLean
    {
        static public class GameObjectExtensions
        {
            static public void DestroySelf( this GameObject a_obj ) {
                GameObject.Destroy( a_obj );
            }

            /*
            static public void SetNonvisualComponentEnabled( this GameObject a_obj, bool a_enabled ) {
                foreach ( Transform child in a_obj.transform ) {
                    child.gameObject.SetNonvisualComponentEnabled( a_enabled );
                    foreach ( var comp in child.gameObject.GetComponents<MonoBehaviour>() ) {
                        if ( comp.GetType() == typeof( Palette ) ) continue;
                        comp.enabled = a_enabled;
                    }
                }
            }
            */
        }
    }
}
