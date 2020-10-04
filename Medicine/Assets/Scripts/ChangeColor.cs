using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ChangeColor : MonoBehaviour
{
    public Interactable interactable;
    public bool isGrabEnding;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }

    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabTypes = hand.GetGrabStarting();
        isGrabEnding = hand.IsGrabEnding(gameObject);
        if(interactable.attachedToHand == null && grabTypes != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabTypes);
        }
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
        }
    }
}
