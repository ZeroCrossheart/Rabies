using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4SFX : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] sfxClips;
    public void BiteEffect()
    {
        source.clip = sfxClips[0];
        source.Play();
    }

    public void CureEffect()
    {
        source.clip = sfxClips[1];
        source.Play();
    }
}
