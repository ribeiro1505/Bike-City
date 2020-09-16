using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour{

    public Text retryText;
    public Text menuText;
    public Text scoreText;

    public MonetizationScript monetizationScript;

    void Start(){
        gameObject.SetActive(false);
    }

    void Update(){
    }

    public void ToggleEndMenu(float score){
        gameObject.SetActive(true);
        scoreText.text = (score).ToString("0.00") + "Km";

        Invoke("showAd",1);

    }

    public void showAd(){
        monetizationScript.showAd();
    }

    public void Restart(){
        SceneManager.LoadScene("Game");
    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }
}
