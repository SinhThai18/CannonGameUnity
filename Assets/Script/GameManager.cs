using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton để truy cập từ mọi nơi
    public Text enemyKillText; // UI hiển thị số lượng enemy bị tiêu diệt
    public Button pauseButton; // Nút Pause
    public Text pauseButtonText; // Text hiển thị trên nút Pause

    private int enemyKillCount = 0; // Số lượng enemy bị tiêu diệt
    public bool isPaused = false; // Trạng thái game

    private bool canTogglePause = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        pauseButton.onClick.RemoveAllListeners(); // Xóa sự kiện cũ tránh trùng lặp
        pauseButton.onClick.AddListener(TogglePause);
    }

    public void AddKill()
    {
        enemyKillCount++;
        enemyKillText.text = "Enemies Killed: " + enemyKillCount;
    }

    public void TogglePause()
    {
        if (!canTogglePause) return;

        canTogglePause = false;

        Debug.Log($"[📌 Trước khi đổi] isPaused = {isPaused}, Time.timeScale = {Time.timeScale}");

        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;

        pauseButtonText.text = isPaused ? "Resume" : "Pause";

        Debug.Log($"[✅ Sau khi đổi] isPaused = {isPaused}, Time.timeScale = {Time.timeScale}");

        Invoke(nameof(ResetTogglePause), 0.2f);
    }


    void ResetTogglePause()
    {
        canTogglePause = true; // Mở khóa click
    }
}
