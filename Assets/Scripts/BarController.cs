using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public GameObject shelterManager;
    public GameObject boss;
    private float attack_1;
    //�o�[�̈ړ����x
    public float barSpeed = 100;
    //�o�[�̃T�C�Y�̕ϐ��錾
    private Vector3 barScale = new Vector3(1, 2, 1);
    //�o�[�̉����錾
    public float barLength;
    //�o�[�̉����̍ŏ��l
    private float minBarLength = 5;
    //�ǂɓ������Ă�H
    private bool leftWallCollision = false;
    private bool rightWallCollision = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //�V�F���^�[�}�l�[�W���[���擾
        this.shelterManager = GameObject.Find("ShelterManager");
        //�o�[�̉������V�F���^�[����E���đ��
        this.barLength = this.shelterManager.GetComponent<ShelterManager>().GetShelter("�v���C���[").GetBarLength();
        barScale.x = barLength;
        transform.localScale = barScale;

        //�{�X�̍U���͂��E���đ��
        attack_1 = boss.GetComponent<BossController>().attack;
    }

    // Update is called once per frame
    void Update()
    {
        //�g�O�ɂ͏o�Ȃ��悤�Ƀo�[�𓮂���
        if (Input.GetKey(KeyCode.LeftArrow) && leftWallCollision == false)
        {
            this.transform.Translate(-barSpeed * Time.deltaTime, 0, 0);
            rightWallCollision = false;
        }
            

        if (Input.GetKey(KeyCode.RightArrow) && rightWallCollision == false)
        {
            this.transform.Translate(barSpeed * Time.deltaTime, 0, 0);
            leftWallCollision = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "LeftWallTag")
        {
            leftWallCollision = true;
        }

        if (other.gameObject.tag == "RightWallTag")
            rightWallCollision = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletTag")
        {
            Damage(attack_1);
        }
    }

    //�_���[�W�H��������̏���
    private void Damage(float damage)
    {
        barScale.x -= damage;
        if (barScale.x < minBarLength)
            barScale.x = minBarLength;

        transform.localScale = barScale;
    }
}
