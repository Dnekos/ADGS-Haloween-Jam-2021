using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Fireball : MonoBehaviour
{
    // Rotation Speed around cat in radians/sec
    [SerializeField] private float rotationSpeed = .1f;
    [SerializeField] private float shotSpeed = .1f;
    private float angle;
    private bool isIdle;
    private bool madeImpact;
    private Vector2 launchDir;
    private GameObject playerCharacter;
    
    void Start()
    {
        Transform t = transform;
        Vector2 firePos = t.localPosition;
        Vector2 playerPos = t.parent.localPosition;
        angle = Mathf.Atan2((firePos.y - playerPos.y), (firePos.x - playerPos.x));
        isIdle = true;
        madeImpact = false;
        playerCharacter = transform.parent.gameObject;
    }

    private void FixedUpdate()
    {
        if (madeImpact)
            return;
        Transform t = transform;
        if (isIdle)
        {
            Vector3 localPos = t.localPosition;
            angle += rotationSpeed;
            transform.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
            launchDir = (t.position - t.parent.position).normalized;
            if (angle > 2 * Mathf.PI)
                angle -= 2 * Mathf.PI;
        }
        else
        {
            t.parent = null;
            Vector3 dir = new Vector3(launchDir.x, launchDir.y, 0f);
            t.position += dir * shotSpeed;
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        isIdle = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")&&!isIdle)
        {
           madeImpact = true;
           // TODO Explosion Area of Effect
           Destroy(gameObject);
           playerCharacter.GetComponent<PlayerCombat>().GenerateFireBall();    
        }
    }
}
