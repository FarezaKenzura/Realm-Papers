using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperRealms.System.CharacterMovement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 10f;

        [Header("Key Bindings")]
        [SerializeField] private KeyCode moveLeftKey;
        [SerializeField] private KeyCode moveRightKey;
        [SerializeField] private KeyCode jumpKey;

        private Rigidbody2D rb;
        private bool isGrounded;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float moveInput = 0f;

            if (Input.GetKey(moveLeftKey))
                moveInput = -1f;
            else if (Input.GetKey(moveRightKey))
                moveInput = 1f;

            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (Input.GetKeyDown(jumpKey) && isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
                isGrounded = false;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
    }
}

