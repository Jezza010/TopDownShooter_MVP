using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public Transform targetPlayer;
    public Vector2 shootDirection;
    public float lifeTime;
    public float speed = 20.0f;
    public float damage = 1.0f;


    void Start()  
    {
        if (targetPlayer != null) {
            shootDirection = targetPlayer.position - transform.position;
            shootDirection.Normalize();
        }
    }

    
    void Update()
    {
        if (lifeTime > 0) {
            lifeTime -= 1 * Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
        transform.Translate(shootDirection * speed * Time.deltaTime);
    }
}
