using UnityEngine;
using UnityEngine.Events;
public class HealthHandler : MonoBehaviour
{
    [SerializeField]
    private float Health;
    [SerializeField]
    private float MaxHealth;
    [Header("Events")]
    public UnityEvent OnGetHealth;
    public UnityEvent OnGetMaxHealth;
    public UnityEvent OnSetMaxHealth;
    public UnityEvent OnDamage;
    public UnityEvent OnHeal;
    public UnityEvent OnDeath;
    public UnityEvent OnHealthChanged;

    public void Death()
    {
        OnDeath.Invoke();
    }

    /// <summary>
    /// Returns the current Health.
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        OnGetHealth.Invoke();
        HealthChanged();
        return Health;
    }
    /// <summary>
    /// Returns the current Max Health.
    /// </summary>
    /// <returns></returns>
    public float GetMaxHealth()
    {
        OnGetMaxHealth.Invoke();
        HealthChanged();
        return MaxHealth;
    }
    /// <summary>
    /// Sets the current Max Health to a new ammount.
    /// </summary>
    /// <param name="ammount"></param>
    public void SetMaxHealth(float ammount)
    {
        OnSetMaxHealth.Invoke();
        MaxHealth = ammount;
        HealthChanged();
    }
    /// <summary>
    /// Damages the current Health.
    /// </summary>
    /// <param name="ammount"></param>
    public void Damage(float ammount)
    {
        OnDamage.Invoke();
        Health -= ammount;
        HealthChanged();
    }
    private void HealthChanged()
    {
        OnHealthChanged.Invoke();
        if(Health <= 0)
        {
            Death();
        }
    }

    /// <summary>
    /// Heals the current Health.
    /// </summary>
    /// <param name="ammount"></param>
    public void Heal(float ammount)
    {
        OnHeal.Invoke();
        Health += ammount;
        HealthChanged();
    }
}
