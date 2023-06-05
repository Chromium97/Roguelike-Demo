using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public Text scoreValue;

    public void Start()
    {
        
    }
    public void setGameOver(int score)
    {
        gameObject.SetActive(true);
        scoreValue.text = "Your Score is:  " + score.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
