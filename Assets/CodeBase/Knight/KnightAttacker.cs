using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightAttacker : MonoBehaviour
    {
        public void Attack(IHealth target, float damage)
        {
            target.TakeDamage(damage);
        }
    }
}