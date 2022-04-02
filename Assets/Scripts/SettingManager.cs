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

    int AllStar;
    public Button stage2Button;
    public Text stage2Text;

    void Start()
    {
        AllStar = 0;
        if (GameManager.instance == null) FirstSetting();
        if (GameManager.stageName != "") stageName = GameManager.stageName;
        
    }


    void Update()
    {
        if (isStageOpen && isMenu)
        {
            StageObject.SetActive(true);
            StageObject.transform.Find("BG").transform.Find(stageName).gameObject.SetActive(true);
            isStageOpen = false;
        }

        if (isMenu)
        {
            if (stage1.active) stageText.text = "Stage 1";
            else if (stage2.active) stageText.text = "Stage 2";
        }

        if(isMenu && PlayerPrefs.GetInt("Stage1_Map18") > 0)
        {
            if (AllStar >= 50)
            {
                stage2Button.interactable = true;
            }
            else
            {
                stage2Text.gameObject.SetActive(true);
                stage2Text.text = AllStar + "/50";
            }
        }

    }

    void FirstSetting()
    {
        isMenu = true;
        stage1 = GameObject.Find("Canvas").transform.Find("Stage").transform.Find("BG").transform.Find("Stage1").gameObject;
        stage2 = GameObject.Find("Canvas").transform.Find("Stage").transform.Find("BG").transform.Find("Stage2").gameObject;
        for (int i = 0; i < 18; i++)
        {
            string mapName = "Map" + (i + 1).ToString();
            if (PlayerPrefs.HasKey("Stage1_" + mapName))
            {
                stage1.transform.Find(mapName).transform.Find("StarBG").gameObject.SetActive(true);
                stage1.transform.Find(mapName).GetComponent<Button>().interactable = true;
                if (PlayerPrefs.GetInt("Stage1_" + mapName) != 0)
                {
                    stage1.transform.Find(mapName).transform.Find("Star").gameObject.SetActive(true);
                    stage1.transform.Find(mapName).transform.Find("Star").GetComponent<Image>().sprite = star[PlayerPrefs.GetInt("Stage1_" + mapName) - 1];
                    AllStar += PlayerPrefs.GetInt("Stage1_" + mapName);

                }

            }
        }
        for (int i = 0; i < 18; i++)
        {
            string mapName = "Map" + (i + 1).ToString();
            if (PlayerPrefs.HasKey("Stage2_" + mapName))
            {
                stage2.transform.Find(mapName).transform.Find("StarBG").gameObject.SetActive(true);
                stage2.transform.Find(mapName).GetComponent<Button>().interactable = true;
                if (PlayerPrefs.GetInt("Stage2_" + mapName) != 0)
                {
                    stage2.transform.Find(mapName).transform.Find("Star").gameObject.SetActive(true);
                    stage2.transform.Find(mapName).transform.Find("Star").GetComponent<Image>().sprite = star[PlayerPrefs.GetInt("Stage2_" + mapName) - 1];
                    AllStar += PlayerPrefs.GetInt("Stage2_" + mapName);
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
