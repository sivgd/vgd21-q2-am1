using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource Fx;
    public AudioClip buttonHover;
    public AudioClip buttonClick;
    public AudioClip themeDay;
    public AudioClip themeNight;
    public AudioClip themeOriginal;
    public AudioClip autoballer;
    public AudioClip catapult;
    public AudioClip launcher;
    public AudioClip pop1;
    public AudioClip pop2;
    public AudioClip pop3;
    public AudioClip tick;
    public AudioClip pageTurn;


    public void HoverSound()
    {
        Fx.PlayOneShot(buttonHover);
    }
    public void ClickSound()
    {
        Fx.PlayOneShot(buttonClick);
    }
    public void DayTheme()
    {
        Fx.PlayOneShot(themeDay);
    }
    public void NightTheme()
    {
        Fx.PlayOneShot(themeNight);
    }
    public void OriginalTheme()
    {
        Fx.PlayOneShot(themeOriginal);
    }
    public void AutoballTower()
    {
        Fx.PlayOneShot(autoballer);
    }
    public void CatapultTower()
    {
        Fx.PlayOneShot(catapult);
    }
    public void LauncherTower()
    {
        Fx.PlayOneShot(launcher);
    }
    public void PopSound1()
    {
        Fx.PlayOneShot(pop1);
    }
    public void PopSound2()
    {
        Fx.PlayOneShot(pop2);
    }
    public void PopSound3()
    {
        Fx.PlayOneShot(pop3);
    }
    public void TickSound()
    {
        Fx.PlayOneShot(tick);
    }
    public void BookPage()
    {
        Fx.PlayOneShot(pageTurn);
    }
}
