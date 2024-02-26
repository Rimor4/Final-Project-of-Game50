using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    public float Z_Max = 30.86f;
    public float Z_Min = -4.87f;
    public float X2_Max = 30.70f;
    public float X2_Min = 5.524f;

    void Start() {
        
    }

    void Update() {
        
    }

    public Vector3 player2MoveDirection(Vector3 position) {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.UpArrow) && position.z < Z_Max) {
            vertical = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow) && position.z > Z_Min) {
            vertical = -1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && position.x > X2_Min) {
            horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow) && position.x < X2_Max) {
            horizontal = 1f;
        }

        return new Vector3(horizontal, 0f, vertical).normalized;
    }
}
