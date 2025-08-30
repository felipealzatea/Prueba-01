using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class MoveNewInput : MonoBehaviour
{
    public float speed = 3f;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        float h = 0;
        float v = 0;

        if (Keyboard.current.aKey.isPressed) h = -1;
        if (Keyboard.current.dKey.isPressed) h = 1;
        if (Keyboard.current.wKey.isPressed) v = 1;
        if (Keyboard.current.sKey.isPressed) v = -1;

        Vector3 move = (transform.forward * v + transform.right * h).normalized;
        cc.Move(move * speed * Time.deltaTime);
    }
}
