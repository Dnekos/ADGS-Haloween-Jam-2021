using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

// elements borrowed from https://arongranberg.com/astar/documentation/dev_4_3_2_0f72d50c/old/wander.php
public class GhostBrain : MonoBehaviour
{
    public enum GhostState
    {
        Wander,
        Chase
    };
    [Tooltip("What state of movement the Ghost is in.\nWander: moves within WanderRadius of initial spot\nChase: tracks detected player")]
    public GhostState ActiveState = GhostState.Wander;

    [SerializeField,Tooltip("How far the ghost can move from its start point when wandering")] 
    float WanderRadius = 20;
    [SerializeField, Tooltip("The range in which the ghost detects the player")]
    float DetectRadius = 3;
    [Header("Components"), SerializeField]
    AIDestinationSetter Chaser;
    IAstarAI ai;
    Vector3 StartPos;
    void Start()
    {
        ai = GetComponent<IAstarAI>();
        StartPos = transform.position;

        GetComponent<CircleCollider2D>().radius = DetectRadius;
        transform.GetChild(0).localScale = new Vector3(DetectRadius * 2, DetectRadius * 2, 1);
    }
    void Update()
    {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        // the ai is in a Wandering state
        if (ActiveState == GhostState.Wander && !ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath))
        {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }
    }

    Vector3 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * WanderRadius;
        point.z = transform.position.z; // flatten point for 2D
        point += StartPos; // localize it within their area
        return point;
    }

    // detect if we find the player then start chasing them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // if we find the player
        {
            ActiveState = GhostState.Chase; // turn off wander
            Chaser.enabled = true;
            Chaser.target = collision.transform; // set player as our target to chase
        }
    }
}
