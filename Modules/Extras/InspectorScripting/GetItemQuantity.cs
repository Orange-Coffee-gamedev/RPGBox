using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemQuantity : MonoBehaviour
{
    public int getItemQuantity(Inventory_Item inventory_Item){
        return inventory_Item.GetQuantity();
    }
}
