using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;//movement speed in units per second
    public float jumpForce;//force applied upwards on jump
    [Header("Camera")]
    public float lookSensitivity;//mouse look sensitivity
    public float maxLookX;//lowest down to look
    public float minLookX;//highest up to look
    private float rotX;//current x rotation of the camera

    private Camera cam;
    private Rigidbody rig;
    private Projectile weapon;
    
    void Awake()
    {
        cam = Camera.main;
        rig = GetComponent<Rigidbody>();
        weapon = GetComponent<Projectile>();

        //disable and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();

        if(Input.GetButtonDown("Jump"))
            TryJump();
            // TryJump2();

        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //Move relative to the cameras forward direction
        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rig.velocity.y;

        rig.velocity = dir;
    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX); // Clamp the vertical rotation on the x-axis

        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0); //Drive rotation on the x-axis
        transform.eulerAngles += Vector3.up * y;//drive rotation on the y-axis
    }
    void TryJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Ray ray2 = new Ray(transform.position, Vector3.forward);

        if(Physics.Raycast(ray, 1.1f))
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        else
            

            if(Physics.Raycast(ray2, 15.0f))
                rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            
    }
    // void TryJump2()
    // {
    //     Ray ray2 = new Ray(transform.position, Vector3.forward);

    //     if(Physics.Raycast(ray2, 5.0f))
    //         rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    // }
}