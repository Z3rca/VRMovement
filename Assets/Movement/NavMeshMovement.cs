using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Valve.VR;

public class NavMeshMovement : MonoBehaviour
{
    [SerializeField] private Transform  _hmdTransform;
    private Rigidbody _rigidBody;
    [SerializeField] private GameObject  head;
    private SteamVR_Input_Sources hand;
    private NavMeshAgent agent;
    public SteamVR_Action_Vector2 moveAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("platformer", "Move");
    public float speed;
    public bool DisableSideWayMovement;    
    private Vector3 MovementDirection;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _rigidBody = GetComponent<Rigidbody>();
        //agent.updateRotation = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //agent.updatePosition = false;
        //agent.updateRotation = false;
        
        Quaternion targetRot = Quaternion.LookRotation(_hmdTransform.forward);
        Vector3 eulerRotation = new Vector3();

       
        
        eulerRotation= Vector3.ProjectOnPlane(targetRot.eulerAngles, Vector3.forward);
        eulerRotation.x = 0f;
        targetRot = Quaternion.Euler(eulerRotation);


        this.transform.rotation = targetRot;
        
        
        
        Vector2 m = moveAction[hand].axis;


        if (DisableSideWayMovement)
        {
            m.x = 0;
        }
        
        // rotate towards a vector
     
        //Debug.Log("input" + m);
        agent.angularSpeed = 300;
        //agent.updateRotation = false;



        
        MovementDirection = new Vector3( m.x,0f,m.y  );
            
        MovementDirection =  transform.rotation* MovementDirection;
        //MovementDirection = MovementDirection * 90; 

        //MovementDirection = MovementDirection + eulerRotation;
        
        //Debug.Log("movement" + MovementDirection);
        
        //Debug.Log("this rotation"+ this.transform.rotation);
        {
        }
        
        
        
        
       // Debug.Log("movement" + MovementDirection);
        
        
        Move(MovementDirection);
        
        
       
    }



    public void Move(Vector3 direction)
    {
        agent.Move(Time.deltaTime*speed*direction);
        head.transform.position = this.transform.position;
    }
    
}
