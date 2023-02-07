using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreelooksCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public float cameraRotationSensitivityX = 5.0f;
    public float cameraRotationSensitivityY = 5.0f;
    public float cameraRotationSensitivityZ = 5.0f;

    public float cameraPositionSensitivityX = 10f;
    public float cameraPositionSensitivityY = 10f;
    public float cameraPositionSensitivityZ = 20f;

    private float minimumY = -60.0f;
    private float maximumY = 60;

    protected float cameraRotationX = 0.0f, cameraRotationY = 0.0f, cameraRotationZ = 0.0f, cameraPositionX= 0.0f, cameraPositionY=0.0f;

    public Vector3 Transport = new Vector3(0f,0f,0f);
    void Start()
    {
        //Reset rotation from camera's world rotation
        Transport = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovementEvent();
    }
    void CameraMovementEvent()
    {
        //Rotation changer
        cameraRotationY += Input.GetAxis("Mouse Y") * cameraRotationSensitivityY;
        cameraRotationY = Mathf.Clamp(cameraRotationY, minimumY, maximumY);
        cameraRotationX += Input.GetAxis("Mouse X") * cameraRotationSensitivityX;
        if (Input.GetKeyDown(KeyCode.Keypad7)) { cameraRotationZ +=5; }
        else if (Input.GetKeyDown(KeyCode.Keypad9)) { cameraRotationZ-=5; }

        //Position changer
        cameraPositionX = Input.GetAxis("Horizontal");
        cameraPositionY = Input.GetAxis("Vertical");

        Transport = new Vector3(cameraPositionX,cameraPositionY,  Input.GetAxis("Camera Mouse ScrollWheel"));
        //ZAxisWheelTransport += new Vector3(0, 0, Input.GetAxis("Camera Mouse ScrollWheel"));

        //, 

        camera.transform.localEulerAngles = new Vector3(-cameraRotationY, cameraRotationX, cameraRotationZ);
        camera.transform.Translate(Transport*5*Time.deltaTime);
        //cameraPositionX = 0; cameraPositionY = 0;
    }
}
