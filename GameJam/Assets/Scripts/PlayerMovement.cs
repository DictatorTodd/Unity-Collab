using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private CharacterController player1;
    private Vector3 inputVector;
    private Vector3 movementVector;
    private float gravity = -10f;
    public float acceleration = .25f;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
    }
    void GetInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();
            inputVector = (forward * inputVector.z + right * inputVector.x).normalized;
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, acceleration * Time.deltaTime);
        }

        movementVector = (inputVector * speed) + (Vector3.up * gravity);

        //inputVector = transform.TransformDirection(inputVector);
        //movementVector = (inputVector * speed) + (Vector3.up * gravity);
    }
    void MovePlayer()
    {

        player1.Move((Vector3)movementVector * Time.deltaTime);
    }
}