using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Tốc độ di chuyển của quái
    private Vector2 moveDirection = Vector2.right; // Hướng di chuyển ban đầu

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); // Di chuyển quái
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            FlipDirection(); // Đổi hướng khi chạm boundary
        }
    }

    void FlipDirection()
    {
        // Đổi hướng di chuyển
        moveDirection *= -1;

        // Giảm vị trí y xuống 1 đơn vị
        transform.position = new Vector2(transform.position.x, transform.position.y - 1f);

        // Lật enemy theo trục X
        Vector3 newScale = transform.localScale;
        newScale.x *= -1; // Đảo ngược trục X
        transform.localScale = newScale;
    }
}
