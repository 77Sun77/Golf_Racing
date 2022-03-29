using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float shootPower;
    Rigidbody2D myRigid;
    public bool isShot, isGole;
    public Vector2 previousPos;

    float timer;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        isShot = false;
        isGole = false;
        timer = 0;
        previousPos = transform.position;
        GameManager.instance.UI.SetActive(true);
    }

    void Update()
    {
        if ((Mathf.Abs(myRigid.velocity.x) <= 0.05f && Mathf.Abs(myRigid.velocity.y) <= 0.05f) && isShot)
        {
            timer += Time.deltaTime;
            if(timer >= 0.5f)
            {
                if (isGole)
                {
                    GameManager.instance.GameClear();
                    isShot = false;
                }
                else
                {
                    isShot = false;
                    previousPos = transform.position;
                    myRigid.freezeRotation = true;
                    GameManager.instance.UI.SetActive(true);
                    timer = 0;
                    
                }
                
            }
            
        }

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(transform.position.x, transform.position.y+1.5f , -10),1f);
    }

    public void Shot()
    {
        if (!isShot)
        {
            myRigid.freezeRotation = false;
            myRigid.velocity = transform.up * shootPower;
            GameManager.instance.bounceCount += 1;
            isShot = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hole")
        {
            isGole = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hole")
        {
            isGole = false;
        }
    }
}
