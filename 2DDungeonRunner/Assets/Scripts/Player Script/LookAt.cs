using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LookAtMouse(Vector2 mouseWorldPosition)
    {
        Vector2 direction = mouseWorldPosition - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(angle);
    }
}
