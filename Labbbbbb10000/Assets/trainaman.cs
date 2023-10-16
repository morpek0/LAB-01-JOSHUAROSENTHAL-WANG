using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class trainaman : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;
    public bool balls;
    public float speed= 8f;
    // Update is called once per frame

    private void Start()
    {
        start = transform.localPosition;
    }
    void Update()
    {
        if (balls == true)
        {
            float stepSize = Time.deltaTime * speed;
            float distanceToTarget = Vector3.Distance(transform.position, end);
            if (distanceToTarget < stepSize)
            {
                return;
            }
            Vector3 moveDir = end - transform.position;
            transform.position += (moveDir * stepSize);
        }
        else
        {
            float stepSize = Time.deltaTime * speed;
            float distanceToTarget = Vector3.Distance(transform.position, start);
            if (distanceToTarget < stepSize)
            {
                return;
            }
            Vector3 moveDir = start - transform.position;
            transform.position += (moveDir * stepSize);
        }
    }
}
