using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    //�o�[�̈ړ����x
    public float barSpeed = 0.2f;

    //�����̃o�[�̒����ɒu����ǂ̓����̔���
    public float inFlame = 22f;


    // Start is called before the first frame update
    void Start()
    {
        
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
