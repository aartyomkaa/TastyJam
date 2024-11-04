using System.Collections;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightAttacker : MonoBehaviour
    {
        private bool _isOnCooldown = false;
        private float _attackCooldown;
        private float _damage;
        private float _radius;
        private LayerMask _mask;
        private Collider2D[] _hitColliders;

        public void Construct(float damage, float radius, float attackCooldown, LayerMask mask)
        {
            _damage = damage;
            _radius = radius;
            _attackCooldown = attackCooldown;
            _mask = mask;
        }

        public void Attack()
        {
            if (_isOnCooldown)
                return;
            
            _hitColliders = Physics2D.OverlapCircleAll(transform.position, _radius, _mask);
            
            if (_hitColliders.Length > 0)
            {
                foreach (var hit in _hitColliders)
                {
                    hit.TryGetComponent<IHealth>(out IHealth enemy);
            
                    enemy.TakeDamage(_damage);
                }
                
                StartCoroutine(AttackCoroutine());
            }
        }

        private IEnumerator AttackCoroutine()
        {
            _isOnCooldown = true;

            yield return new WaitForSeconds(_attackCooldown);

            _isOnCooldown = false;
        }
    }
}