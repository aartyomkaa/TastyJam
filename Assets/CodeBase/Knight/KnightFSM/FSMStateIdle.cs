using System;
using CodeBase.StaticData;

namespace CodeBase.Knight
{
    public class FSMStateIdle : IFSMState
    {
        private readonly KnightStateMachine _knightStateMachine;
        private readonly IFSMControllable _unit;
        
        public FSMStateIdle(KnightStateMachine knightStateMachine, IFSMControllable unit, KnightStaticData data)
        {
            _knightStateMachine = knightStateMachine;
            _unit = unit;
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}