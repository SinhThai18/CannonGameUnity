using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của Enemy
    public int poolSize = 10; // Số lượng Enemy có sẵn trong pool

    private List<GameObject> enemyPool = new List<GameObject>(); // Danh sách chứa các Enemy

    void Start()
    {
        // Tạo sẵn các Enemy và đưa vào pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false); // Ẩn Enemy khi chưa dùng
            enemyPool.Add(enemy);
        }
    }

    // Hàm lấy Enemy từ pool
    public GameObject GetEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy) // Tìm Enemy đang bị disable
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        // Nếu hết quái, tạo mới và thêm vào pool
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(true);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }
}
