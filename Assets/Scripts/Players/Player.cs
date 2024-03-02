using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    public static float playerMoveSpeed = 0.07f;
    public PlayerStateMachine playerStateMachine;

    // get players' PlayerState
    public PlayerStateMachine.PlayerState GetPlayerState() {
        return playerStateMachine.currentState;
    }

    // define a method to check if players' move key is down;
    public virtual bool isPlayerMove() {
        return false;
    }

    // get players' move direction
    public virtual Vector3 PlayerMoveDirection(Vector3 position) {
        return Vector3.zero;
    }
}