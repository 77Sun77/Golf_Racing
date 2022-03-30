using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PowerGage : MonoBehaviour, IPointerDownHandler
{
    public Ball ball;
    Slider gage;
    Text text;
    bool isUp;
    float power;

    float number;
    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        gage = GameManager.instance.UI.transform.Find("Power Gage").transform.Find("GageBG").GetComponent<Slider>();
        text = gage.transform.Find("Text").GetComponent<Text>();
        isUp = false;
        number = 0.65f;
    }


    void Update()
    {
        if (isUp)
        {
            gage.value += number * Time.deltaTime;
            if(gage.value >= gage.maxValue) number = -0.65f;
            if(gage.value <= gage.minValue) number = 0.65f;
            power = gage.value;
            text.text = (int)(gage.value * 100)+"%";
        }
        
    }

    public void ButtonClick()
    {
        if (!ball.isShot)
        {
            if (isUp)
            {
                Shot();
                Cancle();
                return;
            }
            isUp = true;
            
        }
    }
    public void Cancle()
    {
        isUp = false;
        power = 0;
        gage.value = 0f;
    }

    void Shot()
    {
        GameManager.instance.UI.SetActive(false);
        ball.shootPower = 40 * power;
        ball.Shot();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonClick();
    }
}
