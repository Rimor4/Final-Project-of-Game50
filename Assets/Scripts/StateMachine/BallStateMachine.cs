using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStateMachine : MonoBehaviour {
    public enum BallsState {
        Idle,
        Flying
    }

    public BallsState currentState;

    void Start() {
        currentState = BallsState.Idle;
    }

    public void setBallIdleState() {
        currentState = BallsState.Idle;
    }
    public void setBallFlyingState() {
        currentState = BallsState.Flying;
    }

}
