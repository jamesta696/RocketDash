using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFalling : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float calculatedRange;
    [SerializeField] float movementSpeed = .08f;

    void Start(){
        startPosition = transform.position;
    }

    void Update(){
        Vector3 offset = movementVector * calculatedRange;
        transform.position = startPosition + offset;
        calculatedRange += Time.deltaTime * movementSpeed;
    }
}
