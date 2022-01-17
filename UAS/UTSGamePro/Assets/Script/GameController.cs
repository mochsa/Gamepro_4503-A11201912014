using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;
    public Text bestscoreText;
    public Text yourscoreText;
    public GameObject NewScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        Invoke("ShowOverPanel",2.0f); 
    }

    void ShowOverPanel(){
        scoreText.gameObject.SetActive(false);
        if(score > PlayerPrefs.GetInt("BestScore", 0)) {
            PlayerPrefs.SetInt("BestScore", score);
            NewScore.SetActive(true);
        }
        bestscoreText.text = "Best Score : " + PlayerPrefs.GetInt("BestScore", 0).ToString();
        yourscoreText.text = "Your Score : " + score.ToString();
        gameOverPanel.SetActive(true);

    }

    public void Restart() {
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void IncrementStore() {
        score++;
        scoreText.text = score.ToString();
    }
}
