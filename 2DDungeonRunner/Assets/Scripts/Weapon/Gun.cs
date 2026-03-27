using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private float damage = 15f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    public void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetDamage(damage);
    }
}
