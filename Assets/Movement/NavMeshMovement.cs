using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            agent.Move(Vector3.forward);;
        }
    }



    public void MoveDirection(Vector3 direction)
    {
        agent.Move(Time.deltaTime*speed*direction);
    }
    
}
