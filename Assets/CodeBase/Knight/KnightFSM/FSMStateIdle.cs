using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using CodeBase.Logic.Utilities;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Knight.KnightFSM
{
    public class FSMStateIdle : IFsmState
    {
        private readonly KnightStateMachine _knightStateMachine;
        private readonly KnightMover _movement;
        private ClosestTargetFinder _targetFinder;
        
        public FSMStateIdle(KnightStateMachine knightStateMachine, KnightMover movement, KnightStaticData data)
        {
            _knightStateMachine = knightStateMachine;
            _movement = movement;
            _targetFinder = new ClosestTargetFinder(data.AggroRange, data.Enemy);
        }

        public void Enter()
        {
        }

        public void Update()
        {
            if (_targetFinder.TryFindTarget(_movement.gameObject.transform.position, out IHealth target))
            {
                _knightStateMachine.SetTarget(target);
                _knightStateMachine.SetState<FSMStateChaseEnemy>();
            }
        }

        public void Exit()
        {
        }
    }
}