//using UnityEngine;
//using UnityEngine.UI;

//public class SoundManager : MonoBehaviour
//{
//    // Music Audio Sources
//    public AudioSource homeMusicSource;
//    public AudioSource gameMusicSource;

//    // SFX Audio Sources
//    public AudioSource[] sfxSources;

//    // Volume settings
//    private float musicVolume = 1f;
//    private float sfxVolume = 1f;

//    // Sliders to control volumes
//    public Slider musicSlider;
//    public Slider sfxSlider;

//    // State for current music (Home or In-Game)
//    private bool isInGame = false;

//    void Start()
//    {
//        // Initialize the sliders with the current volume settings
//        musicSlider.value = musicVolume;
//        sfxSlider.value = sfxVolume;

//        // Set initial volume for music and SFX
//        UpdateMusicVolume(musicSlider.value);
//        UpdateSFXVolume(sfxSlider.value);

//        // Add listeners to sliders to update the volume when changed
//        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
//        sfxSlider.onValueChanged.AddListener(UpdateSFXVolume);

//        // Start with Home Music
//        PlayHomeMusic();
//    }

//    // Update the music volume and save it
//    public void UpdateMusicVolume(float volume)
//    {
//        musicVolume = volume;

//        // Update the volume of both music sources, regardless of paused state
//        homeMusicSource.volume = musicVolume;
//        gameMusicSource.volume = musicVolume;

//        // Optionally save the setting using PlayerPrefs
//        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
//    }

//    // Update the SFX volume and save it
//    public void UpdateSFXVolume(float volume)
//    {
//        sfxVolume = volume;

//        // Update the volume of all SFX sources, regardless of paused state
//        foreach (var sfx in sfxSources)
//        {
//            sfx.volume = sfxVolume;
//        }

//        // Optionally save the setting using PlayerPrefs
//        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
//    }

//    // Play the home background music and stop the game music
//    public void PlayHomeMusic()
//    {
//        if (!homeMusicSource.isPlaying)
//        {
//            homeMusicSource.Play();
//            gameMusicSource.Stop();
//        }
//        isInGame = false;
//    }

//    // Play the in-game background music and stop the home music
//    public void PlayGameMusic()
//    {
//        if (!gameMusicSource.isPlaying)
//        {
//            gameMusicSource.Play();
//            homeMusicSource.Stop();
//        }
//        isInGame = true;
//    }

//    // Play a sound effect
//    public void PlaySFX(AudioClip clip)
//    {
//        foreach (var sfx in sfxSources)
//        {
//            if (!sfx.isPlaying)
//            {
//                sfx.PlayOneShot(clip);
//                break; // Play only on the first available source
//            }
//        }
//    }

//    // Stop all SFX
//    public void StopAllSFX()
//    {
//        foreach (var sfx in sfxSources)
//        {
//            sfx.Stop();
//        }
//    }
//}


//using UnityEngine;
//using UnityEngine.UI;

//public class SoundManager : MonoBehaviour
//{
//    // Music Audio Sources
//    public AudioSource homeMusicSource;
//    public AudioSource gameMusicSource;

//    // SFX Audio Sources
//    public AudioSource[] sfxSources;

//    // Volume settings
//    private float musicVolume = 1f;
//    private float sfxVolume = 1f;

//    // Sliders to control volumes
//    public Slider musicSlider;
//    public Slider sfxSlider;

//    void Start()
//    {
//        // Initialize sliders with the current volume settings
//        musicSlider.value = musicVolume;
//        sfxSlider.value = sfxVolume;

//        // Set initial volume for music and SFX
//        UpdateMusicVolume(musicSlider.value);
//        UpdateSFXVolume(sfxSlider.value);

//        // Add listeners to sliders to update volume when changed
//        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
//        sfxSlider.onValueChanged.AddListener(UpdateSFXVolume);

//        // Start with home music
//        PlayHomeMusic();
//    }

//    // Update the music volume
//    public void UpdateMusicVolume(float volume)
//    {
//        musicVolume = volume;
//        homeMusicSource.volume = musicVolume;
//        gameMusicSource.volume = musicVolume;
//        PlayerPrefs.SetFloat("MusicVolume", musicVolume); // Save setting
//    }

//    // Update the SFX volume
//    public void UpdateSFXVolume(float volume)
//    {
//        sfxVolume = volume;
//        foreach (var sfx in sfxSources)
//        {
//            sfx.volume = sfxVolume;
//        }
//        PlayerPrefs.SetFloat("SFXVolume", sfxVolume); // Save setting
//    }

//    // Play the home background music
//    public void PlayHomeMusic()
//    {
//        if (!homeMusicSource.isPlaying)
//        {
//            homeMusicSource.Play();
//            gameMusicSource.Stop();
//        }
//    }

//    // Play the in-game background music
//    public void PlayGameMusic()
//    {
//        if (!gameMusicSource.isPlaying)
//        {
//            gameMusicSource.Play();
//            homeMusicSource.Stop();
//        }
//    }

//    // Play a sound effect
//    public void PlaySFX(AudioClip clip)
//    {
//        foreach (var sfx in sfxSources)
//        {
//            if (!sfx.isPlaying)
//            {
//                sfx.PlayOneShot(clip);
//                break; // Play only on first available source
//            }
//        }
//    }

//    // Stop all SFX
//    public void StopAllSFX()
//    {
//        foreach (var sfx in sfxSources)
//        {
//            sfx.Stop();
//        }
//    }

//    public void StopGameMusic()
//    {
//        gameMusicSource.Stop();
//    }

//}


//using UnityEngine;
//using UnityEngine.UI;

//public class SoundManager : MonoBehaviour
//{
//    // Music Audio Sources
//    public AudioSource homeMusicSource;
//    public AudioSource gameMusicSource;

//    // SFX Audio Sources
//    public AudioSource[] sfxSources;

//    // Volume settings
//    private float musicVolume = 1f;
//    private float sfxVolume = 1f;

//    // Sliders to control volumes
//    public Slider musicSlider;
//    public Slider sfxSlider;

//    void Start()
//    {
//        // Initialize sliders with the current volume settings
//        musicSlider.value = musicVolume;
//        sfxSlider.value = sfxVolume;

//        // Set initial volume for music and SFX
//        UpdateMusicVolume(musicSlider.value);
//        UpdateSFXVolume(sfxSlider.value);

//        // Add listeners to sliders to update volume when changed
//        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
//        sfxSlider.onValueChanged.AddListener(UpdateSFXVolume);

//        // Start with home music
//        PlayHomeMusic();
//    }

//    // Update the music volume
//    public void UpdateMusicVolume(float volume)
//    {
//        musicVolume = volume;
//        homeMusicSource.volume = musicVolume;
//        gameMusicSource.volume = musicVolume;
//        PlayerPrefs.SetFloat("MusicVolume", musicVolume); // Save setting
//    }

//    // Update the SFX volume
//    public void UpdateSFXVolume(float volume)
//    {
//        sfxVolume = volume;
//        foreach (var sfx in sfxSources)
//        {
//            sfx.volume = sfxVolume;
//        }
//        PlayerPrefs.SetFloat("SFXVolume", sfxVolume); // Save setting
//    }

//    // Play the home background music
//    public void PlayHomeMusic()
//    {
//        if (!homeMusicSource.isPlaying)
//        {
//            homeMusicSource.Play();
//            gameMusicSource.Stop(); // Ensure game music is stopped when home music starts
//        }
//    }

//    // Play the in-game background music
//    public void PlayGameMusic()
//    {
//        if (!gameMusicSource.isPlaying)
//        {
//            gameMusicSource.Play();
//            homeMusicSource.Stop(); // Ensure home music is stopped when game music starts
//        }
//    }

//    // Play a sound effect
//    public void PlaySFX(AudioClip clip)
//    {
//        foreach (var sfx in sfxSources)
//        {
//            if (!sfx.isPlaying)
//            {
//                sfx.PlayOneShot(clip);
//                break; // Play only on first available source
//            }
//        }
//    }

//    // Stop all SFX
//    public void StopAllSFX()
//    {
//        foreach (var sfx in sfxSources)
//        {
//            sfx.Stop();
//        }
//    }

//    // Stop the game music
//    public void StopGameMusic()
//    {
//        gameMusicSource.Stop();
//    }

//    // Stop the home music
//    public void StopHomeMusic()
//    {
//        homeMusicSource.Stop();
//    }
//}


//using UnityEngine;
//using UnityEngine.UI;

//public class SoundManager : MonoBehaviour
//{
//    // Music Audio Sources
//    public AudioSource homeMusicSource;
//    public AudioSource gameMusicSource;

//    // SFX Audio Sources
//    public AudioSource[] sfxSources;

//    // Volume settings
//    private float musicVolume;
//    private float sfxVolume;

//    // Sliders to control volumes
//    public Slider musicSlider;
//    public Slider sfxSlider;

//    void Start()
//    {
//        // Load saved volume settings from PlayerPrefs (if available)
//        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f); // Default to 1 if no saved setting
//        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);     // Default to 1 if no saved setting

//        // Initialize sliders with the current volume settings
//        musicSlider.value = musicVolume;
//        sfxSlider.value = sfxVolume;

//        // Set initial volume for music and SFX
//        UpdateMusicVolume(musicVolume);
//        UpdateSFXVolume(sfxVolume);

//        // Add listeners to sliders to update volume when changed
//        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
//        sfxSlider.onValueChanged.AddListener(UpdateSFXVolume);

//        // Start with home music
//        PlayHomeMusic();
//    }

//    // Update the music volume
//    public void UpdateMusicVolume(float volume)
//    {
//        musicVolume = volume;
//        homeMusicSource.volume = musicVolume;
//        gameMusicSource.volume = musicVolume;
//        PlayerPrefs.SetFloat("MusicVolume", musicVolume); // Save setting
//    }

//    // Update the SFX volume
//    public void UpdateSFXVolume(float volume)
//    {
//        sfxVolume = volume;
//        foreach (var sfx in sfxSources)
//        {
//            sfx.volume = sfxVolume;
//        }
//        PlayerPrefs.SetFloat("SFXVolume", sfxVolume); // Save setting
//    }

//    // Play the home background music
//    public void PlayHomeMusic()
//    {
//        if (!homeMusicSource.isPlaying)
//        {
//            homeMusicSource.Play();
//            gameMusicSource.Stop(); // Ensure game music is stopped when home music starts
//        }
//    }

//    // Play the in-game background music
//    public void PlayGameMusic()
//    {
//        if (!gameMusicSource.isPlaying)
//        {
//            gameMusicSource.Play();
//            homeMusicSource.Stop(); // Ensure home music is stopped when game music starts
//        }
//    }

//    // Play a sound effect
//    public void PlaySFX(AudioClip clip)
//    {
//        foreach (var sfx in sfxSources)
//        {
//            if (!sfx.isPlaying)
//            {
//                sfx.PlayOneShot(clip);
//                break; // Play only on first available source
//            }
//        }
//    }

//    // Stop all SFX
//    public void StopAllSFX()
//    {
//        foreach (var sfx in sfxSources)
//        {
//            sfx.Stop();
//        }
//    }

//    // Stop the game music
//    public void StopGameMusic()
//    {
//        gameMusicSource.Stop();
//    }

//    // Stop the home music
//    public void StopHomeMusic()
//    {
//        homeMusicSource.Stop();
//    }
//}


using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Music Audio Sources
    public AudioSource homeMusicSource;
    public AudioSource gameMusicSource;

    // SFX Audio Sources (Array of AudioSources for SFX)
    public AudioSource[] sfxSources;

    // Volume settings
    private float musicVolume;
    private float sfxVolume;

    // Sliders to control volumes
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        // Load saved volume settings from PlayerPrefs (if available)
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f); // Default to 1 if no saved setting
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);     // Default to 1 if no saved setting

        // Initialize sliders with the current volume settings
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        // Set initial volume for music and SFX
        UpdateMusicVolume(musicVolume);
        UpdateSFXVolume(sfxVolume);

        // Add listeners to sliders to update volume when changed
        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
        sfxSlider.onValueChanged.AddListener(UpdateSFXVolume);

        // Start with home music
        PlayHomeMusic();
    }

    // Update the music volume
    public void UpdateMusicVolume(float volume)
    {
        musicVolume = volume;
        homeMusicSource.volume = musicVolume;
        gameMusicSource.volume = musicVolume;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume); // Save setting
    }

    // Update the SFX volume
    public void UpdateSFXVolume(float volume)
    {
        sfxVolume = volume;
        foreach (var sfx in sfxSources)
        {
            sfx.volume = sfxVolume;
        }
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume); // Save setting
    }

    // Play a sound effect
    public void PlaySFX(AudioClip clip)
    {
        foreach (var sfx in sfxSources)
        {
            if (!sfx.isPlaying)
            {
                sfx.PlayOneShot(clip); // Play sound on first available AudioSource
                break; // Play only on the first available source
            }
        }
    }

    // Stop all SFX
    public void StopAllSFX()
    {
        foreach (var sfx in sfxSources)
        {
            sfx.Stop();
        }
    }

    // Play the home background music
    public void PlayHomeMusic()
    {
        if (!homeMusicSource.isPlaying)
        {
            homeMusicSource.Play();
            gameMusicSource.Stop(); // Ensure game music is stopped when home music starts
        }
    }

    // Play the in-game background music
    public void PlayGameMusic()
    {
        if (!gameMusicSource.isPlaying)
        {
            gameMusicSource.Play();
            homeMusicSource.Stop(); // Ensure home music is stopped when game music starts
        }
    }

    // Stop the game music
    public void StopGameMusic()
    {
        gameMusicSource.Stop();
    }

    // Stop the home music
    public void StopHomeMusic()
    {
        homeMusicSource.Stop();
    }
}
