using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKnight : MonoBehaviour
{
    public float jumpForce = 5;
    public float speed = 5;
    public LayerMask layerMask;
    public Transform pointGround;
    private Animator animator;

    float x, y;
    public bool isOnGround;
    Rigidbody2D rigidbody2D;
    Vector3 scaleCache;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        scaleCache = transform.localScale;
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        animator.SetBool("isWalk", x != 0);
        scaleCache = x > 0 ? Vector3.one : (x < 0 ? new Vector3(-1, 1, 1) : scaleCache);
        transform.localScale = scaleCache;
        rigidbody2D.velocity = new Vector2(speed * x, rigidbody2D.velocity.y);
        isOnGround = isGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rigidbody2D.velocity = new Vector2(0, jumpForce);
        }
        animator.SetBool("isJump", !isOnGround);
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(pointGround.position, pointGround.position + Vector3.down, 0.25f, layerMask);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pointGround.position, (pointGround.position + Vector3.down));
    }
}
