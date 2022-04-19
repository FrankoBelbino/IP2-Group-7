using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cameraControl : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = .5f;

    public float maxZoom;
    public float minZoom;
    public float zoomLimiter;

    private Vector3 velocity;
    public Camera cam;

    void start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    void Move()
    {
        Vector3 center = GetCenter();

        Vector3 newPosition = center + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetDistance() / zoomLimiter);
        
        offset.z = Mathf.Lerp(offset.z, newZoom, Time.deltaTime);
    }

    float GetDistance()
    {
        float distance;

        distance = Vector3.Distance(targets[0].gameObject.transform.position, targets[1].gameObject.transform.position);

        return distance;
    }

    float GetGreatestDistance()
    {
        
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }


    Vector3 GetCenter()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;

    }


}
