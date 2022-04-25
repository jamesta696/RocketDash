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

    void Start(){
        GetAllTags();
    }

    void GetAllTags(){
        RotatingObstacles = GameObject.FindGameObjectsWithTag("RotatingObstacles");
    }

    void Update(){
        Vector3 spinningRotation = new Vector3(xVal, yVal, zVal);
        
        foreach(GameObject obstacle in RotatingObstacles){
            obstacle.GetComponent<Transform>().Rotate(spinningRotation);
        }
    }
}