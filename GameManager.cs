using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    private int score;
    private bool isGameOver;
    public static GameManager Instance { get; private set; }

     void Start()
    {
        if(Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;
    }

    private void Update()
    {
        if(isGameOver && Input.anyKeyDown)
        {
            ResetGame();
        }
    }

    private  void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int points)
    { 
        score += points;
        scoreText.text = "SCORE: " + score.ToString();
    
    }
    
    public void StopGame()
    {
        isGameOver = true;
        StopScroll();
        StopSpawn();
        ShowGameOverPanel();

    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    private void StopSpawn()
    {
        Spawner[] spawnerObjects = FindObjectsOfType<Spawner>();
        foreach(Spawner spawner in spawnerObjects)
            spawner.StopSpawn();
    }

    private void StopScroll()
    {
        Scroll[] scrollObjects = FindObjectsOfType<Scroll>();

        foreach (Scroll scrollObject in scrollObjects)
        {
            scrollObject.StopScroll();
        }
    }
}
