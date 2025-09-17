using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterControllerScript characterController;
    public AudioController audioController;

    private int currentIndex = 0;

    void Start()
    {
        SelectCharacter(0); // Start with first character
    }

    public void NextCharacter()
    {
        currentIndex = (currentIndex + 1) % characterController.characters.Length;
        SelectCharacter(currentIndex);
    }

    public void PreviousCharacter()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = characterController.characters.Length - 1;
        SelectCharacter(currentIndex);
    }

    public void SelectCharacter(int index)
    {
        characterController.SwitchCharacter(index);
        audioController.SwitchToCharacter(index);
    }
}
