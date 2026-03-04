using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1f;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private int health = 100;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateUI();
    }

    void Update()
    {
        // Horizontal movement (A/D, Left/Right arrows by default)
        float moveInput = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveInput = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveInput = 1f;
        }

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jump (Space by default)
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            UpdateUI();

            if (health <= 0)
            {
                GameOver();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 10;
            Destroy(other.gameObject);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (healthText != null) healthText.text = "Health: " + health;
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        SceneManager.LoadScene("GameOver");
    }
}