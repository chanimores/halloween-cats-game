using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] float speed = 8;
    private float movementX;
    private float movementY;

    private bool inPickUpRange;
    private bool pickedUp;
    private GameObject lanternObj;
    Vector3 offset;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A)) {
            dir.x = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            dir.x = 1;
        }

        if (Input.GetKey(KeyCode.W)) {
            dir.y = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            dir.y = -1;
        }

        dir.Normalize();
        
        GetComponent<Rigidbody2D>().velocity = speed * dir;

        if (Input.GetKey(KeyCode.E) && inPickUpRange) {
            // Debug.Log("yeup");
            pickedUp = true;
            offset = lanternObj.transform.position - transform.position;
            Debug.Log("succesfully picked up");
        } 

        if (pickedUp) {
            lanternObj.transform.position = transform.position ;
            Debug.Log("move");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.tag).Equals("PickUp")) {
            inPickUpRange = true;
            lanternObj = other.gameObject;
            Debug.Log("in pickup range");
        }
    }

    

    private void OnTriggerExit2D(Collider2D other) {
        inPickUpRange = false;
        Debug.Log("outside pickup range");
    }
}
