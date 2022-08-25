using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public GameObject shelterManager;
    //�o�[�̈ړ����x
    public float barSpeed = 0.2f;

    //�����̃o�[�̒����ɒu����ǂ̓����̔���
    public float inFlame = 22f;

    //�o�[�̃T�C�Y�̕ϐ��錾
    private Vector3 barScale = new Vector3(1, 2, 1);
    //�o�[�̉���
    public float barLength;

    // Start is called before the first frame update
    void Start()
    {
        //�V�F���^�[�}�l�[�W���[���擾
        this.shelterManager = GameObject.Find("ShelterManager");
        //�o�[�̉������V�F���^�[����E���đ��
        this.barLength = this.shelterManager.GetComponent<ShelterManager>().GetShelter("�v���C���[").GetBarLength();
        barScale.x = barLength;
        transform.localScale = barScale;

    }

    // Update is called once per frame
    void Update()
    {
        //�g�O�ɂ͏o�Ȃ��悤�Ƀo�[�𓮂���
        if (Input.GetKey(KeyCode.LeftArrow))
        {
           if (this.transform.position.x > -inFlame)
                this.transform.Translate(-barSpeed, 0, 0);
        }
            

        if (Input.GetKey(KeyCode.RightArrow))
        {
           if(this.transform.position.x < inFlame)
            this.transform.Translate(barSpeed, 0, 0);
        }
           

    }
}
