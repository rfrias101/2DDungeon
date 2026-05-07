using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    public static PlayerProgression Instance;
    private int _level = 1;

    void Awake() => Instance = this;
    void Start()
    {
        UIManager.Instance.UpdateLevel(_level);
    }

    public int GetLevel() => _level;

    public void LevelUp()
    {
        _level++;
        Debug.Log($"Level up! Now level {_level}");
        UIManager.Instance.UpdateLevel(_level);
        PlayerAbilities.Instance.UnlockAbilities(_level);
    }
}
