using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //�{�[���̏���
    private float speed = 1000f;
    //���ɓ�����x�ɏオ�鑬�x�̔{��
    private float acceleration = 1.2f;
    //RigitBody�擾
    private Rigidbody myRigidbody;

    public AudioClip se1;
    public AudioClip se2;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //RigitBody�擾
        this.myRigidbody = GetComponent<Rigidbody>();
        //AudioSource�擾
        audioSource = GetComponent<AudioSource>();

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
        if (other.gameObject.tag != "BossTag")
        {
            audioSource.PlayOneShot(se1);
        }
        else
        {
            audioSource.PlayOneShot(se2);
        }

        
    }

}
