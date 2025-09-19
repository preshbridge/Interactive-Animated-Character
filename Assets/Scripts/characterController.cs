using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private GameObject[] characterObjects;
    [SerializeField] private CharacterData[] charactersData;
    [SerializeField] private AudioSource[] characterVoices;
    [SerializeField] private Animator[] characterAnimators;

    [Header("Audio")]
    [SerializeField] private AudioController audioController;

    [Header("UI")]
    [SerializeField] private UIManager uiManager;

    private int currentIndex = 0;

    private void Start()
    {
        ActivateCharacter(currentIndex);
        StopAllAnimations();
    }

    /// <summary>
    /// Activates the character at the specified index and updates UI/audio.
    /// </summary>
    private void ActivateCharacter(int index)
    {
        if (characterObjects == null || characterObjects.Length == 0) return;

        for (int i = 0; i < characterObjects.Length; i++)
        {
            bool isActive = i == index;

            if (characterObjects[i] != null)
                characterObjects[i].SetActive(isActive);

            if (characterAnimators != null && i < characterAnimators.Length && characterAnimators[i] != null)
                characterAnimators[i].SetBool("isDancing", isActive);

            if (characterVoices != null && i < characterVoices.Length && characterVoices[i] != null)
            {
                if (isActive) characterVoices[i].Play();
                else characterVoices[i].Stop();
            }
        }

        currentIndex = index;

        if (uiManager != null && charactersData != null && index < charactersData.Length)
            uiManager.UpdateCharacterUI(charactersData[index]);
    }

    /// <summary>
    /// Stops all character animations.
    /// </summary>
    private void StopAllAnimations()
    {
        if (characterAnimators == null) return;

        foreach (var anim in characterAnimators)
        {
            if (anim != null)
                anim.SetBool("isDancing", false);
        }
    }

    #region Playback Controls
    public void Play()
    {
        audioController?.PlayMusic();
        SetCurrentCharacterAnimation(true);
        PlayCurrentCharacterVoice();
    }

    public void Pause()
    {
        audioController?.PauseMusic();
        SetCurrentCharacterAnimation(false);
        PauseCurrentCharacterVoice();
    }

    private void SetCurrentCharacterAnimation(bool isPlaying)
    {
        if (characterAnimators != null && currentIndex < characterAnimators.Length && characterAnimators[currentIndex] != null)
            characterAnimators[currentIndex].SetBool("isDancing", isPlaying);
    }

    private void PlayCurrentCharacterVoice()
    {
        if (characterVoices != null && currentIndex < characterVoices.Length && characterVoices[currentIndex] != null)
            characterVoices[currentIndex].Play();
    }

    private void PauseCurrentCharacterVoice()
    {
        if (characterVoices != null && currentIndex < characterVoices.Length && characterVoices[currentIndex] != null)
            characterVoices[currentIndex].Pause();
    }
    #endregion

    #region Character Navigation
    public void NextCharacter()
    {
        Pause();
        int nextIndex = (currentIndex + 1) % characterObjects.Length;
        ActivateCharacter(nextIndex);
        Play();
    }

    public void PreviousCharacter()
    {
        Pause();
        int prevIndex = (currentIndex - 1 + characterObjects.Length) % characterObjects.Length;
        ActivateCharacter(prevIndex);
        Play();
    }
    #endregion

    #region Audio Mute Controls
    public void ToggleBackgroundMute()
    {
        audioController?.ToggleMusicMute();
    }

    public void ToggleCharacterMute()
    {
        if (characterVoices != null && currentIndex < characterVoices.Length && characterVoices[currentIndex] != null)
            characterVoices[currentIndex].mute = !characterVoices[currentIndex].mute;
    }
    #endregion
}
