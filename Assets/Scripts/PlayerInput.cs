using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool CanUseInputs { get; set; }

    public event Action OnInteractKeyDown = delegate { };

    private void Start() {
        CanUseInputs = true;
    }

    private void Update() {
        if (CanUseInputs) {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.Space)) {
                OnInteractKeyDown();
            }
        }
        else {
            Horizontal = 0;
            Vertical = 0;
        }

    }
}
