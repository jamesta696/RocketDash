using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float xVal = 0f;
    [SerializeField] float yVal = 6f;
    [SerializeField] float zVal = 0f;

    GameObject[] RotatingObstacles;
    Vector3 spinningRotation;

    void Start(){
        GetAllTags();
    }

    void Update(){
        PerformRotation();
    }    

    void GetAllTags(){
        RotatingObstacles = GameObject.FindGameObjectsWithTag("RotatingObstacles");
        // Radar = GameObject.FindGameObjectsWithTag("EnemyRadar");
        // combinedArray = RotatingObstacles.Concat(Radar).ToArray();
    }

    void PerformRotation(){
        spinningRotation = new Vector3(xVal, yVal, zVal);
        foreach(GameObject obj in RotatingObstacles){
            obj.transform.Rotate(spinningRotation);
        }
    }
}