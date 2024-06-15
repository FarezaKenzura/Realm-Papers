using System.Collections;
using System.Collections.Generic;
using PaperRealm.System.GameManager;
using UniRx;
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
        [SerializeField] private KeyCode pickUpKey;

        private Rigidbody2D rb;
        private BoolReactiveProperty isGrounded = new BoolReactiveProperty(false);
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            // Handle movement
            Observable.EveryUpdate()
                .Where(_ => GameManager.Instance.CurrentState == GameState.GamePlay)
                .Subscribe(_ =>
                {
                    float moveInput = 0f;

                    if (Input.GetKey(moveLeftKey))
                    {
                        moveInput = -1f;
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else if (Input.GetKey(moveRightKey))
                    {
                        moveInput = 1f;
                        transform.localScale = new Vector3(1, 1, 1);
                    }

                    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

                    if (Input.GetKeyDown(jumpKey) && isGrounded.Value)
                    {
                        rb.velocity = Vector2.up * jumpForce;
                        isGrounded.Value = false;
                    }
                }).AddTo(this);
        }

        // Teleport the player
        public void Teleport(Vector3 destination)
        {
            transform.position = destination;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded.Value = true;
            }
        }
    }
}

