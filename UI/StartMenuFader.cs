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
    public enum Behavior
    {
        fadeIn,
        fadeOut
    }
    [SerializeField] private Behavior m_FadeBehavior;
    [SerializeField] private float alphaChangeRate = 1;
    [SerializeField] private Image m_image;
    [SerializeField] private GameObject m_Text;
    [SerializeField] private bool doFadeAway;
    private Color m_color;
    [SerializeField]private AudioSource m_audioSource;
    private void Awake()
    {
        if (m_image == null) { this.enabled = false; return; }
       if(m_audioSource == null) m_audioSource = GetComponent<AudioSource>();
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
            //this is the most efficient way to avoid unneccasry object deactivations
            if (m_Text != null && m_Text.activeInHierarchy) m_Text.SetActive(false);
        }
        if (doFadeAway)
        {

            switch (m_FadeBehavior)
            {
                case Behavior.fadeOut:
                    m_color.a -= alphaChangeRate * Time.deltaTime;
                    m_image.color = m_color;
                    if (m_color.a <= 0)
                    {
                        doFadeAway = false;
                        gameObject.SetActive(false);
                    }
                    break;

                    case Behavior.fadeIn:
                    m_color.a += alphaChangeRate * Time.deltaTime;
                    m_image.color = m_color;
                    if (m_color.a >= 0)
                    {
                        doFadeAway = false;
                        //gameObject.SetActive(false);
                    } 
                    break;
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
