using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_Drawer : Interactible {
    Vector3 initial_position;
    public float max_distance_to_pull, distance_from_interactor, stop_distance;
    bool being_pulled;

    private void Start()
    {
        initial_position = this.transform.position;
    }

    private void Update()
    {
        if(being_pulled == true)
        {
            if(this.transform.position.z < initial_position.z)
            {
                this.transform.position = initial_position;
            }
            Vector3 position = this.transform.position;
            float distance = Vector3.Distance(this.transform.position, initial_position);
            if(interactor.transform.position.z - distance_from_interactor > max_distance_to_pull)
            {
                position.z = interactor.transform.position.z - distance_from_interactor;
            }
            else
            {
                position.z = max_distance_to_pull;
            }
            this.transform.position = position;

            float distance_to_player = Vector3.Distance(this.transform.position, interactor.transform.position);
            if(distance_to_player > stop_distance)
            {
                Stop_Interacting();
            }
        }
    }

    public override void Interact(Character_State _interactor)
    {
        base.Interact(_interactor);
        being_pulled = !being_pulled;
    }

    public override void Stop_Interacting()
    {
        base.Stop_Interacting();
        being_pulled = false;
    }

    void Set_Distance_To_Max()
    {
        Vector3 position = this.transform.position;
    }
}
