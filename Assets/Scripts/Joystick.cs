using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Ball ball;

    RectTransform joystickBG;
    RectTransform joystick;
    float joystickRadius;
    Vector2 downVec;
    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        joystickBG = GameManager.instance.UI.transform.Find("Joystick").transform.Find("JoystickBG").GetComponent<RectTransform>();
        joystick = GameManager.instance.UI.transform.Find("Joystick").transform.Find("JoystickBG/Joystick").GetComponent<RectTransform>();
        joystickRadius = joystickBG.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTouch(Vector2 dragVec)
    {
        Vector2 vec = new Vector2(dragVec.x - joystickBG.position.x, dragVec.y - joystickBG.position.y);

        // vec값을 m_fRadius 이상이 되지 않도록 합니다.
        vec = Vector2.ClampMagnitude(vec, joystickRadius);
        joystick.localPosition = vec;


        // 조이스틱 배경과 조이스틱과의 방향 구하기.
        float angle = Mathf.Atan2(dragVec.y - downVec.y, dragVec.x - downVec.x) * Mathf.Rad2Deg;
        ball.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        downVec = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 원래 위치로 되돌립니다.
        joystick.localPosition = Vector2.zero;
    }
}
