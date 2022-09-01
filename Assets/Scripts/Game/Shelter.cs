using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shelter", menuName = "CreateShelter")]//  CreateからCreateShelterというメニューを表示し、Shelterを作成する
public class Shelter : ScriptableObject
{
    [SerializeField]
    private Sprite icon;//　避難場所のアイコン

    [SerializeField]
    private string Name;//　避難場所の名前

    [SerializeField]
    private string information;//　避難場所の情報

    [SerializeField]
    private int hp;// ボスのHP

    [SerializeField]
    private float attack;//ボスの攻撃力

    public float barLength;//プレイヤーのバーの長さ

    public int ballAttack;//プレイヤーの攻撃力

    public int ballNumber;// プレイヤーの残機数

    public Sprite GetIcon()//  アイコンを入力したら、
    {
        return icon;//  iconに返す
    }

    public string GetName()//  避難場所の名前を入力したら、
    {
        return Name;//  Nameに返す
    }

    public string GetInformation()//  情報を入力したら、
    {
        return information;//  informationに返す
    }

    public int GetHp()
    {
        return hp;
    }

    public float GetAttack()
    {
        return attack;
    }
    public float GetBarLength()
    {
        return barLength;
    }

    public int GetBallAttack()
    {
        return ballAttack;
    }

    public int GetBallNumber()
    {
        return ballNumber;
    }
}
