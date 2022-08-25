using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShelterDataBase", menuName = "CreateShelterDataBase")]//  CreateからCreateShelterというメニューを表示し、Shelterを作成する
public class ShelterDataBase : ScriptableObject
{

    [SerializeField]
    private List<Shelter> shelterLists = new List<Shelter>();//  Shelterのリストを新しく生成する

    public List<Shelter> GetShelterLists()//  Shelterのリストがあったら、
    {
        return shelterLists;//  shelterListsに返す
    }
}