using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        gameObject.SetActive(false);

        InvokeRepeating("flashing", 1f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void flashing()
    {
        if (active == false)
        {
            gameObject.SetActive(true);
            active = true;
        }
        else
        {
            gameObject.SetActive(false);
            active = false;
        }
    }

}