using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ShepherdControl : MonoBehaviour
{
    float xRot;
    float yRot;

    public float xSens = 100f;
    public float ySens = 100f;
    public float moveSpeed = 0.1f;

    public float bakingTimer = 0f;

    public GameObject wheat;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            wheat.SetActive(!wheat.activeSelf);
        }

        bakingTimer += Time.deltaTime;
        if (bakingTimer > 0.1f)
        {
            
        }
       
    }
}
