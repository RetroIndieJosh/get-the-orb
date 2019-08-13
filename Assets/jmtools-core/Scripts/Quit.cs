// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean
{
    using UnityEngine;
    using System.Collections;

    public class Quit : MonoBehaviour
    {
        [SerializeField] private KeyCode m_key = KeyCode.Escape;

        public void QuitGame() { Application.Quit(); }

        private void Update() {
            if ( Input.GetKeyDown( m_key ) )
                QuitGame();
        }
    }
}
