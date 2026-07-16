using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 8f;

    [Header("Camera Position")]
    public float height = 10f;      // how high above the player
    public float distance = 7f;     // how far behind the player

    void LateUpdate()
    {
        if (target == null) return;

        // Position the camera behind and above the player in world space
        Vector3 desiredPosition = target.position + new Vector3(0, height, -distance);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Always look at the player — keeps them centered on screen
        transform.LookAt(target.position);
    }
}
