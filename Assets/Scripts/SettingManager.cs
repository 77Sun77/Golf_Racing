using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    GameObject stage1, stage2, stage3;

    public Sprite[] star;

    bool isMenu;

    public static bool isStageOpen;
    public string stageName;
    public GameObject StageObject;
    public Text stageText;

    void Start()
    {
        if (GameManager.instance == null) FirstSetting();
        if (GameManager.stageName != "") stageName = GameManager.stageName;

    }


    void Update()
    {
        if (isStageOpen && isMenu)
        {
            StageObject.SetActive(true);
            StageObject.transform.Find("BG").transform.Find(stageName).gameObject.SetActive(true);
            stageText.text = stageName;
            isStageOpen = false;
        }
    }

    void FirstSetting()
    {
        isMenu = true;
        stage1 = GameObject.Find("Canvas").transform.Find("Stage").transform.Find("BG").transform.Find("Stage1").gameObject;

        for (int i = 0; i < 18; i++)
        {
            string mapName = "Map" + (i + 1).ToString();
            if (PlayerPrefs.HasKey(mapName))
            {
                stage1.transform.Find(mapName).transform.Find("StarBG").gameObject.SetActive(true);
                stage1.transform.Find(mapName).GetComponent<Button>().interactable = true;
                if (PlayerPrefs.GetInt(mapName) != 0)
                {
                    stage1.transform.Find(mapName).transform.Find("Star").gameObject.SetActive(true);
                    stage1.transform.Find(mapName).transform.Find("Star").GetComponent<Image>().sprite = star[PlayerPrefs.GetInt(mapName) - 1];
                }

            }
        }
    }

    public void DBReset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
    public void Shutdown()
    {
        Application.Quit();
    }
}