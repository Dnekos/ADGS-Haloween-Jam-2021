using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
	public float ImpulseSpeed;
	[SerializeField]
	float ExplosionRadius;
	[SerializeField]
	float PushForce;
    

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(Physics2D.OverlapCircleAll(transform.position, ExplosionRadius).Length);
		foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, ExplosionRadius))
		{
			Vector2 force = (col.transform.position - transform.position) * PushForce;

			Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
			if (rb != null)
			{ 
				rb.AddForce(force,ForceMode2D.Impulse);
				Debug.Log(rb.gameObject);
			}

			GhostBrain gb = col.GetComponent<GhostBrain>();
			if (gb != null)
			{
				gb.PushGhost();
			}
		}
		Destroy(gameObject);
	}
}
