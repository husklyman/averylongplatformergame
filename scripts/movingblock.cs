using UnityEngine;

public class movingblock : MonoBehaviour
{
    private Vector2 startposition;  // The first position
    [SerializeField] private Vector2 position2;  // The second position
    [SerializeField] private float speed = 2f;   // Speed of the movement

    private bool movingToPosition2 = true;       // Track direction

    private void Start()
    {
        // Set the starting position to position1
        startposition = transform.position;
    }

    private void Update()
    {
        // Calculate the target position based on the current direction
        Vector2 targetPosition = movingToPosition2 ? position2 : startposition;

        // Move the block towards the target position
        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the block is close enough to the target to switch directions
        if (Vector2.Distance(transform.position, targetPosition) <= 0.01f)
        {
            movingToPosition2 = !movingToPosition2;  // Toggle direction
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}

