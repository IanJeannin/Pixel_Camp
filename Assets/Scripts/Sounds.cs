using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip dogBark;
    [SerializeField]
    private AudioClip throwLine;
    [SerializeField]
    private AudioClip fishOnLine;
    [SerializeField]
    private AudioClip fishCaught;
    [SerializeField]
    private AudioClip throwBall;
    [SerializeField]
    private AudioClip returnBall;
    [SerializeField]
    private AudioClip tentZip;
    [SerializeField]
    private GameObject musicNight;
    [SerializeField]
    private GameObject ambientNight;
    [SerializeField]
    private GameObject musicDay;
    [SerializeField]
    private GameObject ambientDay;

    private bool isDay=true; //Will be used to keep track of time of day for switching music/ambience

    public void PlayBark()
    {
        PlaySound(dogBark);
    }
    public void PlayReturnBall()
    {
        PlaySound(returnBall);
    }
    public void PlayThrowLine()
    {
        PlaySound(throwLine);
    }
    public void PlayFishOnLine()
    {
        PlaySound(fishOnLine);
    }
    public void PlayFishCaught()
    {
        PlaySound(fishCaught);
    }
    public void PlayThrowBall()
    {
        PlaySound(throwBall);
    }
    public void PlayTentZip()
    {
        PlaySound(tentZip);
    }

    private void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

    public void ChangeMusic()
    {
        if(isDay==true)
        {
            musicDay.SetActive(false);
            ambientDay.SetActive(false);
            musicNight.SetActive(true);
            ambientNight.SetActive(true);
            isDay = false;
        }
        else
        {
            musicDay.SetActive(true);
            ambientDay.SetActive(true);
            musicNight.SetActive(false);
            ambientNight.SetActive(false);
            isDay = true;
        }
    }


}
