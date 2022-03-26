using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float shotPower;
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
                }
                else
                {
                    isShot = false;
                    previousPos = transform.position;
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
            myRigid.velocity = transform.up * shotPower;
            isShot = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Gole")
        {
            isGole = true;
        }
    }
}
