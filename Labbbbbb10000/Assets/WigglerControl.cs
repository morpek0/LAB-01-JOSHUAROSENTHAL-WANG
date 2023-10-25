using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WigglerControl : MonoBehaviour
{
    public Vector3 target;
    private NavMeshAgent agent;

    public float runSpeed = 1.0f;
    public float steeringSpeed = 100;
    public float lookSpeed = 5;


    public float looktime = 0.5f;
    public float looktimer = 0;

    public float teleportTime = 0.5f;
    public float teleportTimere = 0;

    public bool turning = true;
    public bool waiting = false;

    public GameObject[] teleportpoints;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (looktimer > looktime)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.transform.forward, out hit))
            {
                agent.destination = hit.point; 
                
                waiting = true;
            }
            if (looktimer > looktime +0.01f)
            {
                looktimer = 0;
                turning = false; waiting = false;
            }
            
        }
        if (turning&&!waiting)
            {
                float stepSize = lookSpeed * Time.deltaTime;

                Vector3 targetDir = GameObject.FindGameObjectWithTag("Targetme").transform.position - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);

                transform.rotation = Quaternion.LookRotation(newDir);

                
            
            }
        else if (!waiting)
        {
            if (agent.velocity == Vector3.zero)
            {
                // become invisible for teleportation and teleport (wait a bit before re-appearing)
                waiting = true; 
                for (int i = 0; i<transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false; ;
                }
                GameObject teleportal = teleportpoints[Random.Range(0, teleportpoints.Length)];
                transform.position = teleportal.transform.position;
                transform.rotation = teleportal.transform.rotation;
                agent.destination = transform.position;
                
            }
        }
        if (turning)
        {
            looktimer += Time.deltaTime;
        }

        if (waiting) //this is where the counter counts to see how long the invisibility was to let it reappear after a bit of time
        {

            teleportTime += Time.deltaTime;

            if (teleportTime > teleportTimere)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true ;
                }
                turning = true; waiting = false;
                teleportTime = 0;
            }
        }
        

        
    }


}
