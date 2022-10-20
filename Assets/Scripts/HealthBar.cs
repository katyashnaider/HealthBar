using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private Coroutine _coroutine;
    private float _stepSpeed = .1f;

    private void OnEnable()
    {
        _player.ChangedHealth += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnHealthChanged;
    }

    private IEnumerator ChangeSlider(float targetHealth)
    {
        targetHealth /= _player.Health;

        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _stepSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnHealthChanged(float health)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeSlider(health));
    }
}
