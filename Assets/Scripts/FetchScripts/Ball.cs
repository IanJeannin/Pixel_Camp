﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private GameObject playerCharacter;
    [SerializeField]
    private Rigidbody2D ballRigidbody;
    [SerializeField]
    private GameObject doggo;

    private bool isInRange = false;
    private bool isCaught = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact")&&isInRange==true)
        {
            TossBall();
        }
        if(isCaught==true)
        {
            gameObject.transform.position = doggo.transform.position;
        }
    }

    private void TossBall()
    {
        float playerPos = playerCharacter.transform.position.x;
        float ballPos = gameObject.transform.position.x;
        if(playerPos<=ballPos)
        {
            ballRigidbody.AddForce(new Vector2(4-(ballPos-playerPos),5),ForceMode2D.Impulse);
        }
        else
        {
            ballRigidbody.AddForce(new Vector2(-4+(playerPos-ballPos), 5), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            isInRange = true;
            Debug.Log("Player has entered ball range.");
            isCaught = false;
        }
        if(collision.gameObject.tag=="Dog")
        {
            isCaught = true;
            Debug.Log("Doggo has ball");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = false;
            Debug.Log("Player has left ball range.");
        }
        if(collision.gameObject.tag=="Dog")
        {
            isCaught = false;
            Debug.Log("Doggo has dropped ball.");
        }
    }
}
