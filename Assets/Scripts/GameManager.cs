using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Starting Values")]
    public int startingHealth = 100;
    public int startingScore = 0;

    public int CurrentHealth { get; private set; }
    public int CurrentScore { get; private set; }

    // Delegates
    public delegate void ScoreChanged(int newScore);
    public delegate void HealthChanged(int newHealth);
    public delegate void GameOverEvent();

    // Events
    public event ScoreChanged OnScoreChanged;
    public event HealthChanged OnHealthChanged;
    public event GameOverEvent OnGameOver;

    private bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        ResetGame();
    }

    public void ResetGame()
    {
        isGameOver = false;
        CurrentScore = startingScore;
        CurrentHealth = startingHealth;

        OnScoreChanged?.Invoke(CurrentScore);
        OnHealthChanged?.Invoke(CurrentHealth);
    }

    public void AddScore(int amount)
    {
        CurrentScore += amount;
        OnScoreChanged?.Invoke(CurrentScore);
    }

    public void TakeDamage(int amount)
    {
        if (isGameOver) return;

        CurrentHealth -= amount;

        if (CurrentHealth < 0)
            CurrentHealth = 0;

        OnHealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        OnGameOver?.Invoke();
    }
}
