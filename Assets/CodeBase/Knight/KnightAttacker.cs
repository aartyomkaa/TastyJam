using System.Collections.Generic;
using CodeBase.ThrowableObjects.Objects.EquipableObject.Weapon;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightAttacker : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;

        private Weapon _currentWeapon;

        private void Awake()
        {
            EquipFists();
        }

        public void Attack(Transform target)
        {
            if (_currentWeapon.CurrentDurability == 0)
                EquipFists();
            
            Vector2 attackDirection = Vector2.right;

            if (target.position.x < transform.position.x)
                attackDirection = Vector2.left;
            
            _currentWeapon.Attack(transform.position, attackDirection);
        }

        public void Equip(Weapon weapon)
        {
            Debug.Log("equping");
            
            _currentWeapon.gameObject.SetActive(false);
            
            foreach (var stashed in _weapons)
            {
                if (stashed == weapon)
                {
                    _currentWeapon = stashed;
                    _currentWeapon.gameObject.SetActive(true);
                    _currentWeapon.CurrentDurability = _currentWeapon.MaxDurability;
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
                }
            }
        }
    }
}