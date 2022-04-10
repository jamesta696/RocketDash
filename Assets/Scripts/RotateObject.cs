using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float xVal = 0f;
    [SerializeField] float yVal = 6f;
    [SerializeField] float zVal = 0f;

    public GameObject[] floatingAsteroids;

    void Start(){
        floatingAsteroids = GameObject.FindGameObjectsWithTag("SpinningAsteroids");    
    }

    void Update(){
        Vector3 spinningRotation = new Vector3(xVal, yVal, zVal);
        
        foreach(GameObject asteroid in floatingAsteroids){
            asteroid.GetComponent<Transform>().Rotate(spinningRotation);
        }
    }
}