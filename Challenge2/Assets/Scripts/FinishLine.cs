using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameManager.Instance.GameFinish(true);
    }
}