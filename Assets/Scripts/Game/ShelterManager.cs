using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterManager : MonoBehaviour
{

    [SerializeField]
    private ShelterDataBase shelterDataBase;//  使用するデータベース

    private Dictionary<Shelter, int> numOfShelter = new Dictionary<Shelter, int>();//  ディクショナリーをShelterから作成し、numOfShelterにShelterの番号を振る

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < shelterDataBase.GetShelterLists().Count; i++)//  Shelterのリストの数の分だけ繰り返す処理
        {
            numOfShelter.Add(shelterDataBase.GetShelterLists()[i], i);//　避難場所の数を適当に設定


            //Debug.Log(shelterDataBase.GetShelterLists()[i].GetName() + ": " + shelterDataBase.GetShelterLists()[i].GetInformation());
            //　確認の為のデータ出力
        }
        /*
        Debug.Log(GetShelter("プレイヤー").GetInformation());
        Debug.Log(GetShelter("プレイヤー").GetHp());
        Debug.Log(GetShelter("プレイヤー").GetAttack());
        Debug.Log(GetShelter("プレイヤー").GetBarLength());
        Debug.Log(GetShelter("プレイヤー").GetBallAttack());
        Debug.Log(GetShelter("プレイヤー").GetBallNumber()); 
        */
    }

    public Shelter GetShelter(string searchName)//　名前で避難場所を取得
    {
        return shelterDataBase.GetShelterLists().Find(shelterName => shelterName.GetName() == searchName);//  アイテムの日本語名を渡し、避難場所データベースからその名前と一致するShelterクラスを返す

    }
}