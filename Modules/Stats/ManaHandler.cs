using UnityEngine;
using UnityEngine.Events;
public class ManaHandler : MonoBehaviour
{
    private float Mana;
    private float MaxMana;
    public UnityEvent OnGetMana;
    public UnityEvent OnGetMaxMana;
    public UnityEvent OnSetMaxMana;
    public UnityEvent OnTakeMana;
    public UnityEvent OnGiveMana;

    public float GetMana()
    {
        OnGetMana.Invoke();
        return Mana;
    }
    public float GetMaxMana()
    {
        OnGetMaxMana.Invoke();
        return MaxMana;
    }
    public void SetMaxMana(int ammount)
    {
        OnSetMaxMana.Invoke();
        MaxMana = ammount;
    }
    public void TakeMana(int ammount)
    {
        OnTakeMana.Invoke();
        Mana -= ammount;
    }
    public void GiveMana(int ammount)
    {
        OnGiveMana.Invoke();
        Mana += ammount;
    }
}
