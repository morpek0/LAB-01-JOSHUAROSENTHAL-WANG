using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class SheepControl : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject player;
    public bool isWalking = true;
    public bool grazing = false;
    public bool isBaby = false;

    public GameObject tail;

    public float searchRange;
    public float tooClose;

    public float grazeTimer=0;
    public float timePerGraze = 3f;

    public float rotSpeed;
    public float minRot;
    public float maxRot;
    public float minStep;
    public float maxStep;

    private Vector3 targetDirection;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Targetme");
        targetDirection = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - agent.transform.position).magnitude < tooClose|| !player.GetComponent<ShepherdControl>().wheat.activeSelf || !((player.transform.position - agent.transform.position).magnitude < searchRange))
        {
            if (grazing == false)
            {
                grazing = true;
                isWalking = false;
                agent.destination = agent.transform.position;
            }
        }
        else 
        {
            
            grazing = false;
            agent.updateRotation = true;
            isWalking = true;
        }

        if (isWalking)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            float newRot = 0f;
            grazeTimer += Time.deltaTime;
            if (grazeTimer < timePerGraze)
            {
                
            }
            else
            {
                int decision;
                if (isBaby)
                {
                    Debug.Log("Baby success perhaps?");
                    decision = Random.Range(0, 5);
                }
                else
                {
                    decision = Random.Range(0, 3);
                }
                
                switch (decision)
                {
                    case 0:
                        if (Random.Range(0, 2) == 0)
                        {
                            newRot = Random.Range(minRot, maxRot);
                            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y + newRot, transform.rotation.z, transform.rotation.w), rotSpeed);
                        }
                        else
                        {
                            newRot = Random.Range(minRot, maxRot)*-1;
                            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y + newRot, transform.rotation.z, transform.rotation.w), rotSpeed);
                        }
                        break;
                    case 1:;
                        agent.updateRotation = true;
                        agent.destination = agent.transform.position + agent.transform.forward * Random.Range(minStep, maxStep);
                        break;
                    case 2:
                        Debug.Log("baaaaaa");
                        GetComponent<AudioSource>().Play();
                        break;
                    case 3:
                        Debug.Log("Baby success");
                        agent.destination = transform.parent.GetComponent<SheepControl>().tail.transform.position;
                        break;
                    case 4:
                        Debug.Log("Baby success");
                        agent.destination = transform.parent.GetComponent<SheepControl>().tail.transform.position;
                        break;
                }
                grazeTimer = 0;
            }

            
        }
    }

    
}
