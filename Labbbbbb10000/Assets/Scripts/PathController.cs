using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField]
    public PathManager pathManager;

    List<Waypoint> thePath;
    Waypoint target;

    public float MoveSpeed;
    public float RotateSpeed;

    public List<Animator> animator;
    public bool isWalking = false;

    void Start()
    {
        for (int i= 0; i<this.transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Animator>() != null)
            {
                animator.Add(transform.GetChild(i).GetComponent<Animator>());
            }
        }
        foreach (Animator anim in animator)
        {
            anim.SetBool("isWalking", isWalking);
        }

        thePath = pathManager.GetPath();
        if (thePath != null && thePath.Count > 0)
        {
            target = thePath[0];
        }
    }

    void rotateTowardsTarget() 
    { 
        float stepSize = RotateSpeed* Time.deltaTime;
        
        Vector3 targetDir = target.pos-transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    void moveForward() 
    { 
        float stepSize = Time.deltaTime* MoveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if (distanceToTarget < stepSize)
        {
            return;
        }
        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            isWalking = !isWalking;

        }
        foreach (Animator anim in animator)
        {
            anim.SetBool("isWalking", isWalking);
        }
        if (isWalking)
        {
            rotateTowardsTarget();
            moveForward();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        target = pathManager.GetNextTarget();
        isWalking = !isWalking;
    }


}
