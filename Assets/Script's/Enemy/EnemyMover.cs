using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private readonly Quaternion _lookRight = Quaternion.identity;
    private readonly Quaternion _lookLeft = Quaternion.Euler(0, 180, 0);

    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 0;
    private float _distanceInaccuracy = 0.6f;

    private void Update()
    {
        if (Vector2.SqrMagnitude(_waypoints[_currentWaypoint].Position - transform.position) < _distanceInaccuracy)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Count;
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].Position, Time.deltaTime * _speed);

        Flip();
    }

    private void Flip()
    {
        if (_waypoints[_currentWaypoint].Position.x - transform.position.x > 0)
            transform.rotation = _lookRight;
        else
            transform.rotation = _lookLeft;
    }
}