using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    GameObject resourceCanvas;
    private void Start()
    {
        resourceCanvas = GameObject.Find("MainCanvas");
    }

    private void Update()
    {
        CheckResourceInput();
    }

    public void CheckResourceInput()
    {//checks if player pressed P and enabled/disables the canvas accordingly

            if(Input.GetKeyDown(KeyCode.P))
            {
                if(resourceCanvas.activeInHierarchy)
                {
                    resourceCanvas.SetActive(false);
                }
                 else
                {
                    resourceCanvas.SetActive(true);
                }
        }
    }
}
