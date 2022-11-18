using UnityEngine;

namespace Week_10_Platformer
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;

        public void SetMusicEnabled(bool value)
        {
            if (value)
                _music.UnPause();
            else
                _music.Pause();
        }

        public void SetVolume(float value)
        {
            AudioListener.volume = value;
        }
    }
}
