using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour{
    private CharacterController controller;

    private Vector3 moveVector;

    Rigidbody rb;

    public PauseScript pauseScript;
    public ScoreScript scoreScript;

    public Transform frontWheel;
    public Transform backWheel;
    public Transform cassete;
    public GameObject pauseButton;

    public AudioSource freeWheelSound;
    public AudioSource pedalingSound;
    public AudioSource crashSound;
    public AudioSource music;
    public AudioSource citySound;

    private float animationDuration = 3.0f;
    private float startTime;

    private float speed = 5.0f;
    private float maxSpeed = 1250.0f;

    private float tiltAngleY = 10.0f;
    private float tiltAngleZ = 20.0f;
    private float tiltY;
    private float tiltZ;
    private Quaternion target;

    private float frontSpeed = 0.0f;

    private bool isDead = false;

    private float rotationSpeed = 50.0f;

    void Start(){
        pedalingSound.Play();
        pedalingSound.Pause();
        freeWheelSound.Play();
        freeWheelSound.Pause();

        music.Play();
        citySound.Play();

        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
    }

    void Update(){

        if(isDead || pauseScript.isPaused())
            return;

        if(Time.time - startTime < animationDuration)
            return;
        
        //X
        if(frontSpeed > 0){
            float pcXinput = Input.GetAxisRaw("Horizontal");
            float androidXinput = Input.acceleration.x;

            //PC controls
            if(pcXinput != 0){
                tiltY = pcXinput * tiltAngleY;
                tiltZ = pcXinput * tiltAngleZ;

                moveVector.x = pcXinput * frontSpeed / 5;
                target = Quaternion.Euler(0, 180 + tiltY, tiltZ);
            }
            //ANDROID controls 
            else if(androidXinput != 0){
                tiltY = androidXinput * tiltAngleY * 3;
                tiltZ = androidXinput * tiltAngleZ * 3;

                moveVector.x = androidXinput * frontSpeed / 1.5f;
                target = Quaternion.Euler(0, 180 + tiltY, tiltZ);
            } else{
                moveVector.x = 0;
                target = Quaternion.Euler(0, 180, 0);
            }

            rb.rotation = Quaternion.Slerp(rb.rotation, target,  Time.deltaTime * frontSpeed / 50);

        }

        //Z
        if(frontSpeed >= 0 && frontSpeed <= maxSpeed){
            
            //PC controls
            float pcZinput = Input.GetAxisRaw("Vertical");
            if(pcZinput != 0){
                //acelerar
                if(pcZinput > 0){
                    frontSpeed += pcZinput;
                    rotatePedals();
                }
                //desacelerar e travar
                else  {
                    frontSpeed += pcZinput * 5;
                    if(frontSpeed > 0){
                        notRotatePedals();
                    }
                }
            } 
            //ANDROID controls
            else if(Input.GetMouseButton(0)){
                float androidZinput = Input.mousePosition.x;
                //acelerar
                if(androidZinput > Screen.width/2){
                    frontSpeed += 1;
                    rotatePedals();
                }
                //desacelerar e travar
                else if (androidZinput < Screen.width/2){
                    frontSpeed -= 10;
                    if(frontSpeed > 0){
                        notRotatePedals();
                    }
                }
            }
            else{
                frontSpeed += pcZinput * 5;
                if(frontSpeed > 0){
                    notRotatePedals();
                }
            }
        }

        if(frontSpeed > 0)
            frontSpeed -= frontSpeed/2000;
        if(frontSpeed < 0){
            frontSpeed = 0;
            freeWheelSound.Pause();
            pedalingSound.Pause();
        }
        if(frontSpeed > maxSpeed)
            frontSpeed = maxSpeed;

        rotateWheels();

        moveVector.z = frontSpeed;

        rb.velocity = moveVector * speed * Time.deltaTime;
    }

    private void rotateWheels(){
        Vector3 targetwheels = new Vector3(0.0f, 0.0f, frontSpeed * rotationSpeed);
        
        frontWheel.Rotate(targetwheels * Time.deltaTime);
        backWheel.Rotate(targetwheels * Time.deltaTime);
    }

    private void rotatePedals(){
        freeWheelSound.Pause();
        pedalingSound.UnPause();

        Vector3 targetwheels = new Vector3(0.0f, 0.0f, frontSpeed * rotationSpeed / 50);

        cassete.Rotate(targetwheels * Time.deltaTime);
    }

    private void notRotatePedals(){
        freeWheelSound.UnPause();
        pedalingSound.Pause();
    }

    public float GetFrontSpeed(){
        return frontSpeed * 2;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Crash"){
            Death();
        } else if (collision.gameObject.tag == "Coin"){
            Destroy(collision.gameObject);
            scoreScript.addCoin();
        } else if (collision.gameObject.tag == "SpecialCoin"){
            Destroy(collision.gameObject);
            scoreScript.addSpecialCoin();
        }
    }

    private void Death(){
        pedalingSound.Pause();
        freeWheelSound.Pause();
        crashSound.Play();

        music.Pause();
        citySound.Pause();

        isDead = true;
        frontSpeed = 0;
        pauseButton.SetActive(false);
        scoreScript.OnDeath();
    }

}
