using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    [SerializeField] private float shootDelay = .5F;
    private bool locked = false;

    public void Shoot(Vector3 direction)
    {
        StartCoroutine(ShootCo(direction));
    }

    private IEnumerator ShootCo(Vector3 direction)
    {
        if(locked) yield break;
        locked = true;
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bulletPrefab.GetComponent<Collider>().isTrigger = true;
        bullet.BulletMovement(direction);
        yield return new WaitForSeconds(shootDelay);
        locked = false;
    }
}