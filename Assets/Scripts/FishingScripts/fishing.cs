using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fishing : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject fishExclamation;
    [SerializeField]
    private GameObject fishingBobber;

    private float secondsBeforeFishSpawns;
    private bool fishOnLine=false;
    private float numberOfFish=0;
    private bool nearFishingHole=false;
    private bool isFishing = false;
    private bool justCaught = false;

    private IEnumerator FishTimer()
    {
        justCaught = false;
        secondsBeforeFishSpawns = Random.Range(6, 9);
        yield return new WaitForSecondsRealtime(secondsBeforeFishSpawns);
        StartCoroutine(CatchFish());
        
    }

    private IEnumerator CatchFish()
    {
        fishOnLine = true;
        Debug.Log("Fish On Line");
        
        yield return new WaitForSecondsRealtime(2);
        CheckIfFishOnLine();
    }

    private void CheckIfFishOnLine()
    {
        if (justCaught == true)
        {

        }
        else
        {
            Debug.Log("Fish Off Line");
            fishOnLine = false;
            isFishing = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isFishing==true)
        {
            fishingBobber.SetActive(true);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            fishingBobber.SetActive(false);
        }
        if(fishOnLine==true)
        {
            fishExclamation.SetActive(true);
        }
        else
        {
            fishExclamation.SetActive(false);
        }
        if (Input.GetButtonDown("Interact") && nearFishingHole == true && fishOnLine == false)
        {
            isFishing = true;
            StartCoroutine(FishTimer());
            Debug.Log("Out fishin...");
        }
        if (Input.GetButtonDown("Interact")&&fishOnLine==true)
        {
            numberOfFish++;
            Debug.Log("Fish Caught: " + numberOfFish);
            justCaught = true;
            fishOnLine = false;
            isFishing = false;
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
