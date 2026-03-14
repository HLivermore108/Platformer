using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
            GameManager.Instance.OnHealthChanged += HandleHealthChanged;
            GameManager.Instance.OnGameOver += HandleGameOver;
        }
    }

    void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
            GameManager.Instance.OnHealthChanged -= HandleHealthChanged;
            GameManager.Instance.OnGameOver -= HandleGameOver;
        }
    }

    void Start()
    {
        if (GameManager.Instance != null)
        {
            HandleScoreChanged(GameManager.Instance.CurrentScore);
            HandleHealthChanged(GameManager.Instance.CurrentHealth);
        }
    }

    void HandleScoreChanged(int newScore)
    {
        Debug.Log("Score changed: " + newScore);

        if (scoreText != null)
            scoreText.text = "Score: " + newScore;
    }

    void HandleHealthChanged(int newHealth)
    {
        Debug.Log("Health changed: " + newHealth);

        if (healthText != null)
            healthText.text = "Health: " + newHealth;
    }

    void HandleGameOver()
    {
        Debug.Log("Game Over event fired");
        SceneManager.LoadScene("GameOver");
    }
}
