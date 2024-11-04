using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private float _moveSpeed;

    public void Construct(float moveSpeed) => 
        _moveSpeed = moveSpeed;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Move(Transform target)
    {
        Vector3 vectorToKnight = target.transform.position - transform.position;
        
        transform.Translate(vectorToKnight * Time.deltaTime);

        _spriteRenderer.flipX = _rb.velocity.x < 0;
    }
}
