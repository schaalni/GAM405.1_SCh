using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //access gamemanager from everywhere
    public static GameManager instance;

    public GameObject LivesHolder;
    public GameObject gameOverPanel;

    //setup score functionality to check whether score is going up or down
    int score = 0;
    int lives = 3;
    public bool gameOver = false;
    public Text scoreText;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //increment score
    public void IncrementScore()
    {
        if (!gameOver)
        {
            //add 1 to the score
            score++;
            scoreText.text = score.ToString();
            print(score);
        }
    }
    //decrement lives everytime the monster misses the candy
    public void DecreaseLife()
    {
        if (lives > 0)
        { lives--;
            print(lives);
            //deactivate object from scene
            LivesHolder.transform.GetChild(lives).gameObject.SetActive(false);
                }

        if (lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
    }
    public void GameOver()
    {
        //candies should not spawn when gameoOver is displayed
        CandySpawner.instance.StopSpawningCandies();
        //stop player from moving and score from changing
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        //set gameOverPanel inactive when game is over
        gameOverPanel.SetActive(true);
        print("GameOver()");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
