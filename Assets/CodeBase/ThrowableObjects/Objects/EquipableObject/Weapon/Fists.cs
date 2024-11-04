using UnityEngine;

namespace CodeBase.ThrowableObjects.Objects.EquipableObject.Weapon
{
    public class Fists : Weapon
    {
        internal override Collider2D[] FindTargets(Vector2 attackerPosition, Vector2 attackDirection, LayerMask mask)
        {
            Vector2 scale = new(_attackArea.localScale.x * transform.localScale.x, _attackArea.localScale.y * transform.localScale.y);
            Vector2 attackPoint = attackerPosition + attackDirection.normalized * scale.x / 2;
            return Physics2D.OverlapBoxAll(attackPoint, scale, 0, mask);;
        }
        internal override void CalcDurability()
        {
            return;
        }
    }
}