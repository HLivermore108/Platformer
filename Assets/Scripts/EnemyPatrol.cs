using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 3f;

    private Vector3 startPosition;
    private int direction = 1; // 1 = right, -1 = left

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move in current direction
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

        // Check if moved too far from start
        float distanceFromStart = Vector3.Distance(startPosition, transform.position);

        if (distanceFromStart > patrolDistance)
        {
            direction *= -1; // Reverse direction
        }
    }
}