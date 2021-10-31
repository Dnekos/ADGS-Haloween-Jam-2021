using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleEventFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		if (FindObjectsOfType<EventSystem>().Length > 1)
			Destroy(gameObject);
    }
}
