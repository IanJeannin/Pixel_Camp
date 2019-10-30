using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{
    [SerializeField]
    private GameObject day;
    [SerializeField]
    private GameObject night;
    [SerializeField]
    private float timeToSwitchTimes = 40;
    [SerializeField]
    private Sounds soundManager;

    //---------------------------------------------------------------------
    // This Script is found on the TimeChange child object of the MainCamera
    //---------------------------------------------------------------------
  

    private void Start()
    {
        StartCoroutine(ChangeToDay());
    }

    private IEnumerator ChangeToDay()
    {
        day.SetActive(true);
        night.SetActive(false);
        yield return new WaitForSecondsRealtime(timeToSwitchTimes);
        soundManager.ChangeMusic();
        StartCoroutine(ChangeToNight());
    }

    private IEnumerator ChangeToNight()
    {
        day.SetActive(false);
        night.SetActive(true);
        yield return new WaitForSecondsRealtime(timeToSwitchTimes);
        soundManager.ChangeMusic();
        StartCoroutine(ChangeToDay());
    }
}
