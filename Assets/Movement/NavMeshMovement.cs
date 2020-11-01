using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Valve.VR;

public class NavMeshMovement : MonoBehaviour
{
    [SerializeField] private Transform  _hmdTransform;
    [SerializeField] private GameObject  head;
    private NavMeshAgent agent;
    public float speed;
    public bool DisableSideWayMovement;    
    private Vector3 BodyDirection;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = true;
        
    }

    private void FixedUpdate()
    {
        head.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Quaternion targetRot = Quaternion.LookRotation(_hmdTransform.forward);
        Vector3 eulerRotation = new Vector3();
        
        eulerRotation= Vector3.ProjectOnPlane(targetRot.eulerAngles, Vector3.forward);
        eulerRotation.x = 0f;
        targetRot = Quaternion.Euler(eulerRotation);


        this.transform.rotation = targetRot;
        
        
        agent.angularSpeed = 300;
        
    }

    public void Move(Vector2 direction)
    {
        BodyDirection = new Vector3( direction.x,0f,direction.y  );
        BodyDirection =  this.transform.rotation* BodyDirection;
        Debug.Log("body" + BodyDirection);
        Debug.Log("head" + direction);
        MoveInToDirection(BodyDirection);
    }

    private void MoveInToDirection(Vector3 direction)
    {
        
        agent.Move(Time.deltaTime*speed*direction);
       
    }
    
    
    
}
