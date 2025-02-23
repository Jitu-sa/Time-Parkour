using UnityEngine;

public class CameraFollowXYLimited : MonoBehaviour
{
    [SerializeField] Transform player; // Assign the player object in the Inspector
    [SerializeField] float thresholdX = 2f; // Buffer before the camera moves on X-axis
    [SerializeField] float thresholdY = 1.5f; // Buffer before the camera moves on Y-axis

    float fixedZ = -10; // Store the initial Z position
    Camera cam;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned to CameraFollowXYLimited script!");
            return;
        }

        cam = Camera.main;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Get the camera's half-width and half-height
        float halfWidth = cam.orthographicSize * cam.aspect;
        float halfHeight = cam.orthographicSize;

        // Calculate the camera's left, right, bottom, and top bounds
        float leftBound = transform.position.x - halfWidth + thresholdX;
        float rightBound = transform.position.x + halfWidth - thresholdX;
        float bottomBound = transform.position.y - halfHeight + thresholdY;
        float topBound = transform.position.y + halfHeight - thresholdY;

        float newX = transform.position.x;
        float newY = transform.position.y;

        // Move the camera on X-axis only if the player is out of bounds
        if (player.position.x < leftBound)
        {
            newX = player.position.x + halfWidth - thresholdX;
        }
        else if (player.position.x > rightBound)
        {
            newX = player.position.x - halfWidth + thresholdX;
        }

        // Move the camera on Y-axis only if the player is out of bounds
        if (player.position.y < bottomBound)
        {
            newY = player.position.y + halfHeight - thresholdY;
        }
        else if (player.position.y > topBound)
        {
            newY = player.position.y - halfHeight + thresholdY;
        }

        // Apply the new camera position
        transform.position = new Vector3(newX, newY, fixedZ);
    }
}
