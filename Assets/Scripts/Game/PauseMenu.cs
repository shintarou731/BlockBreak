using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool pauseNow;
    //ゲームオーバーとゲームクリア
    private GameObject Boss;
    private GameObject Ball;
    private bool isGameClear;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        pauseNow = false;

        Boss = GameObject.Find("Boss");
        Ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        this.isGameClear = Boss.GetComponent<BossController>().isGameClear;
        this.isGameOver = Ball.GetComponent<BallController>().isGameOver;

        if (Input.GetKeyDown("space") && pauseNow == false && isGameOver == false && isGameClear == false)
        {
            Pause();
        }
        else if (Input.GetKeyDown("space") && pauseNow == true && isGameOver == false && isGameClear == false)
        {
            Resume();
        }
    }
    private void Pause()
    {
        Time.timeScale = 0;  // 時間停止
        pausePanel.SetActive(true);
        pauseNow = true;
    }

    private void Resume()
    {
        Time.timeScale = 1;  // 再開
        pausePanel.SetActive(false);
        pauseNow = false;
    }
}
