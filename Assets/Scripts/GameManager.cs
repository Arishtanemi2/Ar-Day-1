using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float score=0f;
    public Text scoreText;
    void Start()
    {
        scoreText.text=score.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene("scene2", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale=0f;
    }
    public void Resume()
    {
        Time.timeScale=1f;
    }
    public void EnemyKilled(float value)
    {
        score+=value;
        scoreText.text=score.ToString();
    }

}

