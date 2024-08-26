using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity;
    public float xRot = 0f;
    public float minY = -75f;
    public float maxY = 75f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = new Vector3(player.position.x, player.position.y + .5f, player.position.z);

        MouseLook();
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, minY, maxY);

        transform.rotation = Quaternion.Euler(xRot, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
        player.Rotate(Vector3.up * mouseX);
    }
}
