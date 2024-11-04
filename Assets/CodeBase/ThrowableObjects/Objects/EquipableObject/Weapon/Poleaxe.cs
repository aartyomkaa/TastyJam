using UnityEngine;

namespace CodeBase.ThrowableObjects.Objects.EquipableObject.Weapon
{
    public class Poleaxe : Weapon
    {
        internal override Collider2D[] FindTargets(Vector2 attackerPosition, Vector2 attackDirection, LayerMask mask)
        {
            return Physics2D.OverlapCircleAll(attackerPosition, _attackArea.localScale.x * transform.localScale.x, mask);
        }
    }
}