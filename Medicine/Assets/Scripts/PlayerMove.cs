using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMove : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float moveSpeed = 5f;
    public CharacterController characterController;

    //public SteamVR_Action_Boolean openMenu;
    //public GameObject canves;

    private void Update()
    {
        if(characterController != null)
        {
            if (input.axis.magnitude > 0.1f)
            {
                Vector3 dir = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
                //transform.position += moveSpeed * Time.deltaTime * Vector3.ProjectOnPlane(dir, Vector3.up);
                characterController.Move(moveSpeed * Time.deltaTime * Vector3.ProjectOnPlane(dir, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
            }
        }

        //if (openMenu.stateDown)
        //{
        //    if (canves.activeInHierarchy)
        //    {
        //        canves.SetActive(false);
        //    }
        //    else
        //    {
        //        canves.SetActive(true);
        //    }
        //}
    }
}
