using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerAim : MonoBehaviour
    {
        private Vector2 _cursorCoords;

        public Vector2 CurrentCoords => _cursorCoords;

        private void Awake()
        {
            _cursorCoords = Vector2.zero;
        }

        public void UpdateAimCoords(Vector2 newCoords)
        {
            _cursorCoords = newCoords;
        }
    }
}
