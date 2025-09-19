using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] characters; // Assign in Inspector
    private int currentIndex = 0;

    private void Start()
    {
        ShowCharacter(currentIndex);
    }

    // Show a specific character and hide others
    private void ShowCharacter(int index)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
        }
    }

    // Move to next character
    public void NextCharacter()
    {
        if (characters.Length == 0) return;

        currentIndex++;
        if (currentIndex >= characters.Length) currentIndex = 0;

        ShowCharacter(currentIndex);
    }

    // Move to previous character
    public void PreviousCharacter()
    {
        if (characters.Length == 0) return;

        currentIndex--;
        if (currentIndex < 0) currentIndex = characters.Length - 1;

        ShowCharacter(currentIndex);
    }
}
