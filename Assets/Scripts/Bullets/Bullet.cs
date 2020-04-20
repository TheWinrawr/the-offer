using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour, IBulletMovement
{
    public float Speed { get; set; }
    public float Angle { get; set; }

    public float rotationOffset = -90f;
    public float lifeSpan = 10f;

    private Vector2 velocity;
    private float fadeTime = 0.3f;

    private new Collider2D collider;
    private new SpriteRenderer renderer;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0) {
            Die();
        }
    }

    private void FixedUpdate() {
        velocity.x = Speed * Mathf.Cos(Angle * Mathf.Deg2Rad);
        velocity.y = Speed * Mathf.Sin(Angle * Mathf.Deg2Rad);
        transform.position += (Vector3) velocity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0f, 0f, Angle + rotationOffset);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player") || collision.tag.Equals("removeBullets")) {
            Player player = collision.GetComponent<Player>();
            if (player != null) {
                player.Die();
                Destroy(gameObject);
            }
            Die();
        }
    }

    private void Die() {
        collider.enabled = false;
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut() {
        float timeUntilFadeOut = fadeTime;
        Color color = renderer.color;
        while (timeUntilFadeOut > 0) {
            timeUntilFadeOut -= Time.deltaTime;
            float t = 1 - timeUntilFadeOut / fadeTime;
            float alpha = Mathf.Lerp(1, 0, t);
            color.a = alpha;
            renderer.color = color;
            yield return null;
        }
        Destroy(gameObject);
    }
}
