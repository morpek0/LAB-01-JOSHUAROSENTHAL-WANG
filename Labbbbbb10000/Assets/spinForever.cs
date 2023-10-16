using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinForever : MonoBehaviour
{
    public float speed = 1.0f;
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
    }
}
