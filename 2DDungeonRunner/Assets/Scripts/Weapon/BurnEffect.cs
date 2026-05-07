using UnityEngine;
using System.Collections;
public class BurnEffect : MonoBehaviour
{
    public void ApplyBurn(float damagePerSec, float duration)
    {
        StartCoroutine(BurnRoutine(damagePerSec, duration));
    }

    private IEnumerator BurnRoutine(float damagePerSec, float duration)
    {
        float elapsed = 0f;
        IDamageable damageable = GetComponent<IDamageable>();
        while (elapsed < duration)
        {
            yield return new WaitForSeconds(1f);
            damageable?.TakeDamage(damagePerSec);
            elapsed += 1f;
        }
    }
}
