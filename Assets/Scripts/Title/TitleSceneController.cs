using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public GameObject fade;//こいつに「FadeCanvas」のプレハブを入れる
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
        if (Input.anyKey)
        {
            sceneChange("Game");
        }
    }

    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("FadeTag");//Canvasをみつける
        fadeCanvas.GetComponent<FadeManager>().fadeIn();//フェードインフラグを立てる
    }

    public async void sceneChange(string sceneName)//ボタン操作などで呼び出す
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();//フェードアウトフラグを立てる
        await Task.Delay(200);//暗転するまで待つ
        SceneManager.LoadScene(sceneName);//シーンチェンジ
    }
}
