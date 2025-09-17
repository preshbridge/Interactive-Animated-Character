using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [Header("Music Settings")]
    public AudioSource musicSource;
    public AudioClip[] tracks;
    private int currentTrack = 0;

    [Header("Volume Settings")]
    [Range(0f, 1f)]
    public float volume = 1f;

    private void Start()
    {
        if (tracks.Length > 0)
        {
            musicSource.clip = tracks[currentTrack];
            musicSource.volume = volume;
            musicSource.Play();
        }
    }

    public void PlayMusic() => musicSource.Play();
    public void PauseMusic() => musicSource.Pause();

    public void NextTrack()
    {
        if (tracks.Length == 0) return;
        currentTrack = (currentTrack + 1) % tracks.Length;
        musicSource.clip = tracks[currentTrack];
        musicSource.Play();
    }

    public void PreviousTrack()
    {
        if (tracks.Length == 0) return;
        currentTrack = (currentTrack - 1 + tracks.Length) % tracks.Length;
        musicSource.clip = tracks[currentTrack];
        musicSource.Play();
    }

    public void ToggleMute()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        musicSource.volume = volume;
    }
}
