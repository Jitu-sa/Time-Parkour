using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputSystem : MonoBehaviour
{
    int currentScene;
    void Start()
    {
        int sceneNumber;
        if (int.TryParse(SceneManager.GetActiveScene().name, out sceneNumber))
        {
            currentScene = sceneNumber;
        }
    }
    public void Next_Level()
    {
        string nextlevelname=(currentScene+1).ToString();
        SceneManager.LoadScene(nextlevelname);

    }

    public void Repeat_Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //#################################################################################

    public void Change_Level_Spring()
    {
        SceneManager.LoadScene("LevelManagerSpringScene");
    }

    public void Change_Level_Autmn()
    {
        SceneManager.LoadScene("LevelManagerAutmnScene");
    }

    public void Change_Level_Winter()
    {
        SceneManager.LoadScene("LevelManagerWinterScene");
    }

    //##################################################################################

    public void Play()
    {
        GameObject lobbycanvas = GameObject.Find("Lobby canvas");
        GameObject Globallevelcanvas = GameObject.Find("Global Level Canvas");

        Globallevelcanvas.GetComponent<Canvas>().sortingOrder=4;
        lobbycanvas.GetComponent<Canvas>().sortingOrder = -1;
    }

    public void Back()
    {
        GameObject lobbycanvas = GameObject.Find("Lobby canvas");
        GameObject Globallevelcanvas = GameObject.Find("Global Level Canvas");

        Globallevelcanvas.GetComponent<Canvas>().sortingOrder = -1;
        lobbycanvas.GetComponent<Canvas>().sortingOrder = 4;
    }
}
