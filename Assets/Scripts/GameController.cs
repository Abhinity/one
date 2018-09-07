using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spanValues;
    public int hazardcount;
    public float startwait;
    public float spawnwait;
    public float wavewait;

    public Text scoreText;
    public Text RestartText;
    public Text GameOverText;

    private bool gameover;
    private bool restart;
    private int score;

    void Start()
    {
        
        gameover = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startwait);
        while (true)
        {
            for (int i = 0; i < hazardcount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spanValues.x, spanValues.x), spanValues.y, spanValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnwait);
            }
            yield return new WaitForSeconds(wavewait);

            if (gameover)
            {
                RestartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int ScoreValue)
    {
        score = score + ScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void Gameover()
    {
        GameOverText.text = "Game Over!";
        gameover = true;
    }
}
