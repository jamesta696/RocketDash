using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    int currentSceneIndex;
    int lastSceneIndex;
    int nextSceneIndex;

    [SerializeField] float timeDelay = 2f;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip levelCompleteSFX;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem levelCompleteParticles;

    AudioSource audioSource;
    ParticleSystem particleSource;
    Movement movement_script;

    bool isTransitioning = false;

    void Start(){
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        nextSceneIndex = currentSceneIndex < lastSceneIndex ? currentSceneIndex + 1 : 0;

        audioSource = GetComponent<AudioSource>();
        movement_script = GetComponent<Movement>();
    }

    void OnCollisionEnter(Collision other) {
        if(isTransitioning){
            return;
        }
        
        switch(other.gameObject.tag){
            case "Friendly":
                Debug.Log("Collided with Friendly");
                break;
            case "Finish":
                OnFinishSequence();
                break;
            default:
                OnCrashSequence();
                break;
        }
    }

    void OnFinishSequence(){
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(levelCompleteSFX);
        levelCompleteParticles.Play();
        movement_script.enabled = false;
        Invoke("LoadNextLevel", timeDelay);
    }

    void OnCrashSequence(){
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashParticles.Play();
        movement_script.enabled = false;
        Invoke("ReloadScene", timeDelay);
    }

    void ReloadScene(){
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel(){
        SceneManager.LoadScene(nextSceneIndex);
    }
}