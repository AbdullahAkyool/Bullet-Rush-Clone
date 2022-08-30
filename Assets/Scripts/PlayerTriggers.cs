using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    [SerializeField]private MoneyController _moneyController;

    private void Start()
    {
       // _moneyController = FindObjectOfType<MoneyController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Dead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            _moneyController.CreateMoneySpriteInUI(other.transform.position);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Win");
            Time.timeScale = 0;
        }
    }
    
    private void Dead()
    {
        Debug.Log("Dead");
        Time.timeScale = 0;
    }
}
