using UnityEngine;

public class EnemyScaling : MonoBehaviour
{
    private static readonly float[] healthMultipliers = { 1f, 1.5f, 2f };
    private static readonly float[] damageMultipliers = { 1f, 1.2f, 1.4f };
    private static readonly float[] speedMultipliers = { 1f, 1.1f, 1.2f };

    public static EnemyData ScaleData(EnemyData baseData, int level)
    {
        int index = Mathf.Min(level - 1, healthMultipliers.Length - 1);
        return new EnemyData
        {
            health = baseData.health * healthMultipliers[index],
            dmg = baseData.dmg * damageMultipliers[index],
            speed = baseData.speed * speedMultipliers[index]
        };
    }
}
