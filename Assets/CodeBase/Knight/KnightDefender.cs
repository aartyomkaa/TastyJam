using CodeBase.Knight.KnightFSM;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightDefender : MonoBehaviour
    {
        private KnightStateMachine _stateMachine;

        public void Construct(KnightStateMachine stateMachine) => 
            _stateMachine = stateMachine;
        
        private void Update()
        {
            _stateMachine.Update();
        }
    }
}