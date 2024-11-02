using CodeBase.Infrastructure.States;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Knight.KnightFSM
{
    public class FSMStateAttack : IFsmState
    {
        private readonly KnightStateMachine _knightStateMachine;
        private readonly KnightAttacker _attacker;
        private readonly Animator _animator;
        private readonly KnightStaticData _data;
        private float _distance;

        public FSMStateAttack(KnightStateMachine knightStateMachine, KnightAttacker attacker, Animator animator, KnightStaticData data)
        {
            _knightStateMachine = knightStateMachine;
            _attacker = attacker;
            _animator = animator;
            _data = data;
        }

        public void Enter()
        {
        }

        public void Update()
        {
            if (_knightStateMachine.Target != null && _knightStateMachine.Target.Current > 0 &&
                _knightStateMachine.Target.Transform.gameObject.activeSelf)
            {
                if (NeedChaseEnemy())
                {
                    _knightStateMachine.SetState<FSMStateChaseEnemy>();
                }
                else
                {
                    _attacker.Attack(_knightStateMachine.Target, _data.Damage);
                }
            }
            else
            {
                _knightStateMachine.SetState<FSMStateIdle>();
            }
        }

        public void Exit()
        {
        }
        
        private bool NeedChaseEnemy()
        {
            _distance = Vector2.Distance(_attacker.gameObject.transform.position, _knightStateMachine.Target.Transform.position);

            if (_distance > _data.AttackRange)
                return true;

            return false;
        }
    }
}