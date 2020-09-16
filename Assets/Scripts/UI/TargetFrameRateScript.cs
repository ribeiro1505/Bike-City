using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRateScript : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 300;
    }
}
