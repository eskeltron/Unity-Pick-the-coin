using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioClip clickSound;
    public void ExitButton()
    {
        Application.Quit();
    }
    public void StartButton()
    {
        OwnSceneManager.GoToScene(OwnSceneManager.SCENES.GAME);
    }
    public void OptionsButton()
    {
        OwnSceneManager.GoToScene(OwnSceneManager.SCENES.OPTIONS);
    }

    public void ClickSound()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(clickSound);
    }
}
