using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpace : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameManager.Instance.GameFinish(false);
        
    }
}