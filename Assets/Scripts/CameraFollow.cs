using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The target the camera will follow
    public float smoothSpeed = 0.125f;  // The speed of the smooth following
    public Vector3 offset;  // Offset of the camera from the target

    void FixedUpdate()
    {
        
        //target.position + offset;
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);  // Optional: to keep the camera oriented toward the target
    }
}

