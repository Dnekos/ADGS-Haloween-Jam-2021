using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
	public float ImpulseSpeed;
	Rigidbody2D rd;
	[SerializeField]
	float ExplosionRadius;
	[SerializeField]
	float PushForce;

    // Start is called before the first frame update
    void Start()
    {
		rd = GetComponent<Rigidbody2D>();
		rd.AddRelativeForce(Vector2.right * ImpulseSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(Physics2D.OverlapCircleAll(transform.position, ExplosionRadius).Length);
		foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, ExplosionRadius))
		{
			if (col.isTrigger || col.tag == "Player")
				continue;

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
				Debug.Log(gb.gameObject.GetInstanceID());
				gb.PushGhost();
			}
		}
		Destroy(gameObject);
	}
}
