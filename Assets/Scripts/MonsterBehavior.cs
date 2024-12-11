using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector3 _direction;
    private MonsterMovement _detectionZone;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public float speed = 0.5f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _detectionZone = GetComponent<MonsterMovement>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MonsterMove();
    }

    private void MonsterMove()
    {
        _animator.SetBool("IsWalk1", false);
        if (_detectionZone.detectedObjs != null)
        {
            Vector3 direction = (_detectionZone.detectedObjs.transform.position - transform.position);
            if (direction.magnitude <= _detectionZone.viewRadius)
            {
                var step = speed * Time.deltaTime;
                _rb.MovePosition(transform.position + step * direction);
                var angle = Vector3.Angle(direction, transform.forward);
                if (direction.x < 0)
                {
                    _spriteRenderer.flipX = true;
                }

                if (direction.x > 0)
                {
                    _spriteRenderer.flipX = false;
                }
                float MoveX1 = Mathf.Cos(angle) * direction.x;
                float MoveY1 = Mathf.Sin(angle) * direction.y;
                _animator.SetFloat("MoveX1", MoveX1);
                _animator.SetFloat("MoveY1", MoveY1);
                _animator.SetBool("IsWalk1", direction.magnitude >0);
            }
        }
    }
}
