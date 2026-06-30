using UnityEngine;


public class Projectile : MonoBehaviour {
    public Vector2 shootDirection;
    public float lifeTime;
    public float speed = 20.0f;

    private void Awake() {
        shootDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        shootDirection.Normalize();
    }

    void Update() {
        if (lifeTime > 0) {
            lifeTime -= 1 * Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
        transform.Translate(shootDirection * speed * Time.deltaTime);
    }

}
