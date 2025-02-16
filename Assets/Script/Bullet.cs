using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            Destroy(gameObject); // Hủy bullet khi chạm boundary
        }
        else if (collision.CompareTag("Enemy")) // Nếu bullet chạm enemy
        {
            collision.gameObject.SetActive(false); // Ẩn enemy, trả về pool
            Destroy(gameObject); // Hủy bullet
        }
    }
}
