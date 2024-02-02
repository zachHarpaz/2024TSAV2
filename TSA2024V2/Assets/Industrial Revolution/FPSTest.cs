using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSTest : MonoBehaviour
{
    public float sensitivity_setter = 3f;
    private float sensitivity = 3f;
    [SerializeField] private float orbitSensitivity;
    public float jumpSpeed = 10f;
    public CharacterController ch;
    public float gravity = 20f;
    public Vector3 moveDirection;
    float vSpeed = 0;
    bool hasJumped = false;
    public Vector3 impact;
    public AudioSource jumpAudio;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        jumpSpeed = 10f;

    }


    // Update is called once per frame
    void Update()
    {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = transform.TransformDirection(moveDirection);


        if (Input.GetKey("left shift"))
        {
            sensitivity = sensitivity_setter * 1.7f;
        }
        else
        {
            sensitivity = sensitivity_setter;
        }
        moveDirection *= sensitivity;


        




        float yaw = Input.GetAxis("Mouse X") * orbitSensitivity * Time.deltaTime;
        float pitch = Input.GetAxis("Mouse Y") * orbitSensitivity * Time.deltaTime;

        Vector3 rot = transform.rotation.eulerAngles + new Vector3(-pitch, yaw, 0f);
        rot.x = ClampAngle(rot.x, -90, 70);
        transform.eulerAngles = rot;

        if (ch.isGrounded)

        {
            vSpeed = -20;

            if (Input.GetButtonDown("Jump"))
            {
                jumpAudio.time = 0.446f;
                jumpAudio.Play();
                vSpeed = jumpSpeed;
                hasJumped = true;
                impact = transform.forward * 15;

            }


        }
        else
        {
            hasJumped = false;
        }
        vSpeed -= gravity * Time.deltaTime;
        moveDirection.y = vSpeed;
        ch.Move(moveDirection * Time.deltaTime);



    }
    protected float ClampAngle(float angle, float min, float max)
    {

        angle = NormalizeAngle(angle);
        if (angle > 180)
        {
            angle -= 360;
        }
        else if (angle < -180)
        {
            angle += 360;
        }

        min = NormalizeAngle(min);
        if (min > 180)
        {
            min -= 360;
        }
        else if (min < -180)
        {
            min += 360;
        }

        max = NormalizeAngle(max);
        if (max > 180)
        {
            max -= 360;
        }
        else if (max < -180)
        {
            max += 360;
        }

        // Aim is, convert angles to -180 until 180.
        return Mathf.Clamp(angle, min, max);
    }

    /** If angles over 360 or under 360 degree, then normalize them.
     */
    protected float NormalizeAngle(float angle)
    {
        while (angle > 360)
            angle -= 360;
        while (angle < 0)
            angle += 360;
        return angle;
    }




}
