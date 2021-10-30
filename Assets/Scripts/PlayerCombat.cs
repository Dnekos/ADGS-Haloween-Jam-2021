using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject youDiedUI;
    [SerializeField] private GameObject fireBall;

    public void GenerateFireBall()
    {
        Instantiate(fireBall,transform); 
    }

    private void Start()
    {
        GenerateFireBall();
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
