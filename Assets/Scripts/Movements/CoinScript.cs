using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    private float rotationSpeed = 100f;

    void Start()
    {
        if(Random.Range(0,9) != 1){
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        this.transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }
}
