using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int numberOfSticks = 0;

    public void AddItem(GameObject item)
    {
        numberOfSticks++;
    }

    public int GetInventory()
    {
        int tempSticks = numberOfSticks;
        numberOfSticks = 0;
        return tempSticks;
    }
}
