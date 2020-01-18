using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class PlaneExtractionTest : MonoBehaviour
{
    // Bounding Box for Planes Requests
    public Transform BBoxTransform;
    public Vector3 BBoxExtents;

    // Request Planes Every (timeout) number of seconds
    private float timeout = 5f;
    private float timeSinceLastRequest = 0f;

    private MLWorldPlanesQueryParams _queryParams = new MLWorldPlanesQueryParams();
    public MLWorldPlanesQueryFlags QueryFlags;
    public GameObject PlaneGameObject;

    private List<GameObject> _planeCache = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // Start Plane Extraction
        MLWorldPlanes.Start();
    }

    void onDestroy()
    {
        // Stop Plane Extraction
        MLWorldPlanes.Stop();
    }

    void RequestPlanes()
    {
        _queryParams.Flags = QueryFlags;
        _queryParams.MaxResults = 100;
        _queryParams.BoundsCenter = BBoxTransform.position;
        _queryParams.BoundsRotation = BBoxTransform.rotation;
        _queryParams.BoundsExtents = BBoxExtents;

        MLWorldPlanes.GetPlanes(_queryParams, HandleOnReceivedPlanes);
    }

    private void HandleOnReceivedPlanes(MLResult result, MLWorldPlane[] planes, MLWorldPlaneBoundaries[] boundaries)
    {
        GameObject newPlane;
        // Destroy and Remove Old Planes
        for (int i = _planeCache.Count - 1; i >= 0; --i)
        {
            Destroy(_planeCache[i]);
            _planeCache.Remove(_planeCache[i]);
        }

        // Add New Planes to Cache
        for (int i = 0; i < planes.Length; ++i)
        {
            newPlane = Instantiate(PlaneGameObject);
            newPlane.transform.position = planes[i].Center;
            newPlane.transform.rotation = planes[i].Rotation;
            newPlane.transform.localScale = new Vector3(planes[i].Width, planes[i].Height, 1f);
            _planeCache.Add(newPlane);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceLastRequest += Time.deltaTime;
        if (timeSinceLastRequest > timeout)
        {
            timeSinceLastRequest = 0f;
            RequestPlanes();
        }
    }
}
