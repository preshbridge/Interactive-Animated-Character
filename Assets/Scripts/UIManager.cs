using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AudioController audioController;
    public CharacterManager characterManager;

    // Buttons can call these
    public void OnPlayMusic() => audioController.PlayMusic();
    public void OnPauseMusic() => audioController.PauseMusic();
    public void OnNextTrack() => audioController.NextTrack();
    public void OnPreviousTrack() => audioController.PreviousTrack();
    public void OnToggleMute() => audioController.ToggleMute();
    public void OnSetVolume(float value) => audioController.SetVolume(value);
    public void OnSwitchCharacter() => characterManager.SwitchCharacter();
}
