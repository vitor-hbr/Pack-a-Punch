using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] float volume = 0.2f;

    private void Start()
    {
        if (audioSource == null)
            audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void play()
    {
        if (audioSource == null) return;
        audioSource.PlayOneShot(audioClip, volume);
    }
}
