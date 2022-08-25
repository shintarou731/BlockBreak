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
    private GameObject ballNumberText;
    BossController bossController;
    BallController ballController;

    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからボスUI、残機数UI、ボール、ボスオブジェクトを検索
        bossHPUI = GameObject.Find("BossHp");
        gameOverText = GameObject.Find("GameOverText");
        ballNumberText = GameObject.Find("BallNumberText");
        ball = GameObject.Find("Ball");
        boss = GameObject.Find("Boss");

        //各スクリプトにアクセス
        bossController = boss.GetComponent<BossController>();
        ballController = ball.GetComponent<BallController>();
        //ボスUIのスライダーをマックス
        bossHPUI.GetComponent<Slider>().value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(ballController.isGameOver == false)
        {
            ballNumberText.GetComponent<Text>().text = "× " + ballController.ballNumber + "";
        }
        else
         gameOverText.GetComponent<Text>().text = "Game Over";
    }

    //ボスHPの増減を表示する関数
    public void Damage()
    {
        bossHPUI.GetComponent<Slider>().value = (float)bossController.hp / (float)bossController.maxhp;
    }
}
