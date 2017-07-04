using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip explosionSFX;

    // Use this for initialization
    void Start()
    {
        AudioManager.instance.PlayExplosionSound(explosionSFX);
        Destroy(gameObject, 1f);
    }
}
