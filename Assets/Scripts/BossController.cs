using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Boss firstBoss;
    private int ballAttack = 15; //ボールの攻撃力仮設定、あとで別のスクリプトから引っ張れるようにする

    public class Boss
    {
        public int maxhp = 100;
        public int hp = 100;
        public GameObject uiController;
        public void Defence(int damage)
        {
            this.hp -= damage;
            //HPがマイナスにならないようにする
            if(this.hp < 0)
             this.hp = 0;
            uiController = GameObject.Find("UIController");
            uiController.GetComponent<UIController>().Damage();
            Debug.Log("現在のHPは" + hp + "");

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        firstBoss = new Boss();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BallTag")
        {
            firstBoss.Defence(ballAttack);
        }

    }

}
