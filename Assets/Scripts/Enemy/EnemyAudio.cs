using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public void enemyTakeHitAudio()
    {
        audioSource.PlayOneShot(audioClip);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
