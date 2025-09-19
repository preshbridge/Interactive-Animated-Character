using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Basic Info")]
    [Tooltip("The display name of the character.")]
    [SerializeField] private string characterName;

    [Tooltip("Icon representing the character in UI.")]
    [SerializeField] private Sprite characterIcon;

    [Header("Optional Voice")]
    [Tooltip("Optional voice clip for the character.")]
    [SerializeField] private AudioClip characterVoice;

    // Public read-only accessors
    public string CharacterName => characterName;
    public Sprite CharacterIcon => characterIcon;
    public AudioClip CharacterVoice => characterVoice;
}
