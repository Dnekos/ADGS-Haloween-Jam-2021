using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Candle : MonoBehaviour
{

	CircleCollider2D LitArea;

	// Start is called before the first frame update
	void Start()
    {
		LitArea = GetComponent<CircleCollider2D>();
		AstarPath.active.UpdateGraphs(LitArea.bounds);
    }

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.transform.tag == "Player")// && Player.getComponent<Movement>().blowingout)
		{
			gameObject.layer = 0; // place the object out of the GhostWall layer
			// define area of the graph to update, so we dont update the whole level
			Bounds litbounds = new Bounds(transform.position, Vector3.one * LitArea.radius); 
			AstarPath.active.UpdateGraphs(litbounds); // update the graph
		}
	}
}
