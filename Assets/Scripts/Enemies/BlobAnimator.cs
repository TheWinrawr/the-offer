using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BlobAnimator : MonoBehaviour
{

    public float minSpeed = 0.2f;
    public float maxSpeed = 1f;
    public float minScaleSize = 0.5f;
    public float maxScaleSize = 1.5f;

    private Blob[] blobs;
    private new BoxCollider2D collider;
    void Start()
    {
        blobs = GetComponentsInChildren<Blob>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Blob blob in blobs) {
            float xPos = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            float yPos = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
            float scale = Random.Range(minScaleSize, maxScaleSize);
            float speed = Random.Range(minSpeed, maxSpeed);
            blob.TargetPos = new Vector2(xPos, yPos);
            blob.TargetScale = scale;
            blob.DestinationTime = speed;
        }
    }
}
