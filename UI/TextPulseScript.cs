using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPulseScript : MonoBehaviour
{
    ///
    /// This script is literally just to pulse
    /// the press start button on the main menu
    ///

    //alpha max is 1 and alpha min is 0
    [SerializeField] private float alphaChangeRate = .005f;
    [SerializeField] private TextMeshProUGUI m_text;
    [SerializeField] private bool fadeUp;

    private void Awake()
    {
        if (m_text == null) { this.enabled = false; return; }
    }
    private void Update()
    {
        if (fadeUp)
        {
            m_text.alpha += alphaChangeRate;
            if (m_text.alpha >= 1) fadeUp = false;
        }
        else
        {
            m_text.alpha -= alphaChangeRate;
            if (m_text.alpha <= 0) fadeUp = true;
        }
    }
}
