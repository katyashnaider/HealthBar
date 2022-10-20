using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private float _maxHealth = 100;
    private float _minHealth = 0;
    private float _currentHealth;

    public event Action<float> ChangedHealth;

    public float Health => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
   
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = CheckingValue();
        
        ChangedHealth?.Invoke(_currentHealth);
    }

    public void Heal(float heal)
    {
        _currentHealth += heal;
        _currentHealth = CheckingValue();

        ChangedHealth?.Invoke(_currentHealth);
    }

    private float CheckingValue()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

        return _currentHealth;
    }
}
