using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;

    public GameObject gameOverScreen;
    public GameObject bird;
    public AudioSource audioScore;
    public AudioSource audioGameOver;
    public int highScore;

    private void Start() {
        highScore = PlayerPrefs.HasKey("highScore") ? PlayerPrefs.GetInt("highScore") : 0;
        highScoreText.text = "High Score: "+highScore;
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {

        BirdScript birdScript = bird.GetComponent<BirdScript>();

        if (birdScript.birdIsAlive)
        {

            audioScore.Play();

            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {

        if(playerScore > highScore){
            PlayerPrefs.SetInt("highScore", playerScore);
        }

        if(!audioGameOver.isPlaying){
            audioGameOver.Play();
        }
        gameOverScreen.SetActive(true);
    }
}
