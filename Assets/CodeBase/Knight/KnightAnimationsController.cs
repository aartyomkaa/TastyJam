using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightAnimationsController : MonoBehaviour
    {
        #region Inspector
        [SpineAnimation]
        [SerializeField]
        private string _runAnimationName;

        [SpineAnimation]
        [SerializeField]
        private string _idleAnimationName;

        [SpineAnimation]
        [SerializeField]
        private string _meleeAtackAnimationName;

        [SpineAnimation]
        [SerializeField]
        private string _swordAttackAnimationName;

        [SpineAnimation]
        [SerializeField]
        private string _poleaxeAttackAnimationName;

        [SpineAnimation]
        [SerializeField]
        private string _takeDamamgeAnimationName;

        [SpineAnimation]
        [SerializeField]
        private string _stunAnimationName;

        [SpineAnimation]
        [SerializeField]
        private string _deathAnimationName;

        [SpineSkin]
        [SerializeField]
        private string _meleeSkinName;

        [SpineSkin]
        [SerializeField]
        private string _swordSkinName;

        [SpineSkin]
        [SerializeField]
        private string _poleaxeSkinName;
        #endregion

        private SkeletonAnimation _skeletonAnimation;
        private Spine.AnimationState _spineAnimationState;
        private Skeleton _skeleton;
        private bool _isRunning;


        void Awake()
        {
            _skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
            _spineAnimationState = _skeletonAnimation.AnimationState;
            _skeleton = _skeletonAnimation.Skeleton;
            _isRunning = false;
        }
        public void Run()
        {
            _isRunning = true;
            _spineAnimationState.SetAnimation(0, _runAnimationName, true);
        }
        public void Idle()
        {
            _isRunning = false;
            _spineAnimationState.SetAnimation(0, _idleAnimationName, true);
        }
        public void TakeDamage()
        {
            _spineAnimationState.SetAnimation(1, _takeDamamgeAnimationName, false);
        }
        public void Die()
        {
            _spineAnimationState.SetAnimation(0, _deathAnimationName, false);
        }
        public void Attack()
        {
            if (_skeleton.Skin.Name == _meleeSkinName)
            {
                _spineAnimationState.SetAnimation(0, _meleeAtackAnimationName, false);
            }
            else if (_skeleton.Skin.Name == _swordSkinName)
            {
                _spineAnimationState.SetAnimation(0, _swordAttackAnimationName, false);
            }
            else if (_skeleton.Skin.Name == _poleaxeSkinName)
            {
                _spineAnimationState.SetAnimation(0, _poleaxeAttackAnimationName, false);
            }

            if (_isRunning)
            {
                _spineAnimationState.AddAnimation(0, _runAnimationName, true, 0);
            }
            else
            {
                _spineAnimationState.AddAnimation(0, _idleAnimationName, true, 0);
            }
        }
        public void Turn()
        {
            _skeleton.ScaleX *= -1;
        }

        public void SetMeleeSkin()
        {
            _skeleton.SetSkin(_meleeSkinName);
            _skeleton.SetSlotsToSetupPose();
        }
        public void SetSwordSkin()
        {
            _skeleton.SetSkin(_swordSkinName);
            _skeleton.SetSlotsToSetupPose();
        }
        public void SetPoleaxeSkin()
        {
            _skeleton.SetSkin(_poleaxeSkinName);
            _skeleton.SetSlotsToSetupPose();
        }
    }
}