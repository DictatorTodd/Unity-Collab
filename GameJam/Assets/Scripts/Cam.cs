using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private float sensitivity = .25f;
    public float smoothing = 1.5f;

    private float xMousePos;
    private float yMousePos;
    private float smoothedMousePos;
    private float smoothedMousePosy;

    private float currentPos;
    private float currentPosy;



    // Start is called before the first frame update
    void Start()
    {
        //locks cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }
    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
        yMousePos = Input.GetAxisRaw("Mouse Y");
    }
    void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        yMousePos *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f/sensitivity);
        smoothedMousePosy = Mathf.Lerp(smoothedMousePosy, yMousePos, 1f / sensitivity);
    }
    void MovePlayer()
    {
        currentPos += smoothedMousePos;
        currentPosy += smoothedMousePosy;
        currentPosy = Mathf.Clamp(currentPosy, -89f, 89f);
        //transform currentPos by - and in "x"" position
        transform.eulerAngles = new Vector3(-currentPosy, currentPos, 0);

    }
}
