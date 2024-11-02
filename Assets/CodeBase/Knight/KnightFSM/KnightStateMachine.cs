using System;
using System.Collections.Generic;
using CodeBase.Logic;
using CodeBase.StaticData;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightStateMachine
    {
        private IFSMState _currentState;
        private Dictionary<Type, IFSMState> _states = new Dictionary<Type, IFSMState>();

        public KnightStateMachine(Animator animator, IFSMControllable unit, KnightStaticData data)
        {
            AddState(new FSMStateIdle(this, unit, data));
            AddState(new FSMStateChaseEnemy(this, animator, data));
            AddState(new FSMStateAttack(this, unit, animator, data));
        }

        public Vector3 MovePosition { get; private set; }

        public IDamageable Target { get; private set; }

        public void AddState(IFSMState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>()
            where T : IFSMState
        {
            var type = typeof(T);

            if (_currentState?.GetType() != type)
            {
                if (_states.TryGetValue(type, out var newState))
                {
                    _currentState?.Exit();

                    _currentState = newState;

                    _currentState.Enter();
                }
            }
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}