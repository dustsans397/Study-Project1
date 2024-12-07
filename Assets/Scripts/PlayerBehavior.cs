using UnityEngine;
using UnityEngine.Serialization;

public class PlayerBehavior : MonoBehaviour
{
    [FormerlySerializedAs("_speed")] [SerializeField] private float speed = 0.5f;

    private Animator _animator;

    private Vector3 _direction;

    private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rigidBody2D;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        var isWalking = false;
        var direction = new Vector3();
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += new Vector3(0, -1);
            _spriteRenderer.flipX = false;
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += new Vector3(0, 1);
            _spriteRenderer.flipX = false;
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += new Vector3(-1, 0);
            _spriteRenderer.flipX = true;
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += new Vector3(1, 0);
            _spriteRenderer.flipX = false;
            isWalking = true;
        }
        
        if (direction != Vector3.zero)
            _direction = direction;

        _animator.SetFloat("MoveX", _direction.x);
        _animator.SetFloat("MoveY", _direction.y);

        _animator.SetBool("IsWalk", isWalking);
        var step = speed * Time.deltaTime;
        _rigidBody2D.MovePosition(transform.position + step *direction);
    }
    
}