using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMover : MonoBehaviour
{
    public float minX, maxX;
    public float minY, maxY;
    public float minSpeed = 0.2f;
    public float maxSpeed = 1f;

    private Vector2 oldPos;
    private Vector2 newPos;
    private float moveTime;
    private float timeToDestination;

    private void Start() {
        timeToDestination = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToDestination <= 0) {
            moveTime = Random.Range(minSpeed, maxSpeed);
            oldPos = transform.localPosition;
            newPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            timeToDestination = moveTime;
        }
        else {
            timeToDestination -= Time.deltaTime;
            float xPos = Mathf.Lerp(oldPos.x, newPos.x, 1 - timeToDestination / moveTime);
            float yPos = Mathf.Lerp(oldPos.y, newPos.y, 1 - timeToDestination / moveTime);
            transform.localPosition = new Vector2(xPos, yPos);
        }
    }
}
