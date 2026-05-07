using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private float damage = 15f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float spreadAngle = 15f;
    [SerializeField] private float fireDamagePerSec = 2f;
    [SerializeField] private float fireDuration = 3f;

    public void Attack()
    {
        if (PlayerAbilities.Instance.HasBulletSpread)
            FireSpread();
        else
            FireSingle(firePoint.rotation);
    }

    private void FireSingle(Quaternion rotation)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
        bullet.GetComponent<Bullet>().SetDamage(damage);
        if (PlayerAbilities.Instance.HasFireDamage)
            bullet.GetComponent<Bullet>().SetFireDamage(fireDamagePerSec, fireDuration);
    }

    private void FireSpread()
    {
        FireSingle(firePoint.rotation);
        FireSingle(firePoint.rotation * Quaternion.Euler(0, 0, spreadAngle));
        FireSingle(firePoint.rotation * Quaternion.Euler(0, 0, -spreadAngle));
    }
}
