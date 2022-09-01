using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public GameObject fade;
    public GameObject fadeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (!FadeManager.isFadeInstance)
        {
            Instantiate(fade);
        }
        Invoke("findFadeObject", 0.02f);
    }

    private void Update()
    {
 
    }

    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("FadeTag");//Canvas���݂���
        fadeCanvas.GetComponent<FadeManager>().fadeIn();//�t�F�[�h�C���t���O�𗧂Ă�
    }

    public async void sceneChange(string sceneName)//�{�^������ȂǂŌĂяo��
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();//�t�F�[�h�A�E�g�t���O�𗧂Ă�
        await Task.Delay(200);//�Ó]����܂ő҂�
        SceneManager.LoadScene(sceneName);//�V�[���`�F���W
    }
}
