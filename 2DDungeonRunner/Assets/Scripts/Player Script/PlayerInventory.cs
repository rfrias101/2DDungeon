using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int maxKeys = 3;
    [SerializeField] private int maxPotions = 3;
    [SerializeField] private float potionHealAmount = 50f;
    private PlayerHealth _playerHealth;
    private int _keys = 0;
    private int _potions = 0;
    void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        UIManager.Instance.UpdateKeys(_keys, maxKeys);
        UIManager.Instance.UpdatePotions(_potions, maxPotions);
    }
    public bool HasKey() => _keys > 0;
    public bool HasPotion() => _potions > 0;

    public void AddKey()
    {
        if (_keys >= maxKeys) { Debug.Log("Can't carry more keys!"); return; }
        _keys++;
        UIManager.Instance.UpdateKeys(_keys, maxKeys);
    }

    public void AddPotion()
    {
        if (_potions >= maxPotions) { Debug.Log("Can't carry more potions!"); return; }
        _potions++;
        UIManager.Instance.UpdatePotions(_potions, maxPotions);
    }

    public void UseKey()
    {   if (_keys > 0)
        {
            _keys--;
            UIManager.Instance.UpdateKeys(_keys, maxKeys);
        }
    }
    public void UsePotion()
    {
        if (_potions <= 0) { Debug.Log("No potions!"); return; }
        if (_playerHealth.GetCurrentHealth() >= _playerHealth.GetMaxHealth())
        {
            Debug.Log("Already at full health!");
            return;
        }
        _potions--;
        UIManager.Instance.UpdatePotions(_potions, maxPotions);
        _playerHealth.Heal(potionHealAmount);
        Debug.Log($"Potion used! Health restored by {potionHealAmount}");
    }

    public int GetKeys() => _keys;
    public int GetPotions() => _potions;
    public int GetMaxKeys() => maxKeys;
    public int GetMaxPotions() => maxPotions;
}
