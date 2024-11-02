using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightMover : MonoBehaviour
    {
        public void Move(Transform target)
        {
            transform.Translate(transform.position);
        }
    }
}