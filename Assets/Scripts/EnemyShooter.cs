using UnityEngine;

public class EnemyShooter : Enemy
{
    public GameObject projectile;
    public GameObject bullet;
    public Vector2 shootDirection;
    public float timer = 0;
    public float delay = 1;
    public float startDelay;


    new void Start()
    {
        base.Start();
        hitpoint = 2;
        startDelay = Random.Range(0.0f, 2.0f);
        timer = startDelay;

    }
    
    void Update() {
        if (timer <= Time.time) {
            Debug.Log("Время выстрела: " + Time.time);
            CreateProjectile();
            timer = Time.time + delay + startDelay;
        }
    }
    void CreateProjectile() {
        if (target != null) {
            bullet = Instantiate(projectile, transform.position, projectile.transform.rotation);
            bullet.GetComponent<EnemyProjectile>().targetPlayer = target;
        }
    }
}
