using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    GameObject stage1, stage2, stage3;

    public Sprite[] star;
    void Start()
    {
        stage1 = GameObject.Find("Canvas").transform.Find("Stage").transform.Find("BG").transform.Find("Stage1").gameObject;


        FirstSetting();
    }

    
    void Update()
    {
        
    }

    void FirstSetting()
    {
        for(int i = 0; i < 18; i++)
        {
            string mapName = "Map" + (i + 1).ToString();
            if (PlayerPrefs.HasKey(mapName))
            {
                stage1.transform.Find(mapName).transform.Find("StarBG").gameObject.SetActive(true);
                stage1.transform.Find(mapName).GetComponent<Button>().interactable = true;
                if (PlayerPrefs.GetInt(mapName) != 0)
                {
                    stage1.transform.Find(mapName).transform.Find("Star").gameObject.SetActive(true);
                    stage1.transform.Find(mapName).transform.Find("Star").GetComponent<Image>().sprite = star[PlayerPrefs.GetInt(mapName)-1];
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
