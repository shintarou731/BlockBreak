using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private int ballAttack;
    public GameObject shelterManager;

    public int maxhp;
    public int hp;
    public GameObject uiController;


    // Start is called before the first frame update
    void Start()
    {
        //シェルターマネージャーを取得
        this.shelterManager = GameObject.Find("ShelterManager");
        //ボールの攻撃力をシェルターから拾ってくる
        this.ballAttack = this.shelterManager.GetComponent<ShelterManager>().GetShelter("プレイヤー").GetBallAttack();
        //ボスのHPをシェルターから拾ってくる
        this.maxhp = this.shelterManager.GetComponent<ShelterManager>().GetShelter("ボス1").GetHp();
        this.hp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BallTag")
        {
            Defence(ballAttack);
        }

    }

    public void Defence(int damage)
    {
        this.hp -= damage;
        //HPがマイナスにならないようにする
        if (this.hp < 0)
            this.hp = 0;
        uiController = GameObject.Find("UIController");
        uiController.GetComponent<UIController>().Damage();
        Debug.Log("現在のmaxHPは" + maxhp + "");
        Debug.Log("現在のHPは" + hp + "");
        Debug.Log("プレイヤーの攻撃力は" + ballAttack + "");

    }

}
