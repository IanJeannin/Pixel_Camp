using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject credits;

    private bool creditsShowing=false;
    private bool inTentRange = false;

    
        // Update is called once per frame
        void Update()
        {
            if(Input.GetButtonDown("Interact")&&inTentRange==true)
            {
            ShowCredits();
            }
            if(creditsShowing==true)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inTentRange = true;
        }
    }

    private void ShowCredits()
    {
        creditsShowing = !creditsShowing;
        if(creditsShowing==true)
        {
            credits.SetActive(true);
        }
        if(creditsShowing==false)
        {
            credits.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inTentRange = false;
        }
    }
}
