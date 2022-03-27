 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    string stageName;
    string mapName;

    void Start()
    {
        stageName = transform.parent.name;
        mapName = transform.name;
    }

    void MoveScene()
    {
        SceneManager.LoadScene(stageName);
    }

    public void Retry(Stage stage, string stageName, string map)
    {
        string mapName = stageName + "_" + map;
        this.stageName = stageName;
        this.mapName = map;
        stage.SendMessage(mapName);
    }
    public void MoveMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NextMap(Stage stage, string stageName, string nextMap)
    {
        string map = "";
        for (int i = 3; i < nextMap.Length; i++) map += nextMap[i];
        map = "Map"+(int.Parse(map)+1);
        string mapName = stageName + "_" + map;
        this.stageName = stageName;
        this.mapName = map;
        stage.SendMessage(mapName);
    }

    public void Stage1_Map1()
    {
        GameManager.StageReset(stageName, mapName, 10, 1);
        MoveScene();
    }
    public void Stage1_Map2()
    {
        GameManager.StageReset(stageName, mapName, 10, 1);
        MoveScene();
    }
    public void Stage1_Map3()
    {
        GameManager.StageReset(stageName, mapName, 15, 3);
        MoveScene();
    }
    public void Stage1_Map4()
    {
        GameManager.StageReset(stageName, mapName, 15, 3);
        MoveScene();
    }
    public void Stage1_Map5()
    {
        GameManager.StageReset(stageName, mapName, 10, 1);
        MoveScene();
    }
    public void Stage1_Map6()
    {
        GameManager.StageReset(stageName, mapName, 25, 3);
        MoveScene();
    }
    public void Stage1_Map7()
    {
        GameManager.StageReset(stageName, mapName, 10, 1);
        MoveScene();
    }
    public void Stage1_Map8()
    {
        GameManager.StageReset(stageName, mapName, 10, 1);
        MoveScene();
    }
    public void Stage1_Map9()
    {
        GameManager.StageReset(stageName, mapName, 10, 1);
        MoveScene();
    }
    public void Stage1_Map10()
    {
        GameManager.StageReset(stageName, mapName, 30, 5);
        MoveScene();
    }
    public void Stage1_Map11()
    {
        GameManager.StageReset(stageName, mapName, 25, 5);
        MoveScene();
    }
    public void Stage1_Map12()
    {
        GameManager.StageReset(stageName, mapName, 55, 10);
        MoveScene();
    }
    public void Stage1_Map13()
    {
        GameManager.StageReset(stageName, mapName, 40, 5);
        MoveScene();
    }
    public void Stage1_Map14()
    {
        GameManager.StageReset(stageName, mapName, 45, 5);
        MoveScene();
    }
    public void Stage1_Map15()
    {
        GameManager.StageReset(stageName, mapName, 75, 10);
        MoveScene();
    }
    public void Stage1_Map16()
    {
        GameManager.StageReset(stageName, mapName, 30, 3);
        MoveScene();
    }
    public void Stage1_Map17()
    {
        GameManager.StageReset(stageName, mapName, 30, 5);
        MoveScene();
    }
    public void Stage1_Map18()
    {
        GameManager.StageReset(stageName, mapName, 30, 5);
        MoveScene();
    }

}
