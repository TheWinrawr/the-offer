using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileEnemy : MonoBehaviour {
    public BoxCollider2D[] areas;

    public float speed = 8f;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start() {
        ChooseRandomDestination();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Vector3.Distance(transform.position, destination) < 0.2f) {
            ChooseRandomDestination();
        }
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
    }

    private void ChooseRandomDestination() {
        int index = Random.Range(0, areas.Length);
        Bounds bounds = areas[index].bounds;
        destination.x = Random.Range(bounds.min.x, bounds.max.x);
        destination.y = Random.Range(bounds.min.y, bounds.max.y);
        destination.z = 0;
    }
}
