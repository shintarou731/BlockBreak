using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject bossHPUI;
    private GameObject boss;
    private GameObject ball;
    private GameObject gameOverText;
    private GameObject gameClearText;
    private GameObject ballNumberText;
    BossController bossController;
    BallController ballController;

    // Start is called before the first frame update
    void Start()
    {
        //�V�[���r���[����{�XUI�A�c�@��UI�A�{�[���A�{�X�I�u�W�F�N�g������
        bossHPUI = GameObject.Find("BossHp");
        gameOverText = GameObject.Find("GameOverText");
        gameClearText = GameObject.Find("GameClearText");
        ballNumberText = GameObject.Find("BallNumberText");
        ball = GameObject.Find("Ball");
        boss = GameObject.Find("Boss");

        //�e�X�N���v�g�ɃA�N�Z�X
        bossController = boss.GetComponent<BossController>();
        ballController = ball.GetComponent<BallController>();
        //�{�XUI�̃X���C�_�[���}�b�N�X
        bossHPUI.GetComponent<Slider>().value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(ballController.isGameOver == true)
        {
            gameOverText.GetComponent<Text>().text = "GAME OVER";
        }
        else
            ballNumberText.GetComponent<Text>().text = "�~ " + ballController.ballNumber + ""; //�c�@�\��

        if (bossController.isGameClear == true)
        {
            gameClearText.GetComponent<Text>().text = "GAME CLEAR!!";
        }
    }

    //�{�XHP�̑�����\������֐�
    public void Damage()
    {
        bossHPUI.GetComponent<Slider>().value = (float)bossController.hp / (float)bossController.maxhp;
    }
}
