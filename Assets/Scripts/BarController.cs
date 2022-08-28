using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public GameObject shelterManager;
    public GameObject boss;
    private float attack_1;
    //バーの移動速度
    public float barSpeed = 100;
    //バーのサイズの変数宣言
    private Vector3 barScale = new Vector3(1, 2, 1);
    //バーの横幅宣言
    public float barLength;
    //バーの横幅の最小値
    private float minBarLength = 5;
    //壁に当たってる？
    private bool leftWallCollision = false;
    private bool rightWallCollision = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //シェルターマネージャーを取得
        this.shelterManager = GameObject.Find("ShelterManager");
        //バーの横幅をシェルターから拾って代入
        this.barLength = this.shelterManager.GetComponent<ShelterManager>().GetShelter("プレイヤー").GetBarLength();
        barScale.x = barLength;
        transform.localScale = barScale;

        //ボスの攻撃力を拾って代入
        attack_1 = boss.GetComponent<BossController>().attack;
    }

    // Update is called once per frame
    void Update()
    {
        //枠外には出ないようにバーを動かす
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

    //ダメージ食らった時の処理
    private void Damage(float damage)
    {
        barScale.x -= damage;
        if (barScale.x < minBarLength)
            barScale.x = minBarLength;

        transform.localScale = barScale;
    }
}
