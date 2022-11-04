using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] float speed = 8;
    private float movementX;
    private float movementY;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey("left")) {
            dir.x = -1;
        } else if (Input.GetKey("right")) {
            dir.x = 1;
        }

        if (Input.GetKey("up")) {
            dir.y = 1;
        } else if (Input.GetKey("down")) {
            dir.y = -1;
        }

        dir.Normalize();
        
        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}
