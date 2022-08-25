using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject shelterManager;
    //ボールの残機
    public int ballNumber;
    //ボールの初速
    private float speed = 1000f;
    //物に当たる度に上がる速度の倍率
    private float acceleration = 1.2f;
    //RigitBody取得
    private Rigidbody myRigidbody;
    //ゲーム始まってる？
    public bool gameRunning = false;
    //げーむおーばー
    public bool isGameOver = false;

    public AudioClip se1;
    public AudioClip se2;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //RigitBody取得
        this.myRigidbody = GetComponent<Rigidbody>();
        //AudioSource取得
        this.audioSource = GetComponent<AudioSource>();
        //シェルターマネージャーを取得
        shelterManager = GameObject.Find("ShelterManager");
        //ボールの残機をシェルターから拾う
        this.ballNumber = shelterManager.GetComponent<ShelterManager>().GetShelter("プレイヤー").GetBallNumber();

        //最初に右上にボールを打ち出す
        Vector3 force = new Vector3(speed, 0, speed); 
        myRigidbody.AddForce(force);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //当たる度に速度徐々に上がる
        Vector3 bound = new Vector3(this.myRigidbody.velocity.x * acceleration, 0, this.myRigidbody.velocity.z * acceleration);
        myRigidbody.AddForce(bound);

        //壁に当たったらキーン
        if (other.gameObject.tag != "BossTag"　&& other.gameObject.tag != "UnderWallTag")
        {
            audioSource.PlayOneShot(se1);
        }
        else if(other.gameObject.tag == "BossTag")
        {
            audioSource.PlayOneShot(se2);
        }
        else
        {   //下の壁に当たった時の音を用意しておく
            ballNumber -= 1;
            if(ballNumber < 0)
            {
                isGameOver = true;
            }

        }
        
        


        
    }

}
