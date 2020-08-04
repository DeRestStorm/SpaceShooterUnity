using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(AudioSource))]
    public class BackgroundMusicController : MonoBehaviour
    {
        public AudioClip NormalMusic;
        public AudioClip WinMusic;
        public AudioClip LoseMusic;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = NormalMusic;
            _audioSource.Play();
        }

        public void PlayWinMusic()
        {
            _audioSource.clip = WinMusic;
            _audioSource.Play();
        }

        public void PlayLoseMusic()
        {
            _audioSource.clip = LoseMusic;
            _audioSource.loop = false;
            _audioSource.Play();
        }
    }
}