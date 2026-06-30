using Unity.VisualScripting;
using UnityEngine;

public class Hit : MonoBehaviour {
    private Enemy enemy;

    void Start() {
        enemy = GetComponent<Enemy>();
    }

    void FixedUpdate() {

    }


    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet"))
            enemy.Knockback(collision);
    }
}
