using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MobileMovement : MonoBehaviour
{
    protected Joystick joystick;
    private CharacterController _charController;
    private Transform _transform;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        joystick = FindObjectOfType<Joystick>();
        _transform = transform;

        UnityEngine.Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal") * 10f;
        float deltaZ = Input.GetAxis("Vertical") * 10f;

        var rigitbody = GetComponent<Rigidbody>();
        rigitbody.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 10f, 
            rigitbody.velocity.y,
            joystick.Vertical * 10f + Input.GetAxis("Vertical") * 10f);
      


       

       velocity = ((new Vector3(joystick.Horizontal * 10f, 0, 0) + new Vector3(0, 0, joystick.Vertical * 10f) + Vector3.down) * Time.deltaTime);
       _charController.Move(velocity);
       
    }
}
