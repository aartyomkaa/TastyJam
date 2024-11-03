using System;
using CodeBase.EnemiesScripts.Controller;
using CodeBase.Logic;
using CodeBase.StaticData;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    private EnemyMover _enemyMover;
    private EnemyAttacker _enemyAttacker;
    private Transform _knight;
    private EnemyStaticData _data;
    private float _health;
    
    public event Action HealthChanged;
    public float Current { get; set; }
    public float Max { get; set; }
    public Transform Transform => transform;

    public void Construct(EnemyStaticData data, Transform knight)
    {
        _knight = knight;
        _data = data;
        _health = _data.MaxHp;

        _enemyMover = GetComponent<EnemyMover>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
        
        _enemyMover.Construct(_data.Speed);
        _enemyAttacker.Construct(_data.Damage, _data.AttackCooldown, _data.DamageRange, _data.KnightLayer);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _knight.transform.position) > _data.AttackRange)
        {
            _enemyMover.Move(_knight);
        }
        else
        {
            _enemyAttacker.Attack();
        }
    }
    
    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}