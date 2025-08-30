using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLookNewInput : MonoBehaviour
{
    public float sensitivity = 200f;
    public Transform playerBody; // <-- referencia al PlayerRig

    float rotX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 delta = Mouse.current.delta.ReadValue();
        float mouseX = delta.x * sensitivity * Time.deltaTime;
        float mouseY = delta.y * sensitivity * Time.deltaTime;

        // Rotación vertical (solo la cámara)
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);

        // Rotación horizontal (el cuerpo/jugador)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
