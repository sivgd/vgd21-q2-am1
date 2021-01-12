using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource Fx;
    public AudioClip buttonHover;
    public AudioClip buttonClick;


    public void HoverSound()
    {
        Fx.PlayOneShot(buttonHover);
    }
    public void ClickSound()
    {
        Fx.PlayOneShot(buttonClick);
    }
}
