using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fishing : MonoBehaviour
{
    private float secondsBeforeFishSpawns;
    private bool fishOnLine=false;
    private float numberOfFish=0;
    private bool nearFishingHole=false;

    private IEnumerator FishTimer()
    {
        secondsBeforeFishSpawns = Random.Range(8, 12);
        yield return new WaitForSecondsRealtime(secondsBeforeFishSpawns);
        StartCoroutine(CatchFish());
        
    }

    private IEnumerator CatchFish()
    {
        fishOnLine = true;
        Debug.Log("Fish On Line");
        yield return new WaitForSecondsRealtime(2);
        Debug.Log("Fish Off Line");
        fishOnLine = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && nearFishingHole == true && fishOnLine == false)
        {
            StartCoroutine(FishTimer());
            Debug.Log("Out fishin...");
        }
        if (Input.GetButtonDown("Interact")&&fishOnLine==true)
        {
            numberOfFish++;
            Debug.Log("Fish Caught: " + numberOfFish);
            fishOnLine = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("Near Fishing Hole");
            nearFishingHole = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Not Near Fishing Hole");
            nearFishingHole = false;
        }
    }
}
