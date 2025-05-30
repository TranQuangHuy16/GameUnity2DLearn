using UnityEngine;

public class EnemyController : MonoBehaviour

{
    [SerializeField] private float speed = 2f; // Speed of the enemy movement
    [SerializeField] private float distance = 5f;
    private Vector3 startPosition;
    private bool movingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position; // Store the initial position of the enemy
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPosition.x - distance; // Calculate the left boundary    
        float rightBound = startPosition.x + distance; // Calculate the right boundary
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // Move the enemy to the right
            if (transform.position.x >= rightBound) // Check if the enemy has reached the right boundary
            {
                movingRight = false; // Change direction to left
                Flip();
            }

        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBound) // Check if the enemy has reached the left boundary
            {
                movingRight = true; // Change direction to right
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the enemy's scale on the x-axis
        transform.localScale = scale; // Apply the flipped scale
    }
}
