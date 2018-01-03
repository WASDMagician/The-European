using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket_Ball : Pickupable {

    public float throw_force, rotate_amount;

    public override void Stop_Interacting()
    {
        this.transform.Rotate(this.transform.forward, rotate_amount);
        base.Stop_Interacting();
        pickupable_rigidbody.AddForce(this.transform.forward * throw_force, ForceMode.Impulse);

    }
}
