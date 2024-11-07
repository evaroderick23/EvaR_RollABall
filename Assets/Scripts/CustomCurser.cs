using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D customCursorTexture; 
    public Vector2 cursorHotspot = new Vector2(16, 16); 

    
    void Start()
    {
        
        Cursor.SetCursor(customCursorTexture, cursorHotspot, CursorMode.Auto);

        
        Cursor.visible = true;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Cursor.visible = false; // Hide cursor
            Cursor.lockState = CursorLockMode.Locked; 
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None; 
        }
    }
}
