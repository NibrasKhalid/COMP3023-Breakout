using UnityEngine;
using UnityEngine.InputSystem;


public class Paddle : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    public float xAxis = 7.5f;

    private Vector2 moveInput;
    private Rigidbody2D rBody;

    private void Awake(){
        rBody = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        float moveX = moveInput.x * moveSpeed;
        rBody.linearVelocity = new Vector2(moveX, 0f);

        float clampedX = Mathf.Clamp(transform.position.x, -xAxis, xAxis);
        transform.position = new Vector2(clampedX, transform.position.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
    }
}
