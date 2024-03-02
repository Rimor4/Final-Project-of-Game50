using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour {
    public Player1 player1;
    public Player2 player2;
    public Player[] players = new Player[2];

    void Start() {
        players[0] = player1;
        players[1] = player2; 
    }

    void Update() {

        for (int i = 0; i <= 1; i++) {    
            switch (players[i].GetPlayerState()) {

                case PlayerStateMachine.PlayerState.Idle:
                    if (players[i].isPlayerMove()) {
                        // 切换到行走状态
                        players[i].playerStateMachine.setPlayerWalkingState();
                    }
                    break;

                case PlayerStateMachine.PlayerState.Walking:
                    if (players[i].isPlayerMove()) {
                        // 移动角色
                        MovePlayer(players[i]);
                    }
                    else {
                        // 切换到静止状态
                        players[i].playerStateMachine.setPlayerIdleState();
                    }
                    break;

                case PlayerStateMachine.PlayerState.Swinging:
                    // TODO:Haddle the logic of Swinging state
                    break;
            }
        }
    }

    // 移动角色
    void MovePlayer(Player player) {
        Vector3 moveVector;
            Vector3 position = player.gameObject.transform.position;

            moveVector = Player.playerMoveSpeed * player.PlayerMoveDirection(position);

            player.gameObject.transform.Translate(moveVector);
    }

    
}