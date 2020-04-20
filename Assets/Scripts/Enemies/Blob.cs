using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public Vector2 TargetPos {
        get { return targetPos; }
        set {
            if (timeUntilDestination < 0) {
                targetPos = value;
            }
        }
    }
    public float TargetScale {
        get { return targetScale; }
        set {
            if (timeUntilDestination < 0) {
                targetScale = value;
            }
        }
    }
    public float DestinationTime {
        get { return destinationTime; }
        set {
            if (timeUntilDestination < 0) {
                destinationTime = value;
                timeUntilDestination = value;
            }
        }
    }

    private Vector2 targetPos;
    private float targetScale;
    private float destinationTime;
    private float timeUntilDestination;

    private float xVelocity;
    private float yVelocity;
    private float scaleVelocity;

    private void Start() {
        timeUntilDestination = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeUntilDestination >= 0) {
            timeUntilDestination -= Time.deltaTime;
            float xPos = Mathf.SmoothDamp(transform.position.x, targetPos.x, ref xVelocity, destinationTime);
            float yPos = Mathf.SmoothDamp(transform.position.y, targetPos.y, ref yVelocity, destinationTime);
            float scale = Mathf.SmoothDamp(transform.localScale.x, targetScale, ref scaleVelocity, destinationTime);
            transform.position = new Vector3(xPos, yPos, transform.position.z);
            transform.localScale = new Vector3(scale, scale, transform.localScale.z);
        }
    }

}
