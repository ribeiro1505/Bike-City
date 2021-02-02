using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour{

private float score = 0.0f;
private float speed = 0.0f;
private int coins = 0;

public Text scoreText;
public Text speedText;
public Text coinText;
public RawImage scoreImage;
public RawImage SpeedImage;
public RawImage CoinImage;

public AudioSource coinSound;
public AudioSource diamongSound;

public DeathMenu deathMenu;

private bool isDead;

GameObject player;
PlayerMovement playerMovement;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        scoreText.enabled = true;
        speedText.enabled = true;
        coinText.enabled = true;
        scoreImage.enabled = true;
        SpeedImage.enabled = true;
        CoinImage.enabled = true;

        coins = PlayerPrefs.GetInt("Coins");
        coinText.text = coins.ToString();
    }

    public void addCoin(){
        coinSound.Play();
        coins++;
        coinText.text = (coins).ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void addSpecialCoin(){
        diamongSound.Play();
        coins+=10;
        coinText.text = (coins).ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }

    void Update(){
        if(isDead)
            return;
        
        score = player.transform.position.z / 2000;
        speed = playerMovement.GetFrontSpeed() / 50;

        scoreText.text = score.ToString("0.00") + " Km";
        speedText.text = speed.ToString("0.0") + " Km/h";
    }

    public void OnDeath(){
        scoreText.enabled = false;
        speedText.enabled = false;
        coinText.enabled = false;
        scoreImage.enabled = false;
        SpeedImage.enabled = false;
        CoinImage.enabled = false;

        if(score > PlayerPrefs.GetFloat("HighScore"))
            PlayerPrefs.SetFloat("HighScore", score);

        isDead = true;
        deathMenu.ToggleEndMenu(score);
    }
}
