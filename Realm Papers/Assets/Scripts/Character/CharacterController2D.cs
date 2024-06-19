using System.Collections;
using System.Collections.Generic;
using PaperRealm.System.GameManager;
using UniRx;
using UnityEngine;

namespace PaperRealms.System.CharacterMovement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 10f;

        [Header("Key Bindings")]
        [SerializeField] private KeyCode moveLeftKey;
        [SerializeField] private KeyCode moveRightKey;
        [SerializeField] private KeyCode jumpKey;

        [Header("Ground Check")]
        [SerializeField] private Transform groundCheckTransform;
        [SerializeField] private float groundCheckRadius = 0.1f;
        [SerializeField] private LayerMask groundLayer;

        [Header("Collider Check")]
        [SerializeField] private float colliderCheckRadius = 0.1f;

        private Rigidbody2D rb;
        private bool isOnSideOfPlatform = false;
        private BoolReactiveProperty isGrounded = new BoolReactiveProperty(false);
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.interpolation = RigidbodyInterpolation2D.Interpolate;

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

                    if (!isOnSideOfPlatform)
                    {
                        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
                    }

                    if (Input.GetKeyDown(jumpKey) && isGrounded.Value)
                    {
                        rb.velocity = Vector2.up * jumpForce;
                        isGrounded.Value = false;
                    }
                }).AddTo(this);
                
            // Handle ground check
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    CheckGround();
                    CheckSideOfPlatform();
                })
                .AddTo(this);
        }

        private void CheckGround()
        {
            Collider2D groundCollider = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
            isGrounded.Value = groundCollider != null;
        }

        private void CheckSideOfPlatform()
        {
            Collider2D[] colliders = Physics2D.OverlapCapsuleAll(transform.position, new Vector2(colliderCheckRadius * 2, colliderCheckRadius * 2), CapsuleDirection2D.Vertical, 0f, groundLayer);
            isOnSideOfPlatform = false;

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject != gameObject)
                {
                    if (Mathf.Abs(collider.transform.position.y - transform.position.y) < colliderCheckRadius)
                    {
                        isOnSideOfPlatform = true;
                        break;
                    }
                }
            }
        }

        // Teleport the player
        public void Teleport(Vector3 destination)
        {
            transform.position = destination;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            GizmosExtension.DrawWireCircle(groundCheckTransform.position, groundCheckRadius);
            GizmosExtension.DrawWireCapsule(transform.position, colliderCheckRadius, colliderCheckRadius * 2);
        }
    }
}

