using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenTrigger : MonoBehaviour {

    [SerializeField] Camera mainCamera;
    [SerializeField] Camera player1Camera;
    [SerializeField] Camera player2Camera;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [SerializeField] private float speed = 10;

    private void Start() {
        mainCamera.enabled = true;
        player1Camera.enabled = false;
        player2Camera.enabled = false;
    }

    private void FixedUpdate() {
        Vector3 cameraCoords = (player1.transform.position + player2.transform.position)/2;
        transform.position = Vector3.MoveTowards(transform.position, cameraCoords + new Vector3(0,0,-10), Time.deltaTime * speed);
    }
}
