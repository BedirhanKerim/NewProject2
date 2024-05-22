using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{

    
 

    private void OnTriggerEnter(Collider other)
    {
        var   interactable=  other.transform.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact();
        }    }
}
