using System;
using CodeBase.Knight.KnightFSM;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightDefender : MonoBehaviour, IHealth
    {
        private KnightStateMachine _stateMachine;
        public float Current { get; set; }
        public float Max { get; set; }
        public Transform Transform => transform;

        public event Action HealthChanged;

        public void Construct(KnightStateMachine stateMachine, float health)
        {
            _stateMachine = stateMachine;

            Max = health;
            Current = Max;
        }

        private void Update()
        {
            _stateMachine.Update();
        }
        
        public void TakeDamage(float damage)
        {
            Current -= damage;

            if (Current <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}