using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string Name;
    public Sprite Image;
    public string IntText = "Press E to interact";
    public virtual void Interact()
    {

    }
}

public class DepletingItem : InteractableObject
{

}
