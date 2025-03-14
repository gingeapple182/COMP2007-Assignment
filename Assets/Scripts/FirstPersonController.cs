using UnityEngine;

/* First Person Controller
 * Uses a Character Controller component to drive motion
 * Uses a camera for first person looking
 * Has 2 move speeds, walkSpeed and runSpeed
 * Holding down shift while moving swaps between speeds
 * Uses standard unity inputs for horizontal, vertical, mouse x and mouse y
 */ 


// The character controller allows is easy movement input for a gameobject with physics system integration 
// https://docs.unity3d.com/2021.2/Documentation/ScriptReference/CharacterController.html
[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    // Walking speed of character
    public float walkSpeed = 1;

    // Running speed of character
    public float runSpeed = 2;

    // rotation speed for both X and Y axis
    public float turnSpeed = 1;

    // The transorm of the camera
    // NOTE: make sure you have added the camera as a child of the character gameobject
    public Transform camTransform;

    // The character controller we use for movement
    private CharacterController character;

    // Pitch is used to clamp the look rotation of the camera 
    private float pitch = 0;

    void Start()
    {
        // here we hide the mouse
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Cursor-lockState.html
        Cursor.lockState = CursorLockMode.Locked;

        // We get a reference to the character controller
        character = GetComponent<CharacterController>();
    }


    void Update()
    {
        // MOVEMENT from the input manager
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Input.GetAxis.html
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // here we create our direction of movement from the intput and the transform
        // the strafe movement is the current right facing direction (transform.right) and horizontal input (x)
        // the forward/backward movement is the current forward direction (transform.forward) and vertical input (y)
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Transform-right.html
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Transform-forward.html
        Vector3 moveDirection = transform.right * x + transform.forward * y;

        // Here we check if the shift key is held down
        // we adjust the character controllers move speed using runSpeed and walkSpeed
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Input.GetKey.html
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/KeyCode.html
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // the Move method on a character controller applied movement in the vector3 direction supplied
            // here, we take the move direction, run speed and use delta time for the update
            // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/CharacterController.Move.html
            // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Time-deltaTime.html
            character.Move(moveDirection * runSpeed  * Time.deltaTime);
        }
        else
        {
            // here, we take the move direction, walk speed and use delta time for the update
            character.Move(moveDirection * walkSpeed * Time.deltaTime);
        }
       

        // LOOKING
        // the input manager has a default setting for mouse input on X and Y axis
        // here we take the input and turn speed, including delta time for the update
        float mX = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        float mY = Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;

        // pitch is the up/down rotation, we need to invert it for keyboard first person controls (joypad controls may not require this though)
        pitch -= mY;

        // we clamp the pitch at 90 degrees in each direction so the character can look straight up or down, but no further
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Mathf.Clamp.html
        pitch = Mathf.Clamp(pitch, -90, 90);

        // we apply the pitch to the camera x rotation axis
        // local rotation ensure the rotation is consistent with the parent gameobject
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Quaternion.Euler.html
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Transform-localRotation.html
        camTransform.localRotation = Quaternion.Euler(pitch, 0, 0);

        // here we adjust the character rotation on the y axis
        // note how we are applying the mouse x (mX) to the y axis
        // the left/right mouse input is applied to the transform as y or yaw axis rotation
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Transform.Rotate.html
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Vector3-up.html
        transform.Rotate(Vector3.up * mX);

    }
}
