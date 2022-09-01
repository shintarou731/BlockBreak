using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private int ballAttack;
    public GameObject shelterManager;

    public int maxhp;
    public int hp;
    public float attack;
    private GameObject uiController;
    public bool isGameClear = false;
    public GameObject bulletPrefab;
    public float attackInterval;

    // Start is called before the first frame update
    void Start()
    {
        //シェルターマネージャーを取得
        this.shelterManager = GameObject.Find("ShelterManager");
        //ボールの攻撃力をシェルターから拾ってくる
        this.ballAttack = this.shelterManager.GetComponent<ShelterManager>().GetShelter("プレイヤー").GetBallAttack();
        //ボスのHPと攻撃力をシェルターから拾ってくる
        this.maxhp = this.shelterManager.GetComponent<ShelterManager>().GetShelter("ボス1").GetHp();
        this.hp = maxhp;
        this.attack = this.shelterManager.GetComponent<ShelterManager>().GetShelter("ボス1").GetAttack();

        //ボスが一定間隔で攻撃
        InvokeRepeating("shot", 2f, attackInterval);
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
        hp -= damage;
        //HPがマイナスにならないようにする
        if (hp < 0)
            hp = 0;
        //UIコントローラーのHP反映関数を実行
        uiController = GameObject.Find("UIController");
        uiController.GetComponent<UIController>().Damage();
        //ボス倒したらクリア
        if (hp == 0)
        {
            isGameClear = true;
            Time.timeScale = 0;
        }
        /*
        Debug.Log("現在のmaxHPは" + maxhp + "");
        Debug.Log("現在のHPは" + hp + "");
        Debug.Log("プレイヤーの攻撃力は" + ballAttack + "");
        */
    }

    //真下に攻撃
    private void shot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }


}
