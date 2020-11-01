using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using Valve.VR;

public class MovementInput : MonoBehaviour
{
    public bool DisableSideWayMovement;
    
    public SteamVR_ActionSet actionSetEnable;
    public SteamVR_Action_Vector2 Input;

    private NavMeshMovement Mover;
    // Start is called before the first frame update
    void Start()
    {
        actionSetEnable.Activate();
        Mover = GetComponent<NavMeshMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Movement = Input.GetAxis(SteamVR_Input_Sources.Any);
        
        if (DisableSideWayMovement)
        {
            Movement.x = 0;
        }
        
        Mover.Move(Movement);
        
       

        
    }
}
