using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	private Vector2 velocity;
	private Rigidbody2D rigidBody;
	private Vector2 pos;
	// Start is called before the first frame update
	void Start()
	{
		 rigidBody = GetComponent<Rigidbody2D>();
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		velocity = context.ReadValue<Vector2>();
	}

	// Update is called once per frame
	void Update()
	{
		float deltaTime = Time.deltaTime;
		pos = transform.position;
		rigidBody.MovePosition(pos + velocity * speed * deltaTime);
	}
}
