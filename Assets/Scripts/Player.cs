using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    public LayerMask interactMask;
    public BoxCollider2D interactCollider;
    public Animator animator;

    public UnityEvent OnDie;

    public static Player Instance { get; private set; }

    private Vector2 velocity;

    private PlayerInput input;
    private Rigidbody2D rb;
    private bool isDying;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }
        Instance = this;

        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        input.OnInteractKeyDown += OnInteractKeyDown;
        isDying = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity.x = input.Horizontal * speed * Time.deltaTime;
        velocity.y = input.Vertical * speed * Time.deltaTime;
        if (input.Horizontal != 0 || input.Vertical != 0) {
            animator.SetBool("IsWalking", true);
        }
        else {
            animator.SetBool("IsWalking", false);
        }
        rb.MovePosition(rb.position + velocity);
        
        if (input.Horizontal != 0) {
            float rotation = input.Horizontal > 0 ? 0 : 180;
            transform.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
        }
    }

    public void Die() {
        if (isDying) {
            return;
        }
        isDying = true;
        velocity.x = 0;
        velocity.y = 0;
        animator.SetTrigger("Die");
        input.CanUseInputs = false;
        OnDie.Invoke();
    }

    public void Revive() {
        input.CanUseInputs = true;
        animator.SetTrigger("Revive");
        isDying = false;
    }

    void OnInteractKeyDown() {
        Collider2D hit = Physics2D.OverlapBox(interactCollider.bounds.center, interactCollider.size, 0, interactMask);
        if (hit) {
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable != null) {
                interactable.OnInteract();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("enemy")) {
            Die();
        }
    }
}
