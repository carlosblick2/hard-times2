using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjecToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone; // 'transform' should be lowercase

    void Update()
    {
        if (ObjecToPickUp != null && ObjecToPickUp.GetComponent<PickableObject>().IsPickable == true && PickedObject == null) // 'isPickable' should be 'IsPickable'
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjecToPickUp;
                PickedObject.GetComponent<PickableObject>().IsPickable = false; // 'isPickable' should be 'IsPickable'
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.position; // 'tranform' should be 'transform'
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true; // 'IsKinematic' should be 'isKinematic'
            }
        }

        else if (PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {   
                PickedObject.GetComponent<PickableObject>().IsPickable = true; // 'isPickable' should be 'IsPickable'
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false; // 'IsKinematic' should be 'isKinematic'
                PickedObject = null;
            }
        }
    }
}
