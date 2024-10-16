using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; 
    public float distance = 5.0f;
    public float height = 3.0f; 
    public float damping = 5.0f; 
    public float sensitivity = 5.0f; 

    private float rotationY = 0.0f; 
    private float rotationX = 0.0f; 

    void LateUpdate()
    {
       
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -40, 85); 

        
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 position = player.position - rotation * Vector3.forward * distance + Vector3.up * height;

        
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);
        transform.LookAt(player.position + Vector3.up * 1.5f); 
    }
}
