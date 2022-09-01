using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool pauseNow;
    //�Q�[���I�[�o�[�ƃQ�[���N���A
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
        Time.timeScale = 0;  // ���Ԓ�~
        pausePanel.SetActive(true);
        pauseNow = true;
    }

    private void Resume()
    {
        Time.timeScale = 1;  // �ĊJ
        pausePanel.SetActive(false);
        pauseNow = false;
    }
}
