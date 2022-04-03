using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    int currentSceneIndex;
    int lastSceneIndex;
    int nextSceneIndex;

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
                LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("You got more Fuel!");
                break;
            default:
                Debug.Log("You Crashed!");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence(){
        movement_script.enabled = false;
        Invoke("ReloadScene", 2f);
    }

    void ReloadScene(){
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel(){
        SceneManager.LoadScene(nextSceneIndex);
    }
}