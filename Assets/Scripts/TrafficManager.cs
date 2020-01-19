using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    public GameObject planePrefab;
    public GameObject Airspace;
    public GameObject Groundspace;
    public Route HoldingPatternNorthEast;
    public Route HoldingPatternNorthWest;
    public Route HoldingPatternSouthEast;
    public Route HoldingPatternSouthWest;

    public Waypoint SpawnpointNorth;
    public Waypoint SpawnpointEast;
    public Waypoint SpawnpointSouth;
    public Waypoint SpawnpointWest;

    private List<GameObject> planes = new List<GameObject>();
    public string[] airlineCodes = {
        "MIT",
        "HOU",
        "NYU",
        "PSD",
        "UBA",
        "UCF",
        "UOR",
        "USC"
    };

    private float waitTime = 0.0f;
    private float timer = 0.0f;

    private float minWaitTime = 5.0f;
    private float maxWaitTime = 20.0f;

    private HashSet<int> assignedFlightNumbers = new HashSet<int>();

    // Start is called before the first frame update
    void Start()
    {
        RandomizeTime();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= waitTime)
        {
            timer = 0;
            RandomizeTime();
            SpawnPlane();
        }
    }
    void RandomizeTime()
    {
        waitTime = Random.Range(minWaitTime, maxWaitTime);
    }

    void SpawnPlane()
    {
        if (planes.Count >= 10)
        {
            return;
        }

        Debug.Log("Spawning Plane");
        GameObject plane = Instantiate(planePrefab, new Vector3(0, 0, 0), new Quaternion());
        PlaneController pController = plane.GetComponent<PlaneController>();
        pController.airlineCode = airlineCodes[Random.Range(0, airlineCodes.Length)];
        pController.flightNumber = AssignFlightNumber();
        plane.transform.parent = Airspace.transform;

        plane.transform.localScale = new Vector3(1, 1, 1);
        planes.Add(plane);

        int direction = Random.Range(0, 3);
        switch (direction)
        {
            case 0:
                pController.assignedRoute = HoldingPatternNorthWest;
                plane.transform.position = SpawnpointNorth.transform.position;
                break;

            case 1:
                pController.assignedRoute = HoldingPatternNorthEast;
                plane.transform.position = SpawnpointEast.transform.position;
                break;

            case 2:
                pController.assignedRoute = HoldingPatternSouthEast;
                plane.transform.position = SpawnpointSouth.transform.position;
                break;
            case 3:
                pController.assignedRoute = HoldingPatternSouthWest;
                plane.transform.position = SpawnpointWest.transform.position;
                break;

        }
    }

    int AssignFlightNumber()
    {
        int flightNumber = Random.Range(100, 999);
        while (assignedFlightNumbers.Contains(flightNumber))
        {
            flightNumber = Random.Range(100, 999);
        }
        return flightNumber;
    }
}
