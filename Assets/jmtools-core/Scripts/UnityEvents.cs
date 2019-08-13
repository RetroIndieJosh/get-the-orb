// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    namespace JoshuaMcLean
    {
        [System.Serializable] public class FloatEvent : UnityEvent<float> { }
        [System.Serializable] public class GoEvent : UnityEvent<GameObject> { }
        [System.Serializable] public class IntEvent : UnityEvent<int> { }
        [System.Serializable] public class MonoBehaviourEvent : UnityEvent<MonoBehaviour> { }
        [System.Serializable] public class StringEvent : UnityEvent<string> { }
    }
}
