using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] makes a private variable editable in the Inspector
    [SerializeField] private float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private InputAction moveAction;
    private Vector2 moveInput;

    //Start is called once, before the first frame
    private void Start()
    {
        //keep the mouse cursor out of the way while playing
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move"); //"Move" is defined in the Input Actions asset
    }

    //Update is called every frame, a good place to read input
    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    //FixedUpdate runs at a fixed rate and is the right place for physics
    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
