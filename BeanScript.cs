using UnityEngine;
using UnityEngine.InputSystem;
public class BeanScript : MonoBehaviour
{

    public float Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      PlayerInput pi = GetComponent<PlayerInput>();

      InputAction moveAction = pi.actions["Move"];

        // Are any of the buttons mapped to the action currently being pressed?

        if (moveAction.IsPressed() == true)

        {

            // Read the value of the action.

            Vector2 amount = moveAction.ReadValue<Vector2>();

            // Access the Transform component.

            Transform transform = GetComponent<Transform>();

            // Make a copy of the current position.

            Vector2 position = transform.position;

            // Update the copy of the position based on the amount.

            position.x = position.x + amount.x;

            position.y = position.y + amount.y;

            // Update the component with the new position.

            transform.position = position;

        }

    }

    void OnMove (InputValue movement)
    {
        Vector2 move = movement.Get<Vector2>();

          // Shortcut for transform
        Vector2 position = transform.position;

        // How muuch to move = current postion + (Speed * Time.deltaTime).
        position.x = position.x + (Speed * Time.deltaTime) * move.x;

        position.y = position.y + (Speed * Time.deltaTime) * move.y;

        // Update original
        transform.position = position;
    }
}
