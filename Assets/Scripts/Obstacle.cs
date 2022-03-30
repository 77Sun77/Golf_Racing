using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public enum ObstacleType { Propeller, GroundTrap, Wall };
    public ObstacleType obstacleType;

    public bool clockwise; // �����緯

    SpriteRenderer sprite; // �� ����
    float alpha;
    float timer;
    bool isAlpha;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        alpha = 255;
        timer = 0;
        isAlpha = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(obstacleType == ObstacleType.Propeller)
        {
            if(clockwise) transform.Rotate(new Vector3(0, 0, -150) * Time.deltaTime);
            else transform.Rotate(new Vector3(0, 0, 150) * Time.deltaTime);
        }

        if(obstacleType == ObstacleType.GroundTrap)
        {
            if (!isAlpha && timer <= 0)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha / 255);
                alpha -= 200 * Time.deltaTime;
                
                if(alpha < 0)
                {
                    isAlpha = true;
                    timer = 3;
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            if (isAlpha && timer <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha / 255);
                alpha += 200 * Time.deltaTime;
                if(alpha >= 255)
                {
                    isAlpha = false;
                    timer = 0.5f;
                }
            }
            timer -= Time.deltaTime;
        }

        if(obstacleType == ObstacleType.Wall)
        {
            if (!isAlpha && timer <= 0)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha / 255);
                alpha -= 200 * Time.deltaTime;
                
                if(alpha < 0)
                {
                    isAlpha = true;
                    timer = 0.5f;
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            if (isAlpha && timer <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha / 255);
                alpha += 200 * Time.deltaTime;
                if(alpha >= 255)
                {
                    isAlpha = false;
                    timer = 3;
                }
            }
            timer -= Time.deltaTime;
        }
    }
}
