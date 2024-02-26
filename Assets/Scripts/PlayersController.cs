using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour {
    public float playerMoveSpeed = 0.07f;
    public Player1 Player1;
    public Player2 Player2;

    private Transform parentTransform;

    void Start() {
        parentTransform = gameObject.transform;
    }

    void Update() {
        // update every player's movement
        MovePlayers();
    }

    void MovePlayers() {
        Vector3 moveVector = Vector3.zero;
        foreach (Transform childTransform in parentTransform) {
            if (childTransform.name == "Player 1") {
                Vector3 position1 = Player1.gameObject.transform.position;
                moveVector = playerMoveSpeed * Player1.player1MoveDirection(position1);
            }
            else if(childTransform.name == "Player 2") {
                Vector3 position2 = Player2.gameObject.transform.position;
                moveVector = playerMoveSpeed * Player2.player2MoveDirection(position2);
            }

            childTransform.Translate(moveVector);
        }
    }

    
}