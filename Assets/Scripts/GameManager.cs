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

    public GameObject StageClear;
    void Awake()
    {
        instance = this;
        UI = GameObject.Find("Canvas").transform.Find("UI").gameObject;
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        GameObject.Find("Map").transform.Find(stage).gameObject.SetActive(true);
        StageClear = GameObject.Find("Canvas").transform.Find("StageClear").gameObject;
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
                UI.transform.Find("Power Gage").transform.Find("GageBG").transform.Find("Button").GetComponent<PowerGage>().ball = ball;
                UI.SetActive(true);
                ball.transform.position = previousPos;
                ball.previousPos = previousPos;
                timer = 0;
            }
            
        }
        else if (ball.transform.position.y <= -15)
        {
            previousPos = ball.previousPos;
            Destroy(ball.gameObject);
        }

        
    }

    public void GameClear()
    {
        StageClear.SetActive(true);
    }
}
