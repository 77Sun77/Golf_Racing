using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageClear : MonoBehaviour
{
    RectTransform background;
    void Start()
    {
        background = transform.Find("BG").GetComponent<RectTransform>();
        StartCoroutine(Clear());
    }

    void Update()
    {
        
    }
    
    IEnumerator Clear()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            background.position = Vector2.Lerp(background.position, transform.position, 3f * Time.deltaTime);
        }
    }
}
