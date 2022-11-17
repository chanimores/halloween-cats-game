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
    private bool possessing;
    private GameObject crate;

    float cooldown;

    public LayerMask pickUpMask;
    public Vector3 Direction { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        crate = new GameObject();
        possessing = false;
    }
    void FixedUpdate() {

        if (Input.GetKey("right ctrl")) {

            if (cooldown <= 0) {

                if (!possessing) {
                    Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, 1f, pickUpMask);
                    if (pickUpItem){
                        crate = pickUpItem.gameObject;
                        crate.GetComponent<PossessCrate>().possessed = true;
                        crate.GetComponent<PossessCrate>().ghostEffect.GetComponent<SpriteRenderer>().enabled = true;

                        possessing = true;
                        sr.enabled = false;

                        cooldown = 1f;
                    }
                } else if (possessing) {
                    crate.GetComponent<PossessCrate>().possessed = false;
                    crate.GetComponent<PossessCrate>().ghostEffect.GetComponent<SpriteRenderer>().enabled = false;

                    possessing = false;
                    sr.enabled = true;

                    cooldown = 1f;
                }
            }
        }

        if (!(cooldown < -1))
            cooldown -= Time.deltaTime;

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
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        
    }
}
