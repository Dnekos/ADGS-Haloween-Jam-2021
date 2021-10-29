using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Rotation Speed around cat in radians/sec
    [SerializeField] private float rotationSpeed = .1f;
    private float angle;
    
    void Start()
    {
        Transform t = transform;
        Vector2 firePos = t.localPosition;
        Vector2 playerPos = t.parent.localPosition;
        angle = Mathf.Atan2((firePos.y - playerPos.y), (firePos.x - playerPos.x));
    }

    private void FixedUpdate()
    {
        angle += rotationSpeed;
        transform.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
    }
}
