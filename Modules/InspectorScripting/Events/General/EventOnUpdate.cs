using UnityEngine;
using UnityEngine.Events;
public class EventOnUpdate : MonoBehaviour
{
    public UnityEvent OnUpdate;

    public void Update(){
        OnUpdate.Invoke();
    }
}
