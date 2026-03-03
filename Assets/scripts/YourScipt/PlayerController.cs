using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;
    // 1.15 handle game over state
    public bool gameOver = false;
    private Rigidbody rb;
    private InputAction jumpAction;

    private bool isOnGround = true;
    public AudioClip jumpSound;
    private AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.gravity *= gravityMultiplier;
    }


    void Update()
    {

        if (gameOver)
        {
            return;
        }


        if (jumpAction.triggered && isOnGround)
        {
            // 1.5 make it jump
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            isOnGround = false;
            audioSource.PlayOneShot(jumpSound);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
        }
    }
}
