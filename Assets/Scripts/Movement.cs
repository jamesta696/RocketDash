using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour {
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] AudioClip rocketBoostSFX;

    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem leftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;

    [SerializeField] float rocketBoost = 1000f;
    [SerializeField] float rotateSpeed = 135f;

    void Start(){
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    void Update(){
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            StartMainBoosterEfx(); 
        }else{
            StopMainBoosterEfx();
        }
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A)){
            ApplyLeftBoosterPhysics();
            
        }else if(Input.GetKey(KeyCode.D)){
            ApplyRightBoosterPhysics();
        }else{
            StopSideThrustersParticles();
        }
    }

    void StopSideThrustersParticles(){
        leftBoosterParticles.Stop();
        rightBoosterParticles.Stop();
    }

    void ApplyRightBoosterPhysics(){
        RotateSpeedCalcs(rotateSpeed);
        PlayBoosterParticles(rightBoosterParticles);
    }

    void ApplyLeftBoosterPhysics(){
        RotateSpeedCalcs(-rotateSpeed);
        PlayBoosterParticles(leftBoosterParticles);
    }

    void StopMainBoosterEfx(){
        audioSource.Stop();
        mainBoosterParticles.Stop();
    }

    void StartMainBoosterEfx(){
        rb.AddRelativeForce(Vector3.up * rocketBoost * Time.deltaTime);
        if(!audioSource.isPlaying && !mainBoosterParticles.isPlaying){
            audioSource.PlayOneShot(rocketBoostSFX);
            mainBoosterParticles.Play();
        }
    }

    void PlayBoosterParticles(ParticleSystem boosterParticle){
        if(!boosterParticle.isPlaying)
            boosterParticle.Play();
    }

    void RotateSpeedCalcs(float rotateThisFrame){ // reference parameter for rotateSpeed
        rb.freezeRotation = true; // freeze rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system cam take over
    }
}