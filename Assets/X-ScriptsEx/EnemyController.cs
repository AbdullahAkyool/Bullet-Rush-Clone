using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerController2 player;
    [SerializeField] private Rigidbody enemyRB;
    public float moveSpeed;
    
    private void Update()
    {
        var targetDistance = player.transform.localPosition-transform.position ;
        targetDistance.y = 0;
        var direction = targetDistance.normalized;
        Move(direction);
        transform.LookAt(player.transform);
    }

    private void Move(Vector3 Direction)
    {
        enemyRB.velocity = Direction*moveSpeed*Time.deltaTime;
    }
}
