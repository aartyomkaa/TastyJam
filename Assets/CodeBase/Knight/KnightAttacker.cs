using System.Collections.Generic;
using CodeBase.Logic.Utilities;
using CodeBase.ThrowableObjects.Objects.EquipableObject.Weapon;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightAttacker : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private KnightAnimationsController _animator;

        private Weapon _currentWeapon;
        private HorizontalDirection _horizontalDirection;

        private void Start()
        {
            EquipFists();
            _horizontalDirection = HorizontalDirection.Right;
        }

        public void Attack(Transform target)
        {
            if (_currentWeapon.CurrentDurability == 0)
                EquipFists();
            
            Vector2 attackDirection = transform.position - target.transform.position;
            
            if (attackDirection.x > 0 && _horizontalDirection != HorizontalDirection.Right)
            {
                _horizontalDirection = HorizontalDirection.Right;
                _animator.Turn();
            }
            else if (attackDirection.x < 0 && _horizontalDirection != HorizontalDirection.Left)
            {
                _horizontalDirection = HorizontalDirection.Left;
                _animator.Turn();
            }
            
            _animator.Attack();
            _currentWeapon.Attack(transform.position, attackDirection);
        }

        public void Equip(Weapon weapon)
        {
            Debug.Log("equping");
            Debug.Log(weapon.GetType());
            
            _currentWeapon.gameObject.SetActive(false);
            
            foreach (var stashed in _weapons)
            {
                if (stashed.GetType() == weapon.GetType())
                {
                    _currentWeapon = stashed;
                    _currentWeapon.gameObject.SetActive(true);
                    _currentWeapon.CurrentDurability = _currentWeapon.MaxDurability;

                    if (_currentWeapon is Sword)
                    {
                        _animator.SetSwordSkin();
                    }
                    else
                    {
                        _animator.SetPoleaxeSkin();
                    }
                }
            }
            
            Debug.Log(_currentWeapon);
        }

        private void EquipFists()
        {
            foreach (var weapon in _weapons)
            {
                if (weapon is Fists)
                {
                    _currentWeapon = weapon;
                    _currentWeapon.gameObject.SetActive(true);
                    _animator.SetMeleeSkin();
                }
            }
        }
    }
}