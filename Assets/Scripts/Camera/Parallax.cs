using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    public float parallaxEffect;

    private float length;
    private float startPos;
    // Start is called before the first frame update
    void Start() {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate() {
        float distance = Camera.main.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
