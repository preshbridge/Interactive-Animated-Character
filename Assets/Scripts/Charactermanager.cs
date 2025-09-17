using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Characters")]
    public GameObject[] characters;
    private int currentIndex = 0;

    private void Start()
    {
        // Ensure only first character is active
        for (int i = 0; i < characters.Length; i++)
            characters[i].SetActive(i == currentIndex);
    }

    public void SwitchCharacter()
    {
        if (characters.Length <= 1) return;

        characters[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % characters.Length;
        characters[currentIndex].SetActive(true);
    }
}
