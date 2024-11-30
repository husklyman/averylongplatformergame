using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class paperanimation : MonoBehaviour
{
    Vector2 startposition;
    Vector2 endposition;
    [SerializeField] Vector2 direction;
    [SerializeField] float speed;
    bool ismoving1;
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
        endposition = startposition + direction;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the target position based on the current direction
        Vector2 targetPosition = ismoving1 ? endposition : startposition;

        // Move the block towards the target position
        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the block is close enough to the target to switch directions
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            ismoving1 = !ismoving1;  // Toggle direction
        }
    }
}
