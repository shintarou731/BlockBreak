using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static bool isFadeInstance = false;

    public bool isFadeIn = false;
    public bool isFadeOut = false;

    public float alpha = 0.0f;//���ߗ�
    public float fadeSpeed = 0.2f; //�t�F�[�h�ɂ����鎞��


    // Start is called before the first frame update
    void Start()
    {
        if (!isFadeInstance)
        {
            DontDestroyOnLoad(this);
            isFadeInstance = true;
        }
        else
        {
            Destroy(this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeIn)
        {
            alpha -= Time.deltaTime / fadeSpeed;
            if(alpha <= 0.0f)//�����ɂȂ�����t�F�[�h�C���I��
            {
                isFadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if(isFadeOut)
        {
            alpha += Time.deltaTime / fadeSpeed;
            if(alpha >= 1.0f)//�^�����Ńt�F�[�h�A�E�g���I��
            {
                isFadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    public void fadeIn()
    {
        isFadeIn = true;
        isFadeOut = false;
    }

    public void fadeOut()
    {
        isFadeOut = true;
        isFadeIn = false;
    }
}
