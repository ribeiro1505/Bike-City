using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{

    public Text HighScore;
    public Text Coins;

    void Start(){
        HighScore.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore").ToString("0.00") + " Km";
        Coins.text = "Coins: " + PlayerPrefs.GetInt("Coins");
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

}
