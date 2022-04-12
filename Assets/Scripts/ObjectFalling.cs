using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFalling : MonoBehaviour
{
    Vector3 startPosition;

    [SerializeField] float xVal = 0f;
    [SerializeField] float yVal = 6f;
    [SerializeField] float zVal = 0f;

    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float calculatedRange;
    [SerializeField] float movementSpeed = .08f;

    [SerializeField] AudioClip objectFall_sfx;
    [SerializeField] ParticleSystem objectCrash_efx;

    AudioSource audioSource;
    ParticleSystem particleSource;

    GameObject fallingAsteroids;

    bool isTransitioning = false;

    void Start(){
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        fallingAsteroids = GameObject.FindGameObjectWithTag("FallingAsteroid");
    }

    void Update(){
        ObjectSpin();

        Vector3 offset = movementVector * calculatedRange;
        transform.position = startPosition + offset;
        calculatedRange += Time.deltaTime * movementSpeed;
    }

    void OnCollisionEnter(Collision other) {
        if(isTransitioning){
            return;
        }
        SetFlagSequencer();
        InitEffects(objectFall_sfx, objectCrash_efx);
        DestroyCurrentObj();
    }

    void SetFlagSequencer(){
        isTransitioning = true;
    }

    void InitEffects(AudioClip sfx, ParticleSystem efx){
        audioSource.Stop();
        audioSource.PlayOneShot(sfx);
        efx.Play();
    }

    void DestroyCurrentObj(){
        if(this.gameObject != null){
            Destroy(this.gameObject,3f);
        }
    }

    void ObjectSpin(){
        Vector3 spinningRotation = new Vector3(xVal, yVal, zVal);
        fallingAsteroids.GetComponent<Transform>().Rotate(spinningRotation);
    }
}
