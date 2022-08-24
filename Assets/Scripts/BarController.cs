using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    //バーの移動速度
    public float barSpeed = 0.2f;

    //初期のバーの長さに置ける壁の内側の判定
    public float inFlame = 22f;


    // Start is called before the first frame update
    void Start()
    {
        
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
