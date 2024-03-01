using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject interactableNotif;
    [SerializeField]
    private GameObject plusHealth;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private IInteractable targetInteractable;

    private bool isGrounded;
    private bool isMovable = true;

    int health;

    private void Start()
    {
        health = GameManager.Instance.GetHealth();
        GameManager.Instance.healthEvent.Subscribe(HealPlayer).AddTo(this);
        GameManager.Instance.gameOverEvent.Subscribe(DisablePlayer).AddTo(this);
    }

    void Update()
    {
        if (!isMovable)
            return;

        // Check for ground contact
        isGrounded = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Ground"));

        // Horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip sprite based on movement direction
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }

        // Set animator parameter for movement speed
        animator.SetFloat("movementSpeed", Mathf.Abs(moveInput));

        // Set animator parameters for jump and fall animations
        if (!isGrounded)
        {
            animator.SetBool("isJumping", rb.velocity.y > 0);
            animator.SetBool("isFalling", rb.velocity.y < 0);
        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Interact
        if(Input.GetButtonDown("Interact"))
        {
            if(targetInteractable != null)
            {
                targetInteractable.OnInteract();
            }
        }    
    }

    private void HealPlayer(int value)
    {
        plusHealth.SetActive(false);
        if (value <= health)
        {
            health = value;
            return;
        }
        plusHealth.SetActive(true);
    }

    private void DisablePlayer(Unit _)
    {
        animator.SetBool("isDead", true);
        isMovable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            interactableNotif.SetActive(true);
            targetInteractable = collision.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            interactableNotif.SetActive(false);
            targetInteractable = null;
        }
    }
}
