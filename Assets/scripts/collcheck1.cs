using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Oculus.Interaction
{
    public class collcheck1 : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;

        [Tooltip("Audio clip arrays with a value greater than 1 will have randomized playback.")]
        [SerializeField]
        private AudioClip[] _audioClips;

        [Tooltip("Volume set here will override the volume set on the attached sound source component.")]
        [Range(0f, 1f)]
        [SerializeField]
        private float _volume = 0.7f;
        public float Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = value;
            }
        }

        public AudioTrigger audioTrigger;
        public GameObject mesh1;
        public GameObject mesh2;

        [Tooltip("Check the 'Use Random Range' bool to and adjust the min and max slider values for randomized volume level playback.")]
        [SerializeField]
        private MinMaxPair _volumeRandomization;
        public MinMaxPair VolumeRandomization
        {
            get
            {
                return _volumeRandomization;
            }
            set
            {
                _volumeRandomization = value;
            }
        }

        [Tooltip("Pitch set here will override the volume set on the attached sound source component.")]
        [SerializeField]
        [Range(-3f, 3f)]
        [Space(10)]
        private float _pitch = 1f;
        public float Pitch
        {
            get
            {
                return _pitch;
            }
            set
            {
                _pitch = value;
            }
        }

        [Tooltip("Check the 'Use Random Range' bool to and adjust the min and max slider values for randomized volume level playback.")]
        [SerializeField]
        private MinMaxPair _pitchRandomization;
        public MinMaxPair PitchRandomization
        {
            get
            {
                return _pitchRandomization;
            }
            set
            {
                _pitchRandomization = value;
            }
        }

        [Tooltip("True by default. Set to false for sounds to bypass the spatializer plugin. Will override settings on attached audio source.")]
        [SerializeField]
        [Space(10)]
        private bool _spatialize = true;
        public bool Spatialize
        {
            get
            {
                return _spatialize;
            }
            set
            {
                _spatialize = value;
            }
        }

        [Tooltip("False by default. Set to true to enable looping on this sound. Will override settings on attached audio source.")]
        [SerializeField]
        private bool _loop = false;
        public bool Loop
        {
            get
            {
                return _loop;
            }
            set
            {
                _loop = value;
            }
        }

        [Tooltip("100% by default. Sets likelyhood sample will actually play when called")]
        [SerializeField]
        private float _chanceToPlay = 100;
        public float ChanceToPlay
        {
            get
            {
                return _chanceToPlay;
            }
            set
            {
                _chanceToPlay = value;
            }
        }

        [Tooltip("If enabled, audio will play automatically when this gameobject is enabled")]
        [SerializeField, Optional]
        private bool _playOnStart = false;

        private int _previousAudioClipIndex = -1;

        protected virtual void Start()
        {
            // Get the AudioTrigger script component from the same GameObject
            audioTrigger = GetComponent<AudioTrigger>();

            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
            }

            this.AssertField(_audioSource, nameof(_audioSource));
            this.AssertCollectionField(_audioClips, nameof(_audioClips));

            // Play audio on start if enabled
            if (_playOnStart)
            {
                PlayAudio();
            }
        }

        public void PlayAudio()
        {
            // Check if random chance is set
            float pick = Random.Range(0.0f, 100.0f);
            if (_chanceToPlay < 100 && pick > _chanceToPlay)
            {
                return;
            }

            // Check if volume randomization is set
            if (_volumeRandomization.UseRandomRange == true)
            {
                _audioSource.volume = Random.Range(_volumeRandomization.Min, _volumeRandomization.Max);
            }
            else
            {
                _audioSource.volume = _volume;
            }

            // Check if pitch randomization is set
            if (_pitchRandomization.UseRandomRange == true)
            {
                _audioSource.pitch = Random.Range(_pitchRandomization.Min, _pitchRandomization.Max);
            }
            else
            {
                _audioSource.pitch = _pitch;
            }

            _audioSource.spatialize = _spatialize;
            _audioSource.loop = _loop;

            _audioSource.clip = RandomClipWithoutRepeat();

            _audioSource.Play();
        }

        public void checkCollide()
        {
            if (MeshesOverlap(mesh1, mesh2))
            {
                Debug.Log("Meshes are overlapping!Meshes are overlapping!Meshes are overlapping!Meshes are overlapping!Meshes are overlapping!Meshes are overlapping!Meshes are overlapping!Meshes are overlapping!Meshes are overlapping!");
                PlayAudio();
                // Call PlayAudio() from AudioTrigger script
                //
            }
        }

        bool MeshesOverlap(GameObject obj1, GameObject obj2)
        {
            // Get the colliders of both objects
            Collider collider1 = obj1.GetComponent<Collider>();
            Collider collider2 = obj2.GetComponent<Collider>();

            // Check for overlap using Physics.OverlapBox
            if (collider1 != null && collider2 != null)
            {
                Bounds bounds1 = collider1.bounds;
                Bounds bounds2 = collider2.bounds;

                // Adjust the size of the box according to your needs
                Vector3 overlapBoxSize = new Vector3(1f, 1f, 1f);

                // Check for overlap using Physics.OverlapBox
                return Physics.OverlapBox(bounds1.center, overlapBoxSize / 2, Quaternion.identity)
                    .Any(collider => collider == collider2);
            }

            return false;
        }

        /// <summary>
        /// Choose a random clip without repeating the last clip
        /// </summary>
        private AudioClip RandomClipWithoutRepeat()
        {
            if (_audioClips.Length == 1)
            {
                return _audioClips[0];
            }

            int randomOffset = Random.Range(1, _audioClips.Length);
            int index = (_previousAudioClipIndex + randomOffset) % _audioClips.Length;
            _previousAudioClipIndex = index;
            return _audioClips[index];
        }

        #region Inject

        public void InjectAllAudioTrigger(AudioSource audioSource, AudioClip[] audioClips)
        {
            InjectAudioSource(audioSource);
            InjectAudioClips(audioClips);
        }

        public void InjectAudioSource(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }
        public void InjectAudioClips(AudioClip[] audioClips)
        {
            _audioClips = audioClips;
        }

        public void InjectOptionalPlayOnStart(bool playOnStart)
        {
            _playOnStart = playOnStart;
        }

        #endregion
    }

    [System.Serializable]
    public struct MinMaxPair
    {
        [SerializeField]
        private bool _useRandomRange;
        [SerializeField]
        private float _min;
        [SerializeField]
        private float _max;

        public bool UseRandomRange => _useRandomRange;
        public float Min => _min;
        public float Max => _max;
    }
}
