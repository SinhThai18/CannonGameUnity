using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    void Update()
    {
        // Lấy vị trí chuột trên màn hình và chuyển sang tọa độ thế giới
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Đảm bảo không thay đổi trục Z

        // Tính hướng từ đại bác đến con trỏ chuột
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Giới hạn góc xoay từ 0 đến 180 độ (nếu đã xoay 90 độ ban đầu)
        angle = Mathf.Clamp(angle, 0f, 180f);

        // Áp dụng góc xoay mới cho chỉ phần đầu đại bác
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
