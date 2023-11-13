using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshController : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;

    public List<Animator> animator;
    public bool isWalking = true;
    public bool ATTACK = false;


    public GameObject eyes;
    public float runSpeed = 1;
    public float steeringSpeed = 100;
    public float lookSpeed = 100;
    private Vector3 targetDirection;
    private Vector3 newDirection;
    // Start is called before the first frame update
    void Start()
    {
        targetDirection = GameObject.FindGameObjectWithTag("Targetme").transform.position - transform.position;
        agent = GetComponent<NavMeshAgent>();

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
            anim.SetBool("ATTACK", ATTACK);

            anim.speed = runSpeed*0.7f;
        }

        agent.speed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isWalking)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        }

        foreach (Animator anim in animator)
        {
            anim.SetBool("isWalking", isWalking);
            anim.SetBool("ATTACK", ATTACK);
        }

        if (ATTACK)
        {
            float stepSize = lookSpeed * Time.deltaTime;

            Vector3 targetDir = GameObject.FindGameObjectWithTag("Targetme").transform.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
        }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject==target)
        {
            isWalking = false;
            ATTACK = true;
        }
	}

	private void OnTriggerExit(Collider other)
	{
        if (other.gameObject == target)
        {
            ATTACK = true;
            isWalking = true;

        }

    }
}
