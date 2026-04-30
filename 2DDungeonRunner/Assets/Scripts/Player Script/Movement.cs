using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private float _defaultSpeed;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.gravityScale = 0f;
        _defaultSpeed = speed;
    }

    public void Move(Vector2 direction)
    {
        Vector2 displacement = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + displacement);
    }

    public void ApplySlow(float slowAmount, float duration)
    {
        StartCoroutine(SlowRoutine(slowAmount, duration));
    }

    private IEnumerator SlowRoutine(float slowAmount, float duration)
    {
        speed = _defaultSpeed * slowAmount;
        yield return new WaitForSeconds(duration);
        speed = _defaultSpeed;
    }
}