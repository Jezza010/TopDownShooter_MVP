using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject projectile;
    public float delayTime = 0.2f;
    public float timer = 0;
    void Start() {

    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && timer <= Time.time) {
            CreateProjectile();
            timer = Time.time + delayTime;
        } 
    }

    void CreateProjectile() {
        Instantiate(projectile, transform.position, projectile.transform.rotation);
    }
}
