using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectIfNear : MonoBehaviour
{
    GameObject Player;
    GameObject EnemyRadar;

    Vector3 startingPosition;

    [SerializeField] Transform start;
    [SerializeField] Transform end;

    void Start()
    {
        EnemyRadar = GameObject.FindGameObjectWithTag("EnemyRadar");
        Player = GameObject.FindGameObjectWithTag("Player");
        startingPosition = transform.position;
    }

    void Update(){
        CheckIfPlayerIsNearEnemyRadar();
    }

    // Draws a line between the start and end points
    void onDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(start.position, end.position);
    }

    void CheckIfPlayerIsNearEnemyRadar(){
        if((EnemyRadar.transform.position - Player.transform.position).sqrMagnitude < 150.0f){
           GoToTargetPosition();
        }else{
            BackToStartingPosition();
        }
    }

    void GoToTargetPosition(){
        transform.position = Vector3.Lerp(transform.position, end.position, Time.deltaTime * 2);
    }

    void BackToStartingPosition(){
        transform.position = Vector3.Lerp(EnemyRadar.transform.position, startingPosition, Time.deltaTime * 2);
    }
}
