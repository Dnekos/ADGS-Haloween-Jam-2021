using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject youDiedUI;
    
    void Die()
    {
        Destroy(gameObject);
        Instantiate(youDiedUI);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            Die();
    }
}
