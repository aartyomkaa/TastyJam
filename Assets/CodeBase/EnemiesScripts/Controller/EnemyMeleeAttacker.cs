using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttacker : MonoBehaviour
{
    public delegate void Empty();
    public event Empty StartMoving;
    private int _playerLayer = 1;

    public IEnumerator Attack(int enemyDmg, float enemyCooldown, float enemyDamageRange)
    {
        yield return new WaitForSeconds(enemyCooldown);
        Collider2D hit = Physics2D.OverlapCircle(transform.position, enemyDamageRange, _playerLayer);
        if (hit != null)
        {
            //deal dmg
        }
        StartMoving.Invoke();
    }
}
