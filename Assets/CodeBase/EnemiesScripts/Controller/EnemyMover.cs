using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public delegate void Empty();
    public event Empty StartAttacking;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    public IEnumerator MovingToKnight(float enemySpeed, float enemyVisibilityRange)
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Vector2 _knightPos = (Vector2)GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        Vector2 _vectorToKnight = _knightPos - (Vector2)transform.position;
        while (_vectorToKnight.magnitude > enemyVisibilityRange)
        {
            _rb.velocity = _vectorToKnight.normalized * enemySpeed;
            _knightPos = (Vector2)GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
            _vectorToKnight = _knightPos - (Vector2)transform.position;
            _spriteRenderer.flipX = _rb.velocity.x < 0;

            yield return new WaitForSeconds(Time.deltaTime);
        }
        StartAttacking.Invoke();
    }
}
