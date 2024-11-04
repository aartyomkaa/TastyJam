using CodeBase.Logic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.ThrowableObjects.Objects.EquipableObject.Weapon
{
    public class Sword : Weapon
    {
        internal override Collider2D[] FindTargets(Vector2 attackerPosition, Vector2 attackDirection)
        {
            Vector2 scale = new(_attackArea.localScale.x * transform.localScale.x, _attackArea.localScale.y * transform.localScale.y);
            Vector2 attackPoint = attackerPosition + attackDirection.normalized * scale.x / 2;
            var raycastHit = Physics2D.OverlapBoxAll(attackPoint, scale, 0);
            return raycastHit;
        }
    }
}