using CodeBase.ThrowableObjects.Objects.EquipableObject.Weapon;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightPickupObjects : MonoBehaviour
    {
        private CircleCollider2D _collider;
        private KnightAttacker _knightAttacker;

        public void Construct(float pickupRadius, KnightAttacker attacker)
        {
            _collider.radius = pickupRadius;
            _knightAttacker = attacker;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IEquippableObject>(out IEquippableObject pickup))
            {
                pickup.Equip(transform.position);
                
                if (pickup is Weapon weapon)
                {
                    _knightAttacker.Equip(weapon);
                }
            }
        }
    }
}