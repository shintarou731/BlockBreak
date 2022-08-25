using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public GameObject shelterManager;
    //バーの移動速度
    public float barSpeed = 0.2f;

    //初期のバーの長さに置ける壁の内側の判定
    public float inFlame = 22f;

    //バーのサイズの変数宣言
    private Vector3 barScale = new Vector3(1, 2, 1);
    //バーの横幅
    public float barLength;

    // Start is called before the first frame update
    void Start()
    {
        //シェルターマネージャーを取得
        this.shelterManager = GameObject.Find("ShelterManager");
        //バーの横幅をシェルターから拾って代入
        this.barLength = this.shelterManager.GetComponent<ShelterManager>().GetShelter("プレイヤー").GetBarLength();
        barScale.x = barLength;
        transform.localScale = barScale;

    }

    // Update is called once per frame
    void Update()
    {
        //枠外には出ないようにバーを動かす
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
