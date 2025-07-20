using UnityEngine;
using UnityEngine.UI;

namespace SnakeGame {
    public class OptionsMenu : MonoBehaviour
    {
        [SerializeField] private Slider m_musicVolumeSlider;
        [SerializeField] private Slider m_sfxVolumeSlider;

        private AudioManager m_audioManager;

        void Start()
        {
            m_audioManager = AudioManager.Instance;
            
            m_musicVolumeSlider.SetValueWithoutNotify(m_audioManager.MusicVolume);
            m_sfxVolumeSlider.SetValueWithoutNotify(m_audioManager.SFXVolume);
            
            m_musicVolumeSlider.onValueChanged.AddListener(HandleMusicVolumeChanged);
            m_sfxVolumeSlider.onValueChanged.AddListener(HandleSFXVolumeChanged);
        }

        private void OnDestroy()
        {
            m_musicVolumeSlider.onValueChanged.RemoveListener(HandleMusicVolumeChanged);
            m_sfxVolumeSlider.onValueChanged.RemoveListener(HandleSFXVolumeChanged);
        }

        private void HandleMusicVolumeChanged(float volume)
        {
            m_audioManager.SetMusicVolume(volume);
        }    
    
        private void HandleSFXVolumeChanged(float volume)
        {
            m_audioManager.SetSFXVolume(volume);
        }
    }
}
