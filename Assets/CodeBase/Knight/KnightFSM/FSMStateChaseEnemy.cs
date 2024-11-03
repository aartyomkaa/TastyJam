using CodeBase.Infrastructure.States;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Knight.KnightFSM
{
    public class FSMStateChaseEnemy : IFsmState
    {
        private readonly KnightStateMachine _knightStateMachine;
        private readonly KnightMover _movement;
        private readonly Animator _animator;
        private readonly KnightStaticData _data;

        public FSMStateChaseEnemy(KnightStateMachine knightStateMachine, KnightMover movement, Animator animator, KnightStaticData data)
        {
            _knightStateMachine = knightStateMachine;
            _movement = movement;
            _animator = animator;
            _data = data;
        }

        public void Enter()
        {
        }

        public void Update()
        {
            _movement.Move(_knightStateMachine.Target.Transform);
            
            if (_knightStateMachine.Target == null)
                return;
            
            if (Vector2.Distance(_movement.transform.position, _knightStateMachine.Target.Transform.position) < _data.AttackRange)
            {
                _knightStateMachine.SetState<FSMStateAttack>();
            }
        }

        public void Exit()
        {

        }
    }
}