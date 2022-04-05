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

    Movement movement_script;

    void Start(){
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        nextSceneIndex = currentSceneIndex < lastSceneIndex ? currentSceneIndex + 1 : 0;

        movement_script = GetComponent<Movement>();
    }

    void OnCollisionEnter(Collision other) {
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
        movement_script.enabled = false;
        Invoke("LoadNextLevel", timeDelay);
    }

    void OnCrashSequence(){
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