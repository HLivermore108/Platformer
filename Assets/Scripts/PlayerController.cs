using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public TextMeshProUGUI heathText;
    public TextMeshProUGUI scoreText;

    private Rigidbody rb;
    private bool isGrounded = false;
    private int health = 100;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateUI();
    }

    private void Update()
    {
        // Horizontal Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }


}

