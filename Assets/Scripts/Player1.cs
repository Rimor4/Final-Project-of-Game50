using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    public float Z_Max = 30.865f;
    public float Z_Min = -4.87f;
    public float X1_Max = -5.524f;
    public float X1_Min = -30.70f;
    void Start() {
        
    }

    void Update() {
        
    }

    public Vector3 player1MoveDirection(Vector3 position) {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W) && position.z < Z_Max) {
            vertical = 1f;
        }
        if (Input.GetKey(KeyCode.S) && position.z > Z_Min) {
            vertical = -1f;
        }
        if (Input.GetKey(KeyCode.A) && position.x > X1_Min) {
            horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D) && position.x < X1_Max) {
            horizontal = 1f;
        }

        return new Vector3(horizontal, 0f, vertical).normalized;
    }
}
