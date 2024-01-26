using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private ShootController shootController;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator anim;

    private GameObject characterModel;
    
    private Touch touch;
    private Vector3 touchFirst;
    private Vector3 touchLast;

    private bool isDragStarting;
    private bool isMoving;

    [SerializeField] private Collider[] EnemiesiinTarget;
    public LayerMask layer;
    private bool hasTarget = false;
    public float closeDistance = 5;

    private void Start()
    {
        characterModel = anim.gameObject;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isDragStarting = true;
                isMoving = true;
                touchFirst = touch.position;
                touchLast = touch.position;
                anim.SetBool("isRunning", true);
            }
        }
    
        if (isDragStarting)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                touchFirst = touch.position;
            }
    
            if (touch.phase == TouchPhase.Ended)
            {
                touchLast = touch.position;
                isMoving = false;
                isDragStarting = false;
                anim.SetBool("isRunning", false);
            }
    
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation,  CalculateRotation(),
                rotationSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
    }
    
    private void FixedUpdate()
    {
        FindTarget();
    }

    private Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }

    private Vector3 CalculateDirection()
    {
        Vector3 temp = (touchFirst - touchLast).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }

    void FindTarget()
    {
        EnemiesiinTarget = Physics.OverlapSphere(transform.position, 20f, layer);
        
    
        for (int i = 0; i < EnemiesiinTarget.Length; i++)
        {
            if (Vector3.Distance(transform.position, EnemiesiinTarget[i].transform.position) <= closeDistance)
            {
                if (hasTarget) return;
                hasTarget = true;
                var direction = EnemiesiinTarget[i].transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized;

                Quaternion targetRotation = Quaternion.LookRotation(direction , Vector3.up);
                characterModel.transform.rotation = Quaternion.Lerp(characterModel.transform.rotation, targetRotation,
                    Time.deltaTime * 10f);
                
                // Destroy(other.gameObject);
                //transform.LookAt(EnemiesiinTarget[i].transform.position);
                shootController.Shoot(direction);
                hasTarget = false;
            }
            else if (Vector3.Distance(transform.position, EnemiesiinTarget[i].transform.position) >= closeDistance)
            {
                characterModel.transform.rotation = Quaternion.Lerp(characterModel.transform.rotation, transform.rotation,
                    Time.deltaTime * 10f);
            }
        }
    }

    // public Transform FindClosestEnemy()
    // {
    //     multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    //     float ClosestDistance = Mathf.Infinity;
    //     Transform trans = null;
    //
    //     foreach (GameObject obj in multipleEnemies)
    //     {
    //         float currentDistance;
    //         currentDistance = Vector3.Distance(transform.position, obj.transform.position);
    //         if (currentDistance < closeDistance)
    //         {
    //             closeDistance = currentDistance;
    //             trans = obj.transform;
    //         }
    //     }
    //     return trans;
    // }


    

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.transform.CompareTag("Enemy"))
    //     {
    //         var direction = other.transform.position - transform.position;
    //         direction.y = 0;
    //         direction = direction.normalized;
    //        // Destroy(other.gameObject);
    //        shootController.Shoot(direction,transform.position);
    //     }
    // }

   
}