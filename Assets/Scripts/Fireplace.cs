using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : InteractableObject
{
    [SerializeField]
    private GameObject player;

    private bool fireBurning = false;
    private bool playerNearFire=false;
    private int numberOfSticksInFire;
    private int sticksInInventory;
    
    private void Update()
    {
        if (Input.GetButtonDown("Interact") &&playerNearFire==true)
        {
            AddSticksToFire();
        }
    }

    private void AddSticksToFire()
    {
        sticksInInventory = player.GetComponent<Inventory>().GetInventory();
        numberOfSticksInFire += sticksInInventory;
        Debug.Log(numberOfSticksInFire);
    }

    public override void Interact()
    {
        IntText = "The fire is ";
        fireBurning = !fireBurning;
        IntText += fireBurning ? "not burning" : "burning.";

        
        //GetComponent<Animator>().SetBool("Interact", fireBurning);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(collision.name);
            playerNearFire = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearFire = false;
        }
    }
}
