using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool; // Tham chiếu đến Pool
    public Transform spawnPoint; // Điểm spawn
    public float spawnInterval = 2f; // Thời gian spawn mỗi quái

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval); // Tạo quái theo thời gian
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetEnemy(); // Lấy Enemy từ pool
        enemy.transform.position = spawnPoint.position; // Đặt vị trí spawn
    }
}
