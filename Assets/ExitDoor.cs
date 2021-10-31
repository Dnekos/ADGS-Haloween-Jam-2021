using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			foreach (Candle candle in FindObjectsOfType<Candle>())
				if (candle.isLit == true)
					return; // dont get snuffed if any other candles are lit
			
			AudioManager.instance.PlaySound("CloseDoor");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
