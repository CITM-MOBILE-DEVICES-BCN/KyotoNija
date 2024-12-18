using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Audio;


namespace ROBOTIN
{
    public class PlayerController : MonoBehaviour
    {

        private int direction = -1;
        private Rigidbody2D rb;
        [SerializeField] private float rayRange = 5f;
        [SerializeField] private float rayOffsetX = 0.5f;
        [SerializeField] private float jumpForce = 0;
        [SerializeField] private float maxJumpForce = 100f;
        [SerializeField] float horizontalJumpScale = 0.5f;
        private RaycastHit2D hitLeft;
        private RaycastHit2D hitRight;
        private RaycastHit2D hitFront;
        private RaycastHit2D hitBack;
        [SerializeField] private bool isJumpWallUnlocked = true;
        [SerializeField] private bool isDoubleJumpUnlocked = false;
        [SerializeField] private bool canDoubleJump = false;
        [SerializeField] private bool isDashUnlocked = false;
        [SerializeField] private bool canDash = false;
        [SerializeField] private bool hasDashed = false;
        private float wallJumpTimer = 0;
        [SerializeField] LayerMask levelMask;
        private bool isBorder = false;

        public AudioClip jumpChargeSound;
        private AudioSource audioSource;
        public AudioClip collisionSound;



        public SpriteRenderer playerSkin;
        public Animator playerAnimator;
        enum playerState
        {
            idle,
            moving,
            preparingToJump,
            jumping,
            preparingToWallJump,
            falling
        }
        playerState state = playerState.falling;

        private void Awake()
        {

            Camera.main.GetComponent<CameraController>().player = gameObject;

            // Configura el AudioSource si no está asignado.
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
            }
        }

        // Start is called before the first frame update
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void PlayJumpSound()
        {
            if (jumpChargeSound != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(jumpChargeSound);
            }
        }

        public void Init(int level, Sprite skin)
        {
            if (level == 1)
            {
                isJumpWallUnlocked = true;
                isDoubleJumpUnlocked = false;
                isDashUnlocked = false;
            }
            else if (level == 2)
            {
                isJumpWallUnlocked = true;
                isDoubleJumpUnlocked = true;
                isDashUnlocked = false;
            }
            else if (level >= GameManager.instance.maxLevelsPerLoop)
            {
                isJumpWallUnlocked = true;
                isDoubleJumpUnlocked = true;
                isDashUnlocked = true;
            }

            playerSkin.sprite = skin;
            if (isDashUnlocked)
            {
                SwipeDetection.instance.swipePerformed += context => { Dash(context); };
            }
        }



        // Update is called once per frame
        private void Update()
        {
            Vector3 directionRayDown = Vector3.down;
            Vector3 directionRayWall = Vector3.left;
            Vector3 rayOriginLeft = new Vector3(transform.position.x + (rayOffsetX), transform.position.y, transform.position.z);
            Vector3 rayOriginRight = new Vector3(transform.position.x + (-rayOffsetX), transform.position.y, transform.position.z);
            Vector3 rayOriginFront = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 rayOriginBack = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Ray2D playerRayLeft = new Ray2D(rayOriginLeft, transform.TransformDirection(directionRayDown * rayRange));
            Ray2D playerRayRight = new Ray2D(rayOriginRight, transform.TransformDirection(directionRayDown * rayRange));
            Ray2D playerRayFront = new Ray2D(rayOriginFront, transform.TransformDirection(directionRayWall * rayRange));
            Ray2D playerRayBack = new Ray2D(rayOriginBack, transform.TransformDirection(-directionRayWall * rayRange));
            Debug.DrawRay(rayOriginLeft, transform.TransformDirection(directionRayDown * rayRange), Color.red);
            Debug.DrawRay(rayOriginRight, transform.TransformDirection(directionRayDown * rayRange), Color.red);
            Debug.DrawRay(rayOriginFront, transform.TransformDirection(directionRayWall * rayRange), Color.red);
            Debug.DrawRay(rayOriginBack, transform.TransformDirection(-directionRayWall * rayRange), Color.red);

            hitLeft = Physics2D.Raycast(rayOriginLeft, directionRayDown, rayRange, levelMask);
            hitRight = Physics2D.Raycast(rayOriginRight, directionRayDown, rayRange, levelMask);
            hitFront = Physics2D.Raycast(rayOriginFront, directionRayWall, rayRange, levelMask);
            hitBack = Physics2D.Raycast(rayOriginBack, directionRayWall, rayRange, levelMask);


            if (Input.GetKey(KeyCode.Space) && state != playerState.falling && state != playerState.preparingToWallJump)
            {
                state = playerState.preparingToJump;
                if (jumpForce < maxJumpForce)
                {
                    jumpForce += 0.5f;
                }
                PlayJumpSound();


            }
            else if (Input.GetKeyUp(KeyCode.Space) && state == playerState.preparingToJump)
            {
                state = playerState.jumping;
                PlayJumpSound();
            }


            switch (state)
            {
                case playerState.idle:
                    break;

                case playerState.preparingToJump:
                    playerAnimator.SetTrigger("jump");
                    break;
                case playerState.jumping:
                    playerAnimator.SetTrigger("jump");
                    Jump();
                    StartCoroutine(JumpCoroutine());
                    break;
                case playerState.preparingToWallJump:
                    playerAnimator.SetTrigger("jump");
                    rb.velocity = Vector2.zero;
                    wallJumpTimer += Time.deltaTime;
                    if (wallJumpTimer > 1)
                    {
                        state = playerState.falling;
                        wallJumpTimer = 0;
                        rb.gravityScale = 1;
                    }
                    if (Input.GetKey(KeyCode.Space))
                    {
                        if (jumpForce < maxJumpForce)
                        {
                            jumpForce += 0.1f;
                        }

                    }
                    else if (Input.GetKeyUp(KeyCode.Space) && state == playerState.preparingToWallJump)
                    {
                        state = playerState.jumping;
                        wallJumpTimer = 0;
                        rb.gravityScale = 1;
                    }

                    break;
                case playerState.falling:
                    playerAnimator.SetTrigger("walk");
                    if (!hasDashed && isDashUnlocked)
                    {
                        canDash = true;
                    }
                    if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
                    {
                        canDoubleJump = false;
                        DoubleJump();
                    }
                    break;
                case playerState.moving:
                    playerAnimator.SetTrigger("walk");
                    break;
            }

            playerSkin.flipX = direction == -1 ? true : false;
        }
        private void FixedUpdate()
        {
            if (state == playerState.moving)
            {
                Move();
            }



        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                transform.Translate(-0.3f * direction, 0, 0);


                if (state == playerState.falling && isJumpWallUnlocked)
                {
                    state = playerState.preparingToWallJump;
                    rb.gravityScale = 0;
                    hasDashed = false;

                }
            }

            if (IsTouchingGround() && state == playerState.falling)
            {
                state = playerState.moving;
                rb.velocity = Vector2.zero;
                hasDashed = false;
            }

            if (collision.gameObject.CompareTag("FloodLayer"))
            {
                PlayCollisionSound();
                GameManager.instance.LoadScene("RobotinMeta");
                Debug.Log("Game Over");
            }



        }

        private void PlayCollisionSound()
        {
            if (collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Orb") && isDoubleJumpUnlocked)
            {
                GameObject Orb;

                Orb = collision.gameObject;
                canDoubleJump = true;
                Orb.SetActive(false);
                StartCoroutine(RespawnOrb(Orb));
                Orb = null;

            }

        }
        IEnumerator RespawnOrb(GameObject Orb)
        {
            yield return new WaitForSeconds(5);
            Orb.SetActive(true);
            Orb = null;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                direction *= -1;

            }

        }

        private void Move()
        {
            if (IsTouchingGround())
            {
                transform.Translate(0.1f * direction, 0, 0);
            }

            if ((hitLeft.collider == null || hitRight.collider == null) && !isBorder)
            {
                direction *= -1;
                isBorder = true;
            }
            else if (isBorder && hitLeft.collider != null && hitRight.collider != null)
            {
                isBorder = false;
            }
        }

        private void Jump()
        {

            Vector2 jumpDirection = new Vector2(direction * horizontalJumpScale, 1.5f);
            rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
            jumpForce = 0;
        }

        private void DoubleJump()
        {
            Vector2 jumpDirection = new Vector2(direction, 2.5f);
            rb.AddForce(jumpDirection * 5, ForceMode2D.Impulse);
        }

        private void Dash(Vector2 direction)
        {
            if (canDash)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(direction * 20, ForceMode2D.Impulse);
                hasDashed = true;
                canDash = false;
            }

        }

        private bool IsTouchingGround()
        {
            if (hitLeft.collider == null && hitRight.collider == null)
            {
                return false;
            }
            else if (hitLeft.collider != null && hitLeft.collider.CompareTag("Terrain"))
            {
                return true;
            }
            else if (hitRight.collider != null && hitRight.collider.CompareTag("Terrain"))
            {
                return true;
            }

            return false;
        }

        private void IsInBorder()
        {

            if (hitLeft.collider == null || hitRight.collider == null)
            {
                isBorder = true;
            }

            if (isBorder && hitLeft.collider != null && hitRight.collider != null)
            {
                isBorder = false;
            }


        }

        private bool IsTouchingWall()
        {
            if (hitFront.collider == null && hitBack.collider == null)
            {
                return false;
            }
            else if (hitFront.collider.CompareTag("Wall") || hitBack.collider.CompareTag("Wall"))
            {
                return true;
            }
            return false;
        }

        IEnumerator JumpCoroutine()
        {
            yield return new WaitForSeconds(0.05f);
            state = playerState.falling;
        }
        private void WallJump()
        {
            horizontalJumpScale = 0.08f;
            Vector2 wallJumpDirection = new Vector2(direction * horizontalJumpScale, 1.5f);
            rb.AddForce(wallJumpDirection * jumpForce, ForceMode2D.Impulse);

            jumpForce = 0;
        }
        IEnumerator WallJumpCoroutine()
        {
            yield return new WaitForSeconds(1f);
            if (state == playerState.preparingToWallJump)
            {
                state = playerState.falling;
            }

        }
    }

}