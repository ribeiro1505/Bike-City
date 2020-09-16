using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Text retryText;
    public Text menuText;

    void Start(){
        gameObject.SetActive(false);
    }

    void Update(){}

    public void TogglePauseMenu(){
        gameObject.SetActive(true);
    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }

}
