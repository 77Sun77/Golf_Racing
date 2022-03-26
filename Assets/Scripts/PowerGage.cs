using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PowerGage : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Ball ball;
    Slider gage;
    bool isUp;
    float power;
    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        gage = GameObject.Find("Canvas").transform.Find("Power Gage").transform.Find("GageBG").GetComponent<Slider>();
        isUp = false;
    }


    void Update()
    {
        if (isUp)
        {
            power = gage.value;
            ball.shotPower = power;
        }
        else
        {
            power = 0;
            gage.value = 0.3f;
            ball.shotPower = power;
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        isUp = true;
        print("s");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isUp = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isUp = false;
    }
}
