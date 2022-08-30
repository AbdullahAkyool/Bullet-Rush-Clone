using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SuperPowerColliderThings : MonoBehaviour
{
    [SerializeField]private SuperPowerController _SuperPowerController;
    [SerializeField] private EnemyController2 _enemyController2;

    private void Start()
    {
        _SuperPowerController = FindObjectOfType<SuperPowerController>();
        _enemyController2 = FindObjectOfType<EnemyController2>();
    }

    public void SetColliderScale()
    {
        //transform.DOKill();
        transform.DOScale(_SuperPowerController.maxScale, .3f).OnComplete(()=>DefaultScale());
    }

    void DefaultScale()
    {
        transform.localScale = new Vector3(1, .02f, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
