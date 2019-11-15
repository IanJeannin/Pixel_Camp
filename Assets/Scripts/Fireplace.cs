using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : InteractableObject
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject stick;
    [SerializeField]
    private float timeBetweenStickSpawn=2;
    [SerializeField]
    private int maxSticksSpawnedAtOnce = 3;
    [SerializeField]
    private float timeForFireToDieDown = 20;
    [SerializeField]
    private Animator animator;

    private int numberOfSticksSpawned=0;
    private bool fireBurning = false;
    private bool playerNearFire=false;
    private int numberOfSticksInFire;
    private int sticksInInventory;

    private void Start()
    {
        StartCoroutine(StickSpawnTimer());
        StartCoroutine(FireDying());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") &&playerNearFire==true)
        {
            AddSticksToFire();
        }
    }

    private void SpawnStick()
    {
        if (numberOfSticksSpawned < 3)
        {
            Vector2 pos = new Vector2(Random.Range(-8, 20), Random.Range(-2.7f, -3));
            Instantiate(stick, pos, Quaternion.identity);
            numberOfSticksSpawned++;
        }
    }

    private void AddSticksToFire()
    {
        sticksInInventory = player.GetComponent<Inventory>().GetInventory();
        numberOfSticksSpawned -= sticksInInventory;
        numberOfSticksInFire += sticksInInventory;
        //Sticks removed from inventory in Inventory.cs
        animator.SetInteger("numberOfSticksInFire", numberOfSticksInFire);
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

    private IEnumerator StickSpawnTimer()
    {
        yield return new WaitForSecondsRealtime(timeBetweenStickSpawn);
        SpawnStick();
        StartCoroutine(StickSpawnTimer());
    }

    private IEnumerator FireDying()
    {
        yield return new WaitForSecondsRealtime(timeForFireToDieDown);
        if(numberOfSticksInFire>0)
        {
            numberOfSticksInFire--;
            animator.SetInteger("numberOfSticksInFire", numberOfSticksInFire);
        }
        StartCoroutine(FireDying());

    }
}
