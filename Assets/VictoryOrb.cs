using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryOrb : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_victoryTextMesh = null;

    private float m_timeElapsed = 0f;

    private void Awake()
    {
        m_victoryTextMesh.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player == null)
            return;

        player.hasOrb = true;

        var isFastest = false;
        var fastest = PlayerPrefs.GetFloat("fastest", Mathf.Infinity);
        if (m_timeElapsed < fastest) {
            PlayerPrefs.SetFloat("fastest", m_timeElapsed);
            isFastest = true;
        }

        m_victoryTextMesh.enabled = true;
        m_victoryTextMesh.text = $"Victory!\nYou got the orb in\n{m_timeElapsed} seconds";
        if (isFastest)
            m_victoryTextMesh.text += "\n(fastest time!!)";
        else
            m_victoryTextMesh.text += $"\n(fastest: {fastest}s)";
        m_victoryTextMesh.text += "\n[Start/Esc to retry]";

        PlayerPrefs.Save();

        gameObject.SetActive(false);
    }

    private void Update()
    {
        m_timeElapsed += Time.deltaTime;
    }
}
