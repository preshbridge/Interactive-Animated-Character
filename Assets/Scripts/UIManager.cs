using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Text characterNameText;
    [SerializeField] private Image characterIconImage;

    /// <summary>
    /// Updates the UI with the character's name and icon.
    /// </summary>
    /// <param name="character">CharacterData containing info to display.</param>
    public void UpdateCharacterUI(CharacterData character)
    {
        if (character == null)
        {
            Debug.LogWarning("CharacterData is null. Cannot update UI.");
            return;
        }

        if (characterNameText != null)
            characterNameText.text = character.CharacterName; // Use property for safety

        if (characterIconImage != null)
            characterIconImage.sprite = character.CharacterIcon; // Use property for safety
    }
}
