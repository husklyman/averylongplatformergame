/*using UnityEngine;

public class MoveLevelBar : MonoBehaviour
{
    [SerializeField] private RectTransform levelBar; // Reference to the level bar's RectTransform
    public float speed = 100f;                      // Speed of movement (pixels per second)
    [SerializeField] private bool moveUp;           // Determines if this arrow moves the bar up
    [SerializeField] private float minY = 0f;       // Minimum Y position (anchored)
    [SerializeField] private float maxY = 500f;     // Maximum Y position (anchored)

    void OnMouseOver()
    {
        Debug.Log("moves up " + moveUp);
        // Calculate the direction of movement
        Vector2 direction = moveUp ? Vector2.up : Vector2.down;
        levelBar.anchoredPosition = new Vector2(
        levelBar.anchoredPosition.x,
        Mathf.Clamp(levelBar.anchoredPosition.y, minY, maxY)
        );


        // Move the level bar in the specified direction
        levelBar.anchoredPosition += direction * speed * Time.deltaTime;

        // Clamp the level bar's position within the bounds
    }
}
*/