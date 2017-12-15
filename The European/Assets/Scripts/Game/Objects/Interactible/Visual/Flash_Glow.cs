using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flash_Glow : MonoBehaviour {

    public Color flash_color;
    Color initial_color;
    public float speed;
    MeshRenderer renderer;
    Tween tween;
    bool can_run = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.GetComponent<Character_Controller>() != null && can_run == true)
        {
            renderer = this.GetComponent<MeshRenderer>();
            initial_color = renderer.material.color;
            tween = renderer.material.DOColor(flash_color, speed).SetLoops(-1, LoopType.Yoyo);
        }
        else if(other.GetComponent<Phys_Obj_Trigger>() != null)
        {
            can_run = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tween.Kill();
        tween = renderer.material.DOColor(initial_color, speed).SetLoops(1);
    }
}
