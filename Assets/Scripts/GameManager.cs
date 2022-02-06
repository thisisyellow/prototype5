using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titelScreen;

    public bool isGameActive;

    private float spawnRate = 1.0f;
    private int score;

    public void StartGame(int difficult)
	{
        isGameActive = true;        
        score = 0;
        spawnRate /= difficult;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
        titelScreen.gameObject.SetActive(false);
    }
    void Start()
    {
               
    }

    public void UpdateScore(int scoreToAdd)
	{
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
    IEnumerator SpawnTargets()
	{
		while (isGameActive)
		{
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
		}
	}
    public void GameOver()
    { 
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
    void Update()
    {
        
    }
}
