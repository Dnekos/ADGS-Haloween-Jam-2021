using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject youDiedUI;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float projectileSpeed = .1f;
    [SerializeField] private GameObject reticle;

    private GameObject projectile;
    private Vector2 launchDir;

    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.ReadValue<float>() != 1f)
            return;
        Destroy(projectile);
        projectile = Instantiate(fireBall, transform.position, Quaternion.identity);
        Camera cam = Camera.main;
        Vector2 mousePosWorld = cam.ScreenToWorldPoint(reticle.transform.position);
        launchDir = (mousePosWorld - (Vector2)projectile.transform.position);
    }

    private void FixedUpdate()
    {
        if (projectile != null)
        {
            projectile.transform.position += (Vector3)(launchDir * projectileSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            Die();
    }   
    void Die()
    {
        Destroy(gameObject);
        Instantiate(youDiedUI);
    }

}
