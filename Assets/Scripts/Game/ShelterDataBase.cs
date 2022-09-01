using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShelterDataBase", menuName = "CreateShelterDataBase")]//  Create����CreateShelter�Ƃ������j���[��\�����AShelter���쐬����
public class ShelterDataBase : ScriptableObject
{

    [SerializeField]
    private List<Shelter> shelterLists = new List<Shelter>();//  Shelter�̃��X�g��V������������

    public List<Shelter> GetShelterLists()//  Shelter�̃��X�g����������A
    {
        return shelterLists;//  shelterLists�ɕԂ�
    }
}