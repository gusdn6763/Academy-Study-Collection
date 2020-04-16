using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Fish fish;
    [SerializeField] GameObject pipes;
    [SerializeField] GamePanel gameReadyPanel;
    [SerializeField] GamePanel gamePlayPanel;
    [SerializeField] GamePanel gameOverPanel;
    
    [SerializeField] Text bestScoreText;
    [SerializeField] int bestScore;
    enum State
    {
        READY, PLAY, OVER
    }
    State state;
    int score;

    void Start()
    {
        pipes.SetActive(false);
        state = State.READY;
        fish.SetKinematic(true);

        Load();
        bestScoreText.text = bestScore.ToString();
    }

    void Update()
    {
        switch (state)
        {
            case State.READY:
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                break;
            case State.PLAY:
                if (fish.IsDead) GameOver();
                break;
            case State.OVER:
                // if (Input.GetButtonDown("Fire1"))
                // {
                //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                // }
                break;
        }
    }

    void GameStart()
    {
        state = State.PLAY;

        fish.SetKinematic(false);
        pipes.SetActive(true);
        gamePlayPanel.Open();
        gameReadyPanel.Close();
    

        // GamePlayPanel 활성화
        
    }

    void GameOver()
    {
        state = State.OVER;

        if(score>bestScore)
        {
            bestScore = score;
            Save();
            bestScoreText.text = bestScore.ToString();
        }

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        foreach (ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }
        //gameoverpanel 활성화
        gamePlayPanel.Close();
        gameOverPanel.Open();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("bestScore",bestScore);
    }

    public void Load()
    {
        bestScore = PlayerPrefs.GetInt("bestScore",bestScore);
    }
}
