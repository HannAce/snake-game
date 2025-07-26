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
            
            float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
            float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1);
            m_musicVolumeSlider.SetValueWithoutNotify(savedMusicVolume);
            m_sfxVolumeSlider.SetValueWithoutNotify(savedSFXVolume);
            
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
            PlayerPrefs.SetFloat("MusicVolume", volume);
            m_audioManager.SetMusicVolume(volume);
        }    
    
        private void HandleSFXVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("SFXVolume", volume);
            m_audioManager.SetSFXVolume(volume);
        }
    }
}
