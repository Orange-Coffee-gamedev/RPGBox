using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPGBM_Inventory : MonoBehaviour
{
    [SerializeField] private List<Inventory_Item> items;
    
    [SerializeField] private bool isContainer;

    // UnityEvents
    public UnityEvent onItemUsed;
    public UnityEvent onItemAdded;
    public UnityEvent onItemRemoved;

    // Other variables and methods...

}
