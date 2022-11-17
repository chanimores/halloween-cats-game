using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessCrate : MonoBehaviour
{

    [SerializeField] float speed = 100;
    [SerializeField] public GameObject ghostEffect;

    public bool possessed;

    private void Start() {
        possessed = false;
        ghostEffect.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (possessed) {
            
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
}
