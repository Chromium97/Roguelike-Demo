using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{

    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MonsterInfo()
    {
        SceneManager.LoadScene(2);
    }

    public void PowerUpInfo()
    {
        SceneManager.LoadScene(3);
    }
}
