using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _minHealth = 0;

    private float _currentHealth;

    public event Action<float> ChangedHealth;

    public float Health => _maxHealth;

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        
        ChangedHealth?.Invoke(CurrentHealth);
    }

    public void Heal(float heal)
    {
        CurrentHealth += heal;

        ChangedHealth?.Invoke(CurrentHealth);
    }

    private float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, _minHealth, _maxHealth); }
    } 
}
