using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.InputSystem.Utilities;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float maxSpeed = 5f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject mainCamera;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private bool isShiftPressed = false;
    public AudioSource snow;



   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

  
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        snow.Play();
    }

   
    void OnStop(InputValue value)
    {
        isShiftPressed = value.isPressed;
        snow.Stop();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 6)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
 
        if (isShiftPressed)
        {
            StopMovement();
        }
        else
        {
          
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;

            cameraForward.Normalize();
            cameraRight.Normalize();

         
            Vector3 movement = cameraForward * movementY + cameraRight * movementX;

       
            rb.AddForce(movement * speed);
        }
        if (speed == 0)
        {
            snow.Stop();
        }
    }

   
    private void StopMovement()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}
