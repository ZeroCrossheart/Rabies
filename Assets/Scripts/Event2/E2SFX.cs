using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2SFX : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] sfxClips;
    public void CorrectMatchEffect()
    {
        source.clip = sfxClips[0];
        source.Play();
    }

    public void WrongMatchEffect()
    {
        source.clip = sfxClips[1];
        source.Play();
    }
}
