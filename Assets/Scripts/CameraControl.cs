using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z), ref velocity, smoothTime);
            //new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
