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
    [SerializeField] float movementSpeed = .08f;
                     float calculatedRange;

    [SerializeField] AudioClip objectFall_sfx;
    [SerializeField] ParticleSystem objectCrash_efx;

    AudioSource audioSource;
    ParticleSystem particleSource;

    GameObject[] fallingAsteroids;

    bool isTransitioning = false;

    void Start(){
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        fallingAsteroids = GameObject.FindGameObjectsWithTag("FallingAsteroid");
    }

    void Update(){
        ObjectSpin();
        CalculateObjectTrajectory();
    }

    void CalculateObjectTrajectory(){
        Vector3 offset = movementVector * calculatedRange;
        transform.position = startPosition + offset;
        calculatedRange += Time.deltaTime * movementSpeed;
    }

    void OnCollisionEnter(Collision collision) {
        if(isTransitioning){
            return;
        }
        SetFlagSequencer();
        InitEffects(objectFall_sfx, objectCrash_efx);
        Invoke("DestroyCurrentObj", 1.5f);
    }

    void DestroyCurrentObj(){
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    void SetFlagSequencer(){
        isTransitioning = true;
    }

    void InitEffects(AudioClip sfx, ParticleSystem efx){
        audioSource.Stop();
        audioSource.PlayOneShot(sfx);
        efx.Play();
    }

    void ObjectSpin(){
        Vector3 spinningRotation = new Vector3(xVal, yVal, zVal);

        foreach(GameObject asteroid in fallingAsteroids){
            asteroid.GetComponent<Transform>().Rotate(spinningRotation);
        }
    }
}