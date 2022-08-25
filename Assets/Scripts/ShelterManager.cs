using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterManager : MonoBehaviour
{

    [SerializeField]
    private ShelterDataBase shelterDataBase;//  �g�p����f�[�^�x�[�X

    private Dictionary<Shelter, int> numOfShelter = new Dictionary<Shelter, int>();//  �f�B�N�V���i���[��Shelter����쐬���AnumOfShelter��Shelter�̔ԍ���U��

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < shelterDataBase.GetShelterLists().Count; i++)//  Shelter�̃��X�g�̐��̕������J��Ԃ�����
        {
            numOfShelter.Add(shelterDataBase.GetShelterLists()[i], i);//�@���ꏊ�̐���K���ɐݒ�


            //Debug.Log(shelterDataBase.GetShelterLists()[i].GetName() + ": " + shelterDataBase.GetShelterLists()[i].GetInformation());
            //�@�m�F�ׂ̈̃f�[�^�o��
        }
        /*
        Debug.Log(GetShelter("�v���C���[").GetInformation());
        Debug.Log(GetShelter("�v���C���[").GetHp());
        Debug.Log(GetShelter("�v���C���[").GetAttack());
        Debug.Log(GetShelter("�v���C���[").GetBarLength());
        Debug.Log(GetShelter("�v���C���[").GetBallAttack());
        Debug.Log(GetShelter("�v���C���[").GetBallNumber()); 
        */
    }

    public Shelter GetShelter(string searchName)//�@���O�Ŕ��ꏊ���擾
    {
        return shelterDataBase.GetShelterLists().Find(shelterName => shelterName.GetName() == searchName);//  �A�C�e���̓��{�ꖼ��n���A���ꏊ�f�[�^�x�[�X���炻�̖��O�ƈ�v����Shelter�N���X��Ԃ�

    }
}