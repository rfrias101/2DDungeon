using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float stopDistance = 2.5f;
    private Rigidbody2D rb;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = stopDistance;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //rb.constraints = RigidbodyConstraints2D.FreezePosition;

        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);

            Vector2 direction = (playerTransform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.MoveRotation(angle);

           

            Vector3 pos = transform.position;
            pos.z = 0f;
            transform.position = pos;
        }
    }

    public float StopDistance => stopDistance;
}
