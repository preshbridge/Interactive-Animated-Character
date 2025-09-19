using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ch34_nonPBRController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("References")]
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioController audioController;

    private Rigidbody rb;
    private Vector3 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        if (rb == null)
        {
            Debug.LogWarning("Rigidbody not found. Added automatically.");
            rb = gameObject.AddComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private void Update()
    {
        // Capture movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0f, vertical) * moveSpeed;
    }

    private void FixedUpdate()
    {
        // Move the character using Rigidbody for physics consistency
        if (rb != null)
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    #region Character Switching
    public void NextCharacter()
    {
        gameController?.NextCharacter();
        audioController?.NextTrack();
    }

    public void PreviousCharacter()
    {
        gameController?.PreviousCharacter();
        audioController?.PreviousTrack();
    }
    #endregion

    #region Music Controls
    public void PlayMusic() => audioController?.PlayMusic();
    public void PauseMusic() => audioController?.PauseMusic();
    #endregion
}
