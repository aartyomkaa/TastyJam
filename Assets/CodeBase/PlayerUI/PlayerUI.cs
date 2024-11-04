using CodeBase.Knight;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private KnightDefender _knight;
    void Start()
    {
        _knight.HealthChanged += FillBar;
    }

    void FillBar()
    {
        _sprite.fillAmount = _knight.Current / _knight.Max;
    }
}
