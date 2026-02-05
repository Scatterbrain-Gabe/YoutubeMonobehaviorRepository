using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuFader : MonoBehaviour
{
    ///
    /// This script is literally just to fade
    /// out the main menu after the user presses a button
    ///

    //alpha max is 1 and alpha min is 0
    [SerializeField] private float alphaChangeRate = .005f;
    [SerializeField] private Image m_image;
    [SerializeField] private GameObject m_Text;
    [SerializeField] private bool doFadeAway;
    private Color m_color;
    private AudioSource m_audioSource;
    private void Awake()
    {
        if (m_image == null) { this.enabled = false; return; }
        m_audioSource = GetComponent<AudioSource>();
        doFadeAway = false;
        m_color = m_image.color;
        m_color.a = 1;
    }
    public void EnableFadeAway()
    {
        doFadeAway = true;
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            doFadeAway = true;
            PlayAudio();
        }
        if (doFadeAway)
        {
            
            if (m_Text != null) m_Text.SetActive(false);
            m_color.a -= alphaChangeRate;
            m_image.color = m_color;
            if (m_color.a <= 0)
            {
                doFadeAway = false;
                gameObject.SetActive(false);
            }
        }

    }
    private void PlayAudio()
    {//play sound effect when the player presses a button
        if (m_audioSource == null) return;
        if (m_audioSource.isPlaying) return;

        m_audioSource.Play();
    }

}
