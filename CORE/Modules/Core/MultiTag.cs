using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
public class MultiTag : MonoBehaviour
{
    [SerializeField]
    private List<string> tags;
    [Space]
    [Header("Events")]
    public UnityEvent OnFoundTag;
    public UnityEvent OnFailedToFindFoundTag;
    public bool HasTag(string tag)
    {
        foreach (string i in tags)
        {
            if (i == tag)
            {
                OnFoundTag.Invoke();
                return true;
            }
        }
        OnFailedToFindFoundTag.Invoke();
        return false;
    }
}
