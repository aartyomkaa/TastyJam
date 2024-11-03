using UnityEngine;

public class MeleeEnemyController : EnemyController
{
    private int _hp;
    private int _maxHp = 100;
    private int _dmg = 35;
    private float _cooldown = 0.85f;
    private float _damageRange = 0.9f;
    private float _speed = 0.7f;
    private float _visibilityRange = 0.8f;

    public EnemyMover mover = null;
    public EnemyMeleeAttacker attacker = null;

    private void Start()
    {
        _hp = _maxHp;

        mover = gameObject.AddComponent<EnemyMover>();
        attacker = gameObject.AddComponent<EnemyMeleeAttacker>();
        mover.StartAttacking += StartAttacking;
        attacker.StartMoving += StartMoving;

        StartCoroutine(mover.MovingToKnight(_speed, _visibilityRange));
    }
    private void StartAttacking() => StartCoroutine(attacker.Attack(_dmg, _cooldown, _damageRange));
    private void StartMoving() => StartCoroutine(mover.MovingToKnight(_speed, _visibilityRange));

    public void DealDmg(int value)
    {
        _hp -= value;
        if (_hp <= 0)
        {
            //animation
            gameObject.SetActive(false);
        }
    }

}