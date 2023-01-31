using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CurrentWeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Image _icon;

    private static CurrentWeaponView _instance;

    public static CurrentWeaponView Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void Render(Weapon weapon)
    {
        _label.text = weapon.Label;
        _icon.sprite = weapon.Icon;
    }
}
