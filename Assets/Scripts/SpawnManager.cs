using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject enemyClone;
    public GameObject enemyShooterClone;
    public Transform playerPosition;
    private GameObject newEnemy ;
    public float timer = 3;
    void Start() {
    }

    void Update() {
        if (timer > 0) {
            timer -= Time.deltaTime;
        } else { 
            EnemySpawner();
            EnemyShooterSpawner();
            timer = 3;
        }
    }

    void EnemySpawner() {
        if (playerPosition != null) {


            newEnemy = Instantiate(enemyClone, SpawnerRandomaizer(), transform.rotation);
            newEnemy.GetComponent<Enemy>().target = playerPosition;
        }
    }

    void EnemyShooterSpawner() {
        if (playerPosition != null) {
            newEnemy = Instantiate(enemyShooterClone, SpawnerRandomaizer(), transform.rotation);
            newEnemy.GetComponent<Enemy>().target = playerPosition;
        }
    }


    public Vector2 SpawnerRandomaizer() {
        int randomeZone = Random.Range(1, 5);

        Vector2 spawnPosition;

        switch (randomeZone) {
            case 1:
                spawnPosition = new Vector2(Random.Range(-12.5f, 12.5f), Random.Range(4.4f, 5.4f));
                break;
            case 2:
                spawnPosition = new Vector2(Random.Range(-12.5f, 12.5f), Random.Range(-7.4f, -6.4f));
                break;
            case 3:
                spawnPosition = new Vector2(Random.Range(-12.5f, -11.5f), Random.Range(-7.4f, 5.4f));
                break;
            case 4:
                spawnPosition = new Vector2(Random.Range(11.5f, 12.5f), Random.Range(-7.4f, 5.4f));
                break;
            default:
                spawnPosition = Vector2.zero;
                break;
        }

        return spawnPosition;
    }
}
