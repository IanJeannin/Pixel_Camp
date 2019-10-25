using System.Collections;
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

    private bool isChasing = true;
    private bool isInRange = false;
    private bool isCaught = false;

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
        doggo.GetComponent<Dog>().Chase();
        StartCoroutine(Fetch());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            isInRange = true;
            Debug.Log("Player has entered ball range.");
            isCaught = false;
        }
        if(collision.gameObject.tag=="Dog"&&isChasing==true)
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
            isChasing = false;
            isCaught = false;
            Debug.Log("Doggo has dropped ball.");
        }
    }

    private IEnumerator Fetch()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        isChasing = true;

    }
}
