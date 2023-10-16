using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField]
    public bool isMenu = false;
    public PathManager pathManager;
    public MenuState menuState;

    List<Waypoint> thePath;
    Waypoint target;

    public float MoveSpeed;
    public float RotateSpeed;

    public List<Animator> animator;
    public bool isWalking = true;

    void Start()
    {
        if (!isMenu)
        {
            for (int i = 0; i < this.transform.childCount; i++)
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
        Vector3 targetDir;
        Quaternion targetDirr;
        if (isMenu)
        {
            targetDirr = Quaternion.LookRotation(pathManager.GetMenuStateLookTarget().transform.position-target.pos);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetDirr, stepSize);
        }
        else
        {
            targetDir = target.pos - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        }
            
            

    }
    void moveForward() 
    { 
        float stepSize = Time.deltaTime* MoveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if (distanceToTarget < stepSize)
        {
            return;
        }
        Vector3 moveDir = target.pos-transform.position;
        transform.position+=(moveDir * stepSize);
    }

    void Update()
    {
        if (!isMenu)
        {
            if (Input.anyKeyDown)
        {
            isWalking = !isWalking;

        }
        
            foreach (Animator anim in animator)
            {
                anim.SetBool("isWalking", isWalking);
            }
        }
        else
        {
            if (target != pathManager.GetMenuStateTarget())
            {
                Debug.Log("WAAAAAAAAAAA");
                target = pathManager.GetMenuStateTarget();
            }
        }
        if (isWalking)
        {
            rotateTowardsTarget();
            moveForward();
        }
    }

 /*   private void OnTriggerEnter(Collider other)
    {
        if (!isMenu)
        {
            target = pathManager.GetNextTarget();
            isWalking = !isWalking;
        }
    }*/


}
