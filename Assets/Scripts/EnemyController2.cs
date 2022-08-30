using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController2 : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    [SerializeField] private GameObject moneyPrefab;
    [SerializeField]private SuperPowerController _superPowerController;
    private Vector3 temp;
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
         player = FindObjectOfType<PlayerController2>().transform;
         _superPowerController = FindObjectOfType<SuperPowerController>();
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.transform.CompareTag("Bullet"))
    //     {
    //         Destroy(collision.gameObject);
    //         Destroy(gameObject);
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Dead();
        }
    }

    public IEnumerator SpawnMoney()
    {
        Instantiate(moneyPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
    }

    public void Dead()
    {
        Destroy(gameObject);
        _superPowerController.SetScale();
        StartCoroutine(SpawnMoney());
    }
}
