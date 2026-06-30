using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private float horizontalMove;
    private float verticalMove;
    public float speed = 8.0f;
    public float hitPoint = 3;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        Vector2 direction = new Vector2(horizontalMove, verticalMove);
        direction.Normalize();
        rb.linearVelocity = direction * speed;

    }

    public void TakeDamage(float damage) {
        Debug.Log("Урон получен");
        hitPoint -= damage;
        if (hitPoint <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("EnBullet")) {
            EnemyProjectile bullet = collision.GetComponent<EnemyProjectile>();
            TakeDamage(bullet.damage);
            Destroy(bullet.gameObject);
            Debug.Log("Пуля попала");
        }
    }

}
