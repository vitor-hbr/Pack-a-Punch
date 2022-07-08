using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    SoundController explosionSound;
    private void Start()
    {
        explosionSound = GetComponent<SoundController>();
    }
    private void OnEnable()
    {
        Box.onRemoveBox += explode;
    }

    private void OnDisable()
    {
        Box.onRemoveBox -= explode;
    }

    public void explode ()
    {
        explosionSound.play();
    }
}
