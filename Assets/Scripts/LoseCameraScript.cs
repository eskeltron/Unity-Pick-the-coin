using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class LoseCameraScript : MonoBehaviour
{
    public AudioClip loseAudio;
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(loseAudio);
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
