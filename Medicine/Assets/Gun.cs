using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Gun : MonoBehaviour
{
    public GameObject bulletPref;
    public Transform firePoint;
    public float bulletSpeed = 5f;

    public SteamVR_Action_Boolean fireAction;
    public Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if(interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources sources = interactable.attachedToHand.handType;
            if (fireAction[sources].stateDown)
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, 3f);
    }
}
