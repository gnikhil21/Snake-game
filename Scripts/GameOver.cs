using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text points;
    //public Score score;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        points.text="Score: "+score.ToString();
        
    }

    public void Restart()
    {
        Snake.score=0;
        Snake.dead=false;
        SceneManager.LoadScene("GameScene")  ;
        //snake.Start();

    }

    public void Exit()
    {
        Snake.score=0;
        Snake.dead=false;
        SceneManager.LoadScene("mainMenu")  ;
    }
}
