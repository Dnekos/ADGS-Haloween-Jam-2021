using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostBrain : MonoBehaviour
{
    public float radius = 20;
    IAstarAI ai;
    Vector3 StartPos;
    void Start()
    {
        ai = GetComponent<IAstarAI>();
        StartPos = transform.position;
    }
    Vector3 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * radius;
        point.z = transform.position.z;
        point += StartPos;
        return point;
    }
    void Update()
    {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath))
        {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }
    }
}
