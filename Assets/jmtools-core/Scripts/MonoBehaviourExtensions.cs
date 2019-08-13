// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    static public class MonoBehaviourExtensions
    {
        [ExecuteInEditMode]
        static public T RequireComponent<T>( this MonoBehaviour a_requirer, T a_currentComponent )
            where T : Component {

            var comp = a_currentComponent ?? a_requirer.GetComponent<T>();

            if ( comp == null ) {
                Debug.LogErrorFormat( "{0} requires {1} but none is set or in game object.", a_requirer.GetType(),
                    a_currentComponent.GetType() );
                a_requirer.enabled = false;
            }

            return comp;
        }
    }
}
