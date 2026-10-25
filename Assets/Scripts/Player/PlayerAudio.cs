using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip audioClipTakeHit;
    public AudioClip audioClipLose;
    public AudioClip audioClipWin;
    public AudioClip playerClipPick;
    public AudioSource audioSource;
    //单例对象
    public static PlayerAudio playerAudio;

    public void playerTakeHitAduio()
    {
        audioSource.PlayOneShot(audioClipTakeHit);
    }
    public void playerLoseAudio()
    {
        audioSource.PlayOneShot(audioClipLose);
    }
    public void playerWinAudio()
    {
        audioSource.PlayOneShot(audioClipWin);
    }
    public void playerPcikAduio()
    {
        audioSource.PlayOneShot(playerClipPick);
    }
    void Start()
    {
        playerAudio = this;
    }

    void Update()
    {
        
    }
}
