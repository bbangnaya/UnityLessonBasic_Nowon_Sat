using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("ItemTrigger")) 
        {
            if (Input.GetKey(KeyCode.Z))
            {
                other.gameObject.GetComponentInParent<ItemController>().PickUp(this);
            }
        }
    }
}
