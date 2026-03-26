using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void Move(Vector2 direction)
    {
        Vector2 displacement = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + displacement);
    }
}