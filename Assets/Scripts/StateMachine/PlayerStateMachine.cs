using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour {
    public enum PlayerState {
        Idle,
        Walking,
        Swinging
    }

    public PlayerState currentState;

    void Start() {
        // initial state is Idle 
        currentState = PlayerState.Idle;        
    }

    public void setPlayerIdleState() {
        currentState = PlayerState.Idle;
    }
    public void setPlayerWalkingState() {
        currentState = PlayerState.Walking;
    }
    public void setPlayerSwingingState() {
        currentState = PlayerState.Swinging;
    }
}
