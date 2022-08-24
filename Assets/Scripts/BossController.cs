using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Boss firstBoss;
    private int ballAttack = 15; //�{�[���̍U���͉��ݒ�A���Ƃŕʂ̃X�N���v�g������������悤�ɂ���

    public class Boss
    {
        public int maxhp = 100;
        public int hp = 100;
        public GameObject uiController;
        public void Defence(int damage)
        {
            this.hp -= damage;
            //HP���}�C�i�X�ɂȂ�Ȃ��悤�ɂ���
            if(this.hp < 0)
             this.hp = 0;
            uiController = GameObject.Find("UIController");
            uiController.GetComponent<UIController>().Damage();
            Debug.Log("���݂�HP��" + hp + "");

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
