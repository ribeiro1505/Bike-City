using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{

    public bool isMusicOn = true;
    public bool isSoundOn = true;

    public Text HighScore;

    void Start(){
        HighScore.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore").ToString("0.00") + " Km";
    }

    public void ToGame(){
        SceneManager.LoadScene("Game");
    }

    public void ToCredits(){
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void OpenSettings(){
        SceneManager.LoadScene("Settings");
    }

    public void MusicClick(){
        isMusicOn = !isMusicOn;
    }

    public void SoundClick(){
        isSoundOn = !isSoundOn;
    }

}
