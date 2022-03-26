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

        // vec���� m_fRadius �̻��� ���� �ʵ��� �մϴ�.
        vec = Vector2.ClampMagnitude(vec, joystickRadius);
        joystick.localPosition = vec;


        // ���̽�ƽ ���� ���̽�ƽ���� ���� ���ϱ�.
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
        // ���� ��ġ�� �ǵ����ϴ�.
        joystick.localPosition = Vector2.zero;
    }
}
