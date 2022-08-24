using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject bossHPUI;
    private GameObject boss;
    BossController bossController;

    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトの実態を検索する
        this.bossHPUI = GameObject.Find("BossHp");
        
        //スライダーをマックス
        this.bossHPUI.GetComponent<Slider>().value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボスHPの増減を表示する関数
    public void Damage()
    {
        boss = GameObject.Find("Boss");
        bossController = boss.GetComponent<BossController>();
        this.bossHPUI.GetComponent<Slider>().value = (float)bossController.firstBoss.hp / (float)bossController.firstBoss.maxhp;
    }
}
