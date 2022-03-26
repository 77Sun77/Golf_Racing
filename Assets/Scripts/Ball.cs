using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float shotPower;
    Rigidbody2D myRigid;
    bool isShot;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        isShot = false;
    }

    void Update()
    {
        //Shot();

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(transform.position.x, transform.position.y , -10), 1f);
    }

    void Shot()
    {
        if (Input.GetMouseButtonDown(0) && !isShot)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 desPos = mousePos - transform.position;
            float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            myRigid.velocity = transform.up * shotPower;
            isShot = true;
        }

        if ((Mathf.Abs(myRigid.velocity.x) <= 0.1f && Mathf.Abs(myRigid.velocity.y) <= 0.1f) && isShot)
        {
            isShot = false;
        }
    }

    
}
