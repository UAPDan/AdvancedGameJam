using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameObject instance;
    public float timer;
    public bool timerRunning;
    public float bestTime;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        timer = 0;
        timerRunning = false;
        bestTime = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning)
        {
            timer += Time.deltaTime;
        }
        Debug.Log("Current Time: " + timer.ToString("F2"));
        Debug.Log("Best Time: " + bestTime.ToString("F2"));

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PlayerDeath()
    {
        timer = 0;
        timerRunning = false;
        SceneManager.LoadScene(0);
    }
}
