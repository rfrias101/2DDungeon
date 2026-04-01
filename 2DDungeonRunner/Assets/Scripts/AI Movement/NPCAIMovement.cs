using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NPCAIMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 2f;
    private NavMeshAgent _agent;
    private int _currentWaypoint = 0;
    private bool _isInteracting = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        GoToNextWaypoint();
    }

    void Update()
    {
        if (_isInteracting) return;

        // reached waypoint
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(waitTime);
        _agent.isStopped = false;
        GoToNextWaypoint();
    }

    private void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;
        _agent.SetDestination(waypoints[_currentWaypoint].position);
        _currentWaypoint = (_currentWaypoint + 1) % waypoints.Length; // loops back to 0
    }

    public void StopForInteraction()
    {
        _isInteracting = true;
        _agent.isStopped = true;
    }

    public void ResumeAfterInteraction()
    {
        _isInteracting = false;
        _agent.isStopped = false;
        GoToNextWaypoint();
    }
}