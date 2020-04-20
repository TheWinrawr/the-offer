using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float minX, maxX;
    public float minY, maxY;
    public float smoothTime = 0.3f;

    private float xVelocity;
    private float yVelocity;

    private void Start() {
        if (Player.Instance != null) {
            transform.position = new Vector3(
                Player.Instance.transform.position.x, 
                Player.Instance.transform.position.y, 
                transform.position.z
                );
        }
    }

    private void FixedUpdate() {
        float targetXPos = transform.position.x;
        float targetYPos = transform.position.y;
        if (Player.Instance != null) {
            targetXPos = Mathf.SmoothDamp(transform.position.x, Player.Instance.transform.position.x, ref xVelocity, smoothTime);
            targetYPos = Mathf.SmoothDamp(transform.position.y, Player.Instance.transform.position.y, ref yVelocity, smoothTime);
        }
        targetXPos = Mathf.Clamp(targetXPos, minX, maxX);
        targetYPos = Mathf.Clamp(targetYPos, minY, maxY);
        transform.position = new Vector3(targetXPos, targetYPos, transform.position.z);
    }
}
