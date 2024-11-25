using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] sfxClips;

    public void CardClickEffect()
    {
        source.clip = sfxClips[0];
        source.Play();
    }

    public void CorrectMatchEffect()
    {
        source.clip = sfxClips[1];
        source.Play();
    }

    public void WrongMatchEffect()
    {
        source.clip = sfxClips[2];
        source.Play();
    }

    /*public void AllCorrectEffect()
    {
        source.clip = sfxClips[3];
        source.Play();
    }*/
}
