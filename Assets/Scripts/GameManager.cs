using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject UI;

    public GameObject Ball;
    Ball ball;

    public string stage;

    Vector2 previousPos;
    float timer;
    void Awake()
    {
        instance = this;
        UI = GameObject.Find("Canvas").transform.Find("UI").gameObject;
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        GameObject.Find("Map").transform.Find(stage).gameObject.SetActive(true);
        timer = 0;
    }

    void Update()
    {
        if (ball == null)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                ball = Instantiate(Ball).GetComponent<Ball>();
                UI.transform.Find("Joystick").GetComponent<Joystick>().ball = ball;
                UI.transform.Find("Power Gage").GetComponent<PowerGage>().ball = ball;
                ball.transform.position = previousPos;
                ball.previousPos = previousPos;
                timer = 0;
            }
            
        }
        else if (ball.transform.position.y <= -15)
        {
            previousPos = ball.previousPos;
            Destroy(ball);
        }

        
    }
}
