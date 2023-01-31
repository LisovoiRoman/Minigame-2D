using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : Bar
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnValueChanged;
    }
}
