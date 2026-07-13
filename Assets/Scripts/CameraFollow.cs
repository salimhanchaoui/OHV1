using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 12, -8);
    public float smoothSpeed = 8f;

    void LateUpdate()
    {
        if (target == null) return;

        // Follow player position with a fixed world-space offset
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Always point at the player so they stay centered
        transform.LookAt(target.position);
    }
}
