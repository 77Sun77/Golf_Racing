using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject UI;

    public GameObject Ball;
    Ball ball;

    public static string mapName = "Map17";
    public static string stageName;

    Vector2 previousPos;
    float deathTimer;
    
    public GameObject StageClear;
    Stage stage;
    bool isClear;

    public static float timer = 10;
    GameObject timerParent;
    Text timerText;
    bool isTimeOver;

    public static int maxBounceCount;
    public int bounceCount;
    GameObject bounceParent;
    Text bounceText;


    public int starNum;
    Image starImage;
    public Sprite[] star;


    bool isMenuOnOff;
    GameObject menuWindow;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1;
        UI = GameObject.Find("Canvas").transform.Find("UI").gameObject;
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        GameObject.Find("Map").transform.Find(mapName).gameObject.SetActive(true);

        StageClear = GameObject.Find("Canvas").transform.Find("StageClear").gameObject;
        stage = GetComponent<Stage>();
        isClear = false;
        deathTimer = 0;

        timerParent = GameObject.Find("Timer");
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        isTimeOver = false;

        bounceParent = GameObject.Find("ShotCount");
        bounceText = GameObject.Find("CountText").GetComponent<Text>();

        starNum = 3;
        starImage = StageClear.transform.Find("BG").transform.Find("Star").GetComponent<Image>();

        bounceCount = 0;

        isMenuOnOff = false;

        menuWindow = GameObject.Find("Canvas").transform.Find("Menu").gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) GameMenuOnOff();

        if (ball == null)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer >= 2)
            {
                ball = Instantiate(Ball).GetComponent<Ball>();
                UI.transform.Find("Joystick").GetComponent<Joystick>().ball = ball;
                UI.transform.Find("Power Gage").transform.Find("GageBG").transform.Find("Button").GetComponent<PowerGage>().ball = ball;
                UI.SetActive(true);
                ball.transform.position = previousPos;
                ball.previousPos = previousPos;
                deathTimer = 0;
            }
            
        }
        else if (ball.transform.position.y <= -15)
        {
            Death();
        }

        if(timerParent != null && !isClear)
        {
            if (timer <= 1)
            {
                timerParent.transform.Translate(transform.up * 150 * Time.deltaTime);
                if(!isTimeOver)
                {
                    isTimeOver = true;
                    starNum -= 1;
                }
                if (timerParent.transform.localPosition.y >= 170)
                {
                    Destroy(timerParent);
                }
                
            }
            else
            {
                timer -= Time.deltaTime;
                timerText.text = ((int)timer).ToString();
            }
        }

        if (bounceParent != null)
        {
            if(bounceCount > maxBounceCount)
            {
                bounceParent.transform.Translate(transform.up * 150 * Time.deltaTime);
                if (bounceParent.transform.localPosition.y >= 170)
                {
                    starNum -= 1;
                    Destroy(bounceParent);
                }
            }
            else
            {
                bounceText.text = bounceCount + " / " + maxBounceCount;
            }
        }
    }

    public void GameClear()
    {
        StageClear.SetActive(true);
        isClear = true;
        starImage.sprite = star[starNum - 1];

        if(mapName != "Map18")
        {
            string map_Name = "";
            for (int i = 3; i < mapName.Length; i++)
            {
                map_Name += mapName[i];
            }
            int mapNum = int.Parse(map_Name) + 1;

            if (!PlayerPrefs.HasKey(stageName + "_" + "Map" +mapNum.ToString())) PlayerPrefs.SetInt(stageName+"_"+"Map" + mapNum, 0);

        }
        if(PlayerPrefs.GetInt(stageName+"_"+mapName) < starNum || !PlayerPrefs.HasKey(stageName + "_" + mapName)) PlayerPrefs.SetInt(stageName + "_"+mapName, starNum);
    }

    public static void StageReset(string stage, string map, float Timer, int BounceCount)
    {
        stageName = stage;
        mapName = map;
        timer = Timer+1;
        maxBounceCount = BounceCount;
    }

    public void Retry()
    {
        stage.Retry(stage, stageName, mapName);
    }
    public void MoveMenu()
    {
        stage.MoveMenu(stageName);
    }
    public void NextGame()
    {
        stage.NextMap(stage, stageName, mapName);
    }

    public void GameMenuOnOff()
    {
        isMenuOnOff = !isMenuOnOff;
        menuWindow.SetActive(isMenuOnOff);
        if (Time.timeScale == 0) Time.timeScale = 1;
        else Time.timeScale = 0;
    }

    public void Death()
    {
        previousPos = ball.previousPos;
        UI.SetActive(false);
        Destroy(ball.gameObject);
    }
}
