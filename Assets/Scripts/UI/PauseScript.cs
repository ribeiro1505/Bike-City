using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    public GameObject pauseButton;
    public GameObject pauseMenu;

    public AudioSource freeWheelSound;
    public AudioSource pedalingSound;
    public AudioSource music;
    public AudioSource citySound;

    private bool paused = false;

    public void PauseGame (){
        Time.timeScale = 0;

        freeWheelSound.Pause();
        pedalingSound.Pause();
        music.Pause();
        citySound.Pause();
        
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        paused = true;
    }

    public void ResumeGame (){
        Time.timeScale = 1;

        music.Play();
        citySound.Play();

        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        paused = false;
    }

    public bool isPaused (){
        return (paused);
    }

}
