using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.EnemiesScripts.Controller
{
    public class EnemySounds : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _attackSounds;
        [SerializeField] private List<AudioClip> _takeDamageFromMeleeSounds;
        [SerializeField] private List<AudioClip> _takeDamageFromWeaponSounds;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAttackClip()
        {
            int clipIndex = Random.Range(0, _attackSounds.Count);
            _audioSource.PlayOneShot(_attackSounds[clipIndex]);

        }

        public void PlayTakeDamageClip()
        {
            int clipIndex = Random.Range(0, _attackSounds.Count);
            _audioSource.PlayOneShot(_attackSounds[clipIndex]);

        }
    }
}