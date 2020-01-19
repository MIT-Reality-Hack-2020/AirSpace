using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint nextWayPoint;
    public bool transitionPoint = false;
    public List<Route> connectedRoutes;
}
