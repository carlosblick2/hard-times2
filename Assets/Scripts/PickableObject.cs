using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool IsPickable = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (IsPickable && other.tag == "PlayerInteractionZone")
        {
            PickUpObject pickUpScript = other.GetComponentInParent<PickUpObject>();
            if (pickUpScript != null)
            {
                pickUpScript.ObjecToPickUp = this.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            PickUpObject pickUpScript = other.GetComponentInParent<PickUpObject>();
            if (pickUpScript != null)
            {
                pickUpScript.ObjecToPickUp = null;
            }
        }
    }
}
