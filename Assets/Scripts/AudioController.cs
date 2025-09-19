using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource audioSource;      // Assign in Inspector
    public AudioClip[] tracks;           // Character-specific tracks
    [Range(0f, 1f)] public float volume = 1f;

    private int currentTrackIndex = 0;
    private bool isMuted = false;

    private void Start()
    {
        if (tracks.Length > 0 && audioSource != null)
        {
            audioSource.clip = tracks[currentTrackIndex];
            audioSource.volume = volume;
            audioSource.Play();
        }
    }

    // Play current track
    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
            audioSource.Play();
    }

    // Pause current track
    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Pause();
    }

    // Go to next track
    public void NextTrack()
    {
        if (tracks.Length == 0 || audioSource == null) return;

        currentTrackIndex++;
        if (currentTrackIndex >= tracks.Length)
            currentTrackIndex = 0;

        audioSource.clip = tracks[currentTrackIndex];
        audioSource.Play();
    }

    // Go to previous track
    public void PreviousTrack()
    {
        if (tracks.Length == 0 || audioSource == null) return;

        currentTrackIndex--;
        if (currentTrackIndex < 0)
            currentTrackIndex = tracks.Length - 1;

        audioSource.clip = tracks[currentTrackIndex];
        audioSource.Play();
    }

    // Mute / unmute (method name updated to match your scripts)
    public void ToggleMusicMute()
    {
        if (audioSource == null) return;
        isMuted = !isMuted;
        audioSource.mute = isMuted;
    }

    // Adjust volume (0 to 1) via slider
    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (audioSource != null)
            audioSource.volume = volume;
    }

    // Toggle background music on/off via UI Toggle
    public void ToggleBackgroundMusic(bool isOn)
    {
        if (audioSource == null) return;

        if (isOn)
            audioSource.Play();
        else
            audioSource.Pause();
    }
}
