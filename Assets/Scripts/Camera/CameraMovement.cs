using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    //player Object
    private Transform player;

    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(5, 10, 0);

    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       startOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = player.position + startOffset;
        //X
        moveVector.x = moveVector.x / 1.5f;
        //Y varia entre o 3 e o 9
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 8);
        
        if(transition > 1.0f){
            transform.position = moveVector;
        } else{
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transform.LookAt(player.position + 3*Vector3.up);
            transition += Time.deltaTime / animationDuration;
        }

    }
}
