using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public static PlayerAbilities Instance;

    public bool HasFireDamage { get; private set; }
    public bool HasBulletSpread { get; private set; }
    public bool HasSwordWave { get; private set; }

    void Awake() => Instance = this;

    public void UnlockAbilities(int level)
    {
        switch (level)
        {
            case 2:
                HasFireDamage = true;
                Debug.Log("Ability unlocked: Fire Damage!");
                break;
            case 3:
                HasBulletSpread = true;
                Debug.Log("Ability unlocked: Bullet Spread!");
                break;
            case 4:
                HasSwordWave = true;
                Debug.Log("Ability unlocked: Sword Wave!");
                break;
        }
    }
}
