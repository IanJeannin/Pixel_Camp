using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private GameObject ballObject;
    [SerializeField]
    private Animator animator;

    private bool isChasing = true;
    private bool nearBall = false;
    private bool isBallRight = true;
    private bool nearHuman = false;
    private bool isHumanRight = false;
    private bool hasBall = false;
    private bool isFacingRight = false;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(nearBall);
        if(nearBall==false)
        {
            if (ballObject.transform.position.x < gameObject.transform.position.x)
            {
                isBallRight = false;
            }
            else
            {
                isBallRight = true;
            }
            if(isChasing==true)
                 MoveDog();
            
        }
        if(nearHuman==false&&hasBall==true)
        {
            ReturnToHuman();
        }
    }

    private void MoveDog()
    {
        animator.SetBool("isMoving", true);
        if (isBallRight==true)
        {
            transform.Translate(new Vector2(2, 0) * Time.deltaTime);
            if (isFacingRight != true)
            {
                isFacingRight = !isFacingRight; //Corrects isFacingRight
                Flip();
            }
        }
        else
        {
            transform.Translate(new Vector2(-2, 0) * Time.deltaTime);
            if (isFacingRight != false)
            {
                isFacingRight = !isFacingRight; //Corrects isFacingRight
                Flip();
            }
        }
    }

    private void ReturnToHuman()
    {
        animator.SetBool("isMoving", true);
        if (isHumanRight==true)
        {
            transform.Translate(new Vector2(2, 0) * Time.deltaTime);
            if (isFacingRight != true)
            {
                isFacingRight = !isFacingRight; //Corrects isFacingRight
                Flip();
            }
        }
        else
        {
            transform.Translate(new Vector2(-2, 0) * Time.deltaTime);
            if (isFacingRight != false)
            {
                isFacingRight = !isFacingRight; //Corrects isFacingRight
                Flip();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            nearBall = true;
            Debug.Log("Dog has entered ball range.");
            hasBall = true;
        }
        else if (collision.gameObject.tag =="Player"&&hasBall==true)
        {
            nearHuman = true;
            Debug.Log("Dog has entered humans pat range.");
            isChasing = false;
            hasBall = false;
            animator.SetBool("isMoving", false);
        }
        else if(collision.gameObject.tag =="Boundary")
        {
            hasBall = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            nearBall = false;
            Debug.Log("Player has entered ball range.");
        }
        else if(collision.gameObject.tag == "Player")
        {
            nearHuman = false;
            if(collision.transform.position.x<gameObject.transform.position.x)
            {
                isHumanRight = false;
            }
            else
            {
                isHumanRight = true;
            }
        }
    }

    private void Flip()
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    
    public void Chase() //Will get called after briefly after player hits ball. 
    {
        StartCoroutine(Fetch());
    }

    private IEnumerator Fetch()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        isChasing = true;

    }
}
