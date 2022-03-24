using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float rocketBoost = 1000f;
    [SerializeField] float rotateSpeed = 135f;

    void Start(){
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        ProcessThrust();
        ProcessRotation();
    }

    // void FixedUpdate() {
    //     ProcessThrust();
    //     ProcessRotation();
    // }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * rocketBoost * Time.deltaTime);

            if(!audioSource.isPlaying)
                audioSource.Play();

        }else{
            audioSource.Stop();
        }
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A)){
            RotateSpeedCalcs(-rotateSpeed);
        }else if(Input.GetKey(KeyCode.D)){
            RotateSpeedCalcs(rotateSpeed);
        }
    }

    void RotateSpeedCalcs(float rotateThisFrame){ // reference parameter for rotateSpeed
        rb.freezeRotation = true; // freeze rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system cam take over
    }
}