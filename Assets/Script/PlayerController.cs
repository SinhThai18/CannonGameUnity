﻿using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance == null) return; // Kiểm tra tránh lỗi null
        if (GameManager.Instance.isPaused) return; // Dừng nếu game bị pause

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, 0f, 180f);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


}
