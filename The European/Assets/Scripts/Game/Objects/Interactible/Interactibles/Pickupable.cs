using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactible {

    Rigidbody pickupable_rigidbody;
    public float forward_offset, upward_offset;

    private void Start()
    {
        pickupable_rigidbody = GetComponent<Rigidbody>();
    }

    public override void Interact(Character_State _interactor)
    {
        base.Interact(_interactor);
        if(pickupable_rigidbody == null)
        {
            pickupable_rigidbody = GetComponent<Rigidbody>();
        }
        if(pickupable_rigidbody != null && interactor != null)
        {
            SendMessage("Picked_Up", SendMessageOptions.DontRequireReceiver);
            pickupable_rigidbody.isKinematic = true;
            transform.SetParent(interactor.gameObject.transform);
            transform.position = interactor.Get_Hold_Point();
            transform.rotation = interactor.transform.rotation;
            
        }
    }

    public override void Stop_Interacting()
    {
        base.Stop_Interacting();
        if (pickupable_rigidbody == null)
        {
            pickupable_rigidbody = GetComponent<Rigidbody>();
        }
        if (pickupable_rigidbody != null)
        {
            pickupable_rigidbody.isKinematic = false;
            transform.SetParent(null);
        }
    }
}
