using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectIfNear : MonoBehaviour
{
    GameObject Player;
    GameObject EnemyRadar;

    Oscillation OscillationScript;
    Vector3 startingPosition;
    void Start()
    {
        OscillationScript = GetComponent<Oscillation>();
        OscillationScript.enabled = false;

        EnemyRadar = GameObject.FindGameObjectWithTag("EnemyRadar");
        Player = GameObject.FindGameObjectWithTag("Player");
        startingPosition = transform.position;
    }

    void Update(){
        CheckIfPlayerIsNearEnemyRadar();
    }

    void CheckIfPlayerIsNearEnemyRadar(){
        if((EnemyRadar.transform.position - Player.transform.position).sqrMagnitude < 150.0f){
            EnableOscillationScript();
        }else{
            EnemyRadar.transform.position = startingPosition;
            DisableOsciallationScript();
        }
    }

    void EnableOscillationScript(){
        OscillationScript.enabled = true;
    }

    void DisableOsciallationScript(){
        OscillationScript.enabled = false;
    }
}
