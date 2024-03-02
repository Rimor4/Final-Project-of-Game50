using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBall : MonoBehaviour {
    public BallStateMachine ballsStateMachine;

    public Rigidbody rb;
    public float portalBallSpeed = 5f;

    // 记录上一个输球者
    public Player lastLoser;

    void Start() {
        rb = GetComponent<Rigidbody>();        
        lastLoser = null;
    }

    void Update() {
        switch (ballsStateMachine.currentState) {
            case BallStateMachine.BallsState.Idle:
                if (Input.GetButtonDown("Jump")) {
                    // 发射传送球
                    // TODO: 球发向上一个输球者
                    Vector3 launchDirection = new Vector3(
                        lastLoser == null ? Random.Range(-1f, 1f) : lastLoser.transform.position.x,
                        0,
                        Random.Range(-0.5f, 0.5f)
                    ).normalized;

                    rb.velocity = launchDirection * portalBallSpeed;
                    // 切换到飞行状态
                    ballsStateMachine.setBallFlyingState();
                }
                break;
            case BallStateMachine.BallsState.Flying:
                break;
        }
    }
}
