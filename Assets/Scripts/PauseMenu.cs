using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool pauseNow;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        pauseNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && pauseNow == false)
        {
            Pause();
        }
        else if (Input.GetKeyDown("space") && pauseNow == true)
        {
            Resume();
        }
    }
    private void Pause()
    {
        Time.timeScale = 0;  // éûä‘í‚é~
        pausePanel.SetActive(true);
        pauseNow = true;
    }

    private void Resume()
    {
        Time.timeScale = 1;  // çƒäJ
        pausePanel.SetActive(false);
        pauseNow = false;
    }
}
