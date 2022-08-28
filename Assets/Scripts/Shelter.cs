using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shelter", menuName = "CreateShelter")]//  Create����CreateShelter�Ƃ������j���[��\�����AShelter���쐬����
public class Shelter : ScriptableObject
{
    [SerializeField]
    private Sprite icon;//�@���ꏊ�̃A�C�R��

    [SerializeField]
    private string Name;//�@���ꏊ�̖��O

    [SerializeField]
    private string information;//�@���ꏊ�̏��

    [SerializeField]
    private int hp;// �{�X��HP

    [SerializeField]
    private float attack;//�{�X�̍U����

    public float barLength;//�v���C���[�̃o�[�̒���

    public int ballAttack;//�v���C���[�̍U����

    public int ballNumber;// �v���C���[�̎c�@��

    public Sprite GetIcon()//  �A�C�R������͂�����A
    {
        return icon;//  icon�ɕԂ�
    }

    public string GetName()//  ���ꏊ�̖��O����͂�����A
    {
        return Name;//  Name�ɕԂ�
    }

    public string GetInformation()//  ������͂�����A
    {
        return information;//  information�ɕԂ�
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
