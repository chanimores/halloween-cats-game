using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private float speed = 9;

    private void FixedUpdate() {
        Vector3 cameraCoords = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, cameraCoords + new Vector3(0,0,-10), Time.deltaTime * speed);
    }
}
