using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour {
    public BallStateMachine ballsStateMachine;
    void Start() {
        
    }

    void Update() {
        
    }

    // if collides with walls or rackets, then bounces off
    void OnTriggerEnter(Collider other) {
        string colliderName = other.transform.parent.gameObject.name;
        if (colliderName == "Statium") {
            
        } 

        // TODO:
        else if (colliderName == "Racket") {

        }
    }
}
