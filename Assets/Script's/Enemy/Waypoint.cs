using System;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Vector3 Position => transform.position;

    //public event Action EnteredWaypoint;

    //private void OnTriggerEnter(Collider other)
    //{
    //    EnteredWaypoint?.Invoke();
    //}
}
