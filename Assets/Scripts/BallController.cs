using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject shelterManager;
    //�{�[���̎c�@
    public int ballNumber;
    //�{�[���̏���
    private float speed = 1000f;
    //���ɓ�����x�ɏオ�鑬�x�̔{��
    private float acceleration = 1.2f;
    //RigitBody�擾
    private Rigidbody myRigidbody;
    //�Q�[���n�܂��Ă�H
    public bool gameRunning = false;
    //���[�ނ��[�΁[
    public bool isGameOver = false;

    public AudioClip se1;
    public AudioClip se2;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //RigitBody�擾
        this.myRigidbody = GetComponent<Rigidbody>();
        //AudioSource�擾
        this.audioSource = GetComponent<AudioSource>();
        //�V�F���^�[�}�l�[�W���[���擾
        shelterManager = GameObject.Find("ShelterManager");
        //�{�[���̎c�@���V�F���^�[����E��
        this.ballNumber = shelterManager.GetComponent<ShelterManager>().GetShelter("�v���C���[").GetBallNumber();

        //�ŏ��ɉE��Ƀ{�[����ł��o��
        Vector3 force = new Vector3(speed, 0, speed); 
        myRigidbody.AddForce(force);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //������x�ɑ��x���X�ɏオ��
        Vector3 bound = new Vector3(this.myRigidbody.velocity.x * acceleration, 0, this.myRigidbody.velocity.z * acceleration);
        myRigidbody.AddForce(bound);

        //�ǂɓ���������L�[��
        if (other.gameObject.tag != "BossTag"�@&& other.gameObject.tag != "UnderWallTag")
        {
            audioSource.PlayOneShot(se1);
        }
        else if(other.gameObject.tag == "BossTag")
        {
            audioSource.PlayOneShot(se2);
        }
        else
        {   //���̕ǂɓ����������̉���p�ӂ��Ă���
            ballNumber -= 1;
            if(ballNumber < 0)
            {
                isGameOver = true;
            }

        }
        
        


        
    }

}
