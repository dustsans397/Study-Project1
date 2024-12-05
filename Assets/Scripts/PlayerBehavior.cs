using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    private float _speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        var direction = new Vector3();
        bool IsWalking = false;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction = new(0, -1);
                animator.SetFloat("MoveY",-1);
                spriteRenderer.flipX = false;
                IsWalking = true;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction = new(0, 1);
                animator.SetFloat("MoveY", 1);
                spriteRenderer.flipX = false;
                IsWalking = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = new(-1, 0);
                animator.SetFloat("MoveX", -1);
                spriteRenderer.flipX = true;
                IsWalking = true;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = new(1, 0);
                animator.SetFloat("MoveX", 1);
                spriteRenderer.flipX = false;
                IsWalking = true;
            }
        animator.SetBool("IsWalk", IsWalking);
        var step = _speed * Time.deltaTime;
        transform.position += step * direction;
        
    }
}
