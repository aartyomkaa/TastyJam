using CodeBase.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.ThrowableObjects.Objects.EquipableObject.Weapon
{
    public abstract class Weapon : EquipableObject
    {
        [SerializeField] internal Transform _attackArea;
        [SerializeField] internal float _damage;
        [SerializeField] internal float _durability;

        internal readonly float _durabilityChangeStep = 1f;

        public float CurrentDurability { get; set; }

        internal abstract Collider2D[] FindTargets(Vector2 attackerPosition, Vector2 attackDirection);

        internal virtual void CalcDurability()
        {
            CurrentDurability -= _durabilityChangeStep;
            if (CurrentDurability <= 0)
            {
                Debug.Log("weapon broken");
            }
        }

        public bool Attack(Vector2 attackerPosition, Vector2 attackDirection)
        {
            bool attackPerformed = false;
            var raycastHit = FindTargets(attackerPosition, attackDirection);

            if (raycastHit.Length > 0)
            {
                foreach (var hit in raycastHit)
                {
                    if (hit.gameObject.TryGetComponent<IHealth>(out var enemy))
                    {
                        Debug.Log($"{hit.gameObject.name} took {_damage} damage");
                        enemy.TakeDamage(_damage);
                        attackPerformed = true;
                    }
                }
            }

            if (attackPerformed)
            {
                CalcDurability();
            }

            return attackPerformed;
        }

        private void Awake()
        {
            CurrentDurability = _durability;
        }

        private void OnEnable()
        {
            CurrentDurability = _durability;
        }

        private void Start()
        {
            StartCoroutine(LoopAttack());
        }

        private IEnumerator LoopAttack()
        {
            while (true)
            {
                Attack(transform.position, Vector2.right);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}