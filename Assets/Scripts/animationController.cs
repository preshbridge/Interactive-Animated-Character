using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Character Setup")]
    public CharacterManager characterManager; // Reference to your CharacterManager
    public Animator[] characterAnimators;     // Assign Animator components for each character

    [Header("Animation Clips")]
    public string idleState = "Idle";
    public string runState = "Run";

    private int currentCharacterIndex = 0;

    private void Start()
    {
        // Initialize: make sure only current character is active
        for (int i = 0; i < characterAnimators.Length; i++)
        {
            if (i == currentCharacterIndex)
                characterAnimators[i].gameObject.SetActive(true);
            else
                characterAnimators[i].gameObject.SetActive(false);
        }
    }

    // Called when switching characters
    public void SwitchCharacter()
    {
        // Deactivate current character
        characterAnimators[currentCharacterIndex].gameObject.SetActive(false);

        // Get next character index
        currentCharacterIndex = (currentCharacterIndex + 1) % characterAnimators.Length;

        // Activate next character
        characterAnimators[currentCharacterIndex].gameObject.SetActive(true);

        // Optional: reset animation to idle
        characterAnimators[currentCharacterIndex].Play(idleState);
    }

    // Example animation controls
    public void PlayAnimation(string animationName)
    {
        characterAnimators[currentCharacterIndex].Play(animationName);
    }

    public void PauseAnimation()
    {
        characterAnimators[currentCharacterIndex].speed = 0;
    }

    public void ResumeAnimation()
    {
        characterAnimators[currentCharacterIndex].speed = 1;
    }

    // Shortcut functions for UI buttons
    public void OnPlay() => ResumeAnimation();
    public void OnPause() => PauseAnimation();
    public void OnIdle() => PlayAnimation(idleState);
    public void OnRun() => PlayAnimation(runState);
}
