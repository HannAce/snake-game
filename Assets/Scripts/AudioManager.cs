using UnityEngine;
using UnityEngine.Audio;

namespace SnakeGame {
    
    public enum AudioType
    {
        Music,
        SFX
    }
    
    public class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        [SerializeField] private AudioMixer m_audioMixer;
        [SerializeField] private AudioMixerGroup m_musicMixerGroup;
        [SerializeField] private AudioMixerGroup m_sfxMixerGroup;
        [SerializeField] private AudioSource m_audioPrefabToInstantiate;
        
        // These need to be added as exposed parameters in the Audio Mixer
        public float MusicVolume => m_audioMixer.GetFloat("MusicVolume", out float volume) ? volume : 0; // GetFloat returns bool, uses out param so used ternary
        public float SFXVolume => m_audioMixer.GetFloat("SFXVolume", out float volume) ? volume : 0; // GetFloat returns bool, uses out param so used ternary

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        public void InstantiateAndPlayAudio2D(AudioClip audioClip, AudioType audioType, bool usesLifetime, bool isLooping, float volume)
        {
            AudioSource audioSource = Instantiate(m_audioPrefabToInstantiate);
            audioSource.spatialBlend = 0.0f;
            audioSource.outputAudioMixerGroup = audioType is AudioType.Music ? m_musicMixerGroup : m_sfxMixerGroup; // could be switch statement if introduce more audio types
        
            if (isLooping)
            {
                audioSource.clip = audioClip;
                audioSource.loop = true;
                audioSource.volume = volume;
                audioSource.Play();
            }
            else
            {
                audioSource.PlayOneShot(audioClip, volume);
            }

            if (usesLifetime)
            {
                DestroyMe destroyMeComponent = audioSource.GetComponent<DestroyMe>();
                destroyMeComponent.SetLifetime(audioClip.length); // gets length of audioClip, and will call to destroy after
                destroyMeComponent.StartCountdown();
            }
        }
        
        public void SetMusicVolume(float volume)
        {
            m_audioMixer.SetFloat("MusicVolume", volume);
        }    
    
        public void SetSFXVolume(float volume)
        {
            m_audioMixer.SetFloat("SFXVolume", volume);
        }
    }
}
