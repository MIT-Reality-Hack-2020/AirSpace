using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlaneController : MonoBehaviour
{
    public Route assignedRoute;

    public Route nextRoute;

    // KNOTS
    public int airSpeed = 100;
    // FEET
    public int altitude = 1000;
    public Waypoint targetWaypoint;

    public string airlineCode = "NUL";
    public int flightNumber = 000;
    public GameObject label;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetWaypoint == null && assignedRoute != null)
        {
            targetWaypoint = assignedRoute.begin;
        }
        float speed = airSpeed / 100.0f;
        float stepDistance = speed * Time.deltaTime;
        if (targetWaypoint != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetWaypoint.transform.position, stepDistance);
            if (Vector3.Distance(this.transform.position, targetWaypoint.transform.position) < 0.01f)
            {
                targetWaypoint = targetWaypoint.nextWayPoint;
                this.transform.LookAt(targetWaypoint.transform.position);
            }
        }
        label.transform.LookAt(Camera.main.transform);
        label.transform.Rotate(Vector3.up - new Vector3(0, 180, 0));
        label.GetComponent<TextMeshPro>().text = airlineCode + " " + flightNumber;
    }
}
