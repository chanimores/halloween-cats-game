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
    private SpriteRenderer sr;

    private bool inPossessionRange;
    private bool possessing;
    private GameObject crate;

    float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        inPossessionRange = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("PossessCrate")) {
            inPossessionRange = true;
            crate = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag.Equals("PossessCrate")) {
            inPossessionRange = false;
            
        }
    }

    void FixedUpdate() {

        if (Input.GetKey("right ctrl") && inPossessionRange) {
            crate.GetComponent<PossessCrate>().possessed = true;
            crate.GetComponent<PossessCrate>().ghostEffect.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("POSSESSED");
            possessing = true;
            sr.enabled = false;

            cooldown = 1f;
        }

        if (!possessing) {

            Vector2 dir = Vector2.zero;

            if (Input.GetKey("left")) {
                dir.x = -1;
                sr.flipX = false;
            } else if (Input.GetKey("right")) {
                dir.x = 1;
                sr.flipX = true;
            }

            if (Input.GetKey("up")) {
                dir.y = 1;
            } else if (Input.GetKey("down")) {
                dir.y = -1;
            }

            dir.Normalize();
            
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        } else {
            cooldown -= Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            if (cooldown <= 0 && Input.GetKey("right ctrl")) {
                crate.GetComponent<PossessCrate>().possessed = false;
                crate.GetComponent<PossessCrate>().ghostEffect.GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("UNPOSSESSED");
                possessing = false;
                sr.enabled = true;
            }
        }

        
    }
}
