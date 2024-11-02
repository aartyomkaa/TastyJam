using Unity.VisualScripting;

namespace CodeBase.Knight
{
    public interface IFSMState
    {
        void Enter();
        
        void Update();
        
        void Exit();
    }
}