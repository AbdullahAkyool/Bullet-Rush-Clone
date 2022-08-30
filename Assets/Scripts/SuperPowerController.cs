using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class SuperPowerController : MonoBehaviour
{
    public Vector3 maxScale; 
    [SerializeField] private SuperPowerColliderThings _superPowerColliderThings;

    private int killIndex = 0;

    private void Start()
    {
        _superPowerColliderThings = FindObjectOfType<SuperPowerColliderThings>();
    }
    
    public void SetScale()
    {
        killIndex++;
        transform.DOComplete();
        Vector3 scaleVector = transform.localScale + new Vector3(1, 0, 1);
        scaleVector.x = Mathf.Clamp(scaleVector.x, 1, 20);
        scaleVector.z = Mathf.Clamp(scaleVector.z, 1, 20);
        transform.DOScale(scaleVector, .25f).OnComplete(() => CheckScale());
    }
    
    public void CheckScale()
    {
        if (killIndex%maxScale.x == 0)
        {
            Debug.Log("sadasdasdasdasdasdasd");
            _superPowerColliderThings.SetColliderScale();
            transform.localScale = new Vector3(1, 0.2F, 1);
            //_superPowerColliderThings.transform.localScale = new Vector3(1, 0.2F, 1);
        }
    }

    // void UseSuperPower()
    // {
    //     for (int i = 0; i <= enemiesInRange.Count; i++)
    //     {
    //         _enemyController2.Dead(enemiesInRange[0].gameObject);
    //     }
    //     
    // }
    // void OnTriggerEnter(Collider other)
    // {
    //     if(enemiesInRange.Contains(other.gameObject)) return;
    //     enemiesInRange.Add(other.gameObject);
    // }
    // void OnTriggerExit(Collider other)
    // {
    //     if(!enemiesInRange.Contains(other.gameObject)) return;
    //     enemiesInRange.Remove(other.gameObject);
    // }
    //
    
}
