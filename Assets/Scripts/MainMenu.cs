using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private float defaultVolume = 1.0f;
    
    private string levelToLoad = "LevelSelect";
    private string returnToMenu = "MainMenu";
    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ReturnToMenu()
    {
        sceneFader.FadeTo(returnToMenu);
    }
}
