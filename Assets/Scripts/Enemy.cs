using UnityEngine;

public class Enemy : MonoBehaviour {
    private Rigidbody2D rb;
    public Transform target; // Позиция игрока, передается в SM
    private Vector2 direction;
    public bool isKnockback;
    public float knockbackTime = 0.15f;
    public float force = 8.0f;
    public float speed;
    public float hitpoint = 3.0f;

    protected void Start() {
        rb = GetComponent<Rigidbody2D>();
        isKnockback = false;
    }

    void FixedUpdate() {

        if (isKnockback) {
            knockbackTime -= Time.fixedDeltaTime;
            if (knockbackTime <= 0) {
                isKnockback = false;
            }
            return;
        }

        if (target != null) {
            Vector2 position = (target.position - transform.position).normalized;
            rb.linearVelocity = position * speed;
        }
        else {
            rb.linearVelocity = Vector2.zero;
            return;
        }
    }

    public void Knockback(Collider2D col) {
        Projectile bullet = col.GetComponent<Projectile>();
        direction = bullet.shootDirection;
        TakeDamage();
        Destroy(col.gameObject);
        isKnockback = true;
        knockbackTime = 0.15f;
        rb.AddForce(direction * force, ForceMode2D.Impulse);

    }

    public void TakeDamage() {
        hitpoint -= 1;
        if (hitpoint <= 0) {
            Destroy(gameObject);
        }
    }
}
