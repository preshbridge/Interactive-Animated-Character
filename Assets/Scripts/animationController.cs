using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Character Setup")]
    [SerializeField] private CharacterController characterController; // Optional, if you need it for movement
    [SerializeField] private Animator[] characterAnimators;           // Assign Animator components for each character

    [Header("Animation Clips")]
    [SerializeField] private string idleState = "Idle";
    [SerializeField] private string runState = "Run";

    private int currentCharacterIndex = 0;

    private Animator CurrentAnimator => characterAnimators.Length > 0 ? characterAnimators[currentCharacterIndex] : null;

    private void Start()
    {
        if (characterAnimators == null || characterAnimators.Length == 0)
        {
            Debug.LogWarning("No animators assigned to AnimationController.");
            return;
        }

        // Initialize: only current character is active
        for (int i = 0; i < characterAnimators.Length; i++)
        {
            if (characterAnimators[i] != null)
                characterAnimators[i].gameObject.SetActive(i == currentCharacterIndex);
        }

        // Ensure current animator starts in idle
        CurrentAnimator?.Play(idleState);
    }

    /// <summary>
    /// Switches to the next character in the array.
    /// </summary>
    public void SwitchCharacter()
    {
        if (characterAnimators.Length <= 1) return;

        // Deactivate current character
        CurrentAnimator?.gameObject.SetActive(false);

        // Move to next character
        currentCharacterIndex = (currentCharacterIndex + 1) % characterAnimators.Length;

        // Activate next character and reset to idle
        CurrentAnimator?.gameObject.SetActive(true);
        CurrentAnimator?.Play(idleState);
    }

    /// <summary>
    /// Plays a specified animation on the current character.
    /// </summary>
    public void PlayAnimation(string animationName)
    {
        if (CurrentAnimator != null)
            CurrentAnimator.Play(animationName);
    }

    /// <summary>
    /// Pauses the current character's animations.
    /// </summary>
    public void PauseAnimation()
    {
        if (CurrentAnimator != null)
            CurrentAnimator.speed = 0;
    }

    /// <summary>
    /// Resumes the current character's animations.
    /// </summary>
    public void ResumeAnimation()
    {
        if (CurrentAnimator != null)
            CurrentAnimator.speed = 1;
    }

    #region UI Shortcuts
    public void OnPlay() => ResumeAnimation();
    public void OnPause() => PauseAnimation();
    public void OnIdle() => PlayAnimation(idleState);
    public void OnRun() => PlayAnimation(runState);
    #endregion
}
