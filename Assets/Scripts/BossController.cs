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
    public bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        //�V�F���^�[�}�l�[�W���[���擾
        this.shelterManager = GameObject.Find("ShelterManager");
        //�{�[���̍U���͂��V�F���^�[����E���Ă���
        this.ballAttack = this.shelterManager.GetComponent<ShelterManager>().GetShelter("�v���C���[").GetBallAttack();
        //�{�X��HP���V�F���^�[����E���Ă���
        this.maxhp = this.shelterManager.GetComponent<ShelterManager>().GetShelter("�{�X1").GetHp();
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
        hp -= damage;
        //HP���}�C�i�X�ɂȂ�Ȃ��悤�ɂ���
        if (hp < 0)
            hp = 0;
        //UI�R���g���[���[��HP���f�֐������s
        uiController = GameObject.Find("UIController");
        uiController.GetComponent<UIController>().Damage();
        //�{�X�|������N���A
        if (hp == 0)
        {
            isGameClear = true;
            Time.timeScale = 0;
        }
        Debug.Log("���݂�maxHP��" + maxhp + "");
        Debug.Log("���݂�HP��" + hp + "");
        Debug.Log("�v���C���[�̍U���͂�" + ballAttack + "");

    }

}
