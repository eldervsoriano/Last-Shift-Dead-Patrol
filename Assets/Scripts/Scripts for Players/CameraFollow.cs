using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Vector3 offset;   // Offset to maintain a specific distance from the player

    private void LateUpdate()
    {
        // Update camera position to follow the player while maintaining the original rotation
        transform.position = player.position + offset;
    }
}
