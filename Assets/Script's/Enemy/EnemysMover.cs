using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemysMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 0;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector2.SqrMagnitude(_waypoints[_currentWaypoint].Position - transform.position) < 0.6f)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Count;
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].Position, Time.deltaTime * _speed);

        Flip();
    }

    private void Flip()
    {
        if (_waypoints[_currentWaypoint].Position.x - transform.position.x > 0)
            gameObject.transform.rotation = Quaternion.identity;
        else
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}