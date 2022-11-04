using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenTrigger : MonoBehaviour {

    [SerializeField] Camera mainCamera;
    [SerializeField] Camera player1Camera;
    [SerializeField] Camera player2Camera;

    private void Start() {
        mainCamera.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("CameraTrigger")) {
            player1Camera.enabled = false;
            player2Camera.enabled = false;

            mainCamera.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag.Equals("CameraTrigger")) {
            player1Camera.enabled = true;
            player2Camera.enabled = true;

            mainCamera.enabled = false;
        }
    }

}
