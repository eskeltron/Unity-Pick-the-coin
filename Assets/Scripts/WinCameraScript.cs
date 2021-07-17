using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class WinCameraScript : MonoBehaviour
{
    public AudioClip wonAudio;
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(wonAudio);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OwnSceneManager.GoToScene(OwnSceneManager.SCENES.GAME);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
