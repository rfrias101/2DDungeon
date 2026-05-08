using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    [SerializeField] private TextMeshProUGUI keysText;
    [SerializeField] private TextMeshProUGUI potionsText;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI roomNumberText;

    [SerializeField] private TextMeshProUGUI weaponText;

    [SerializeField] private TextMeshProUGUI playerLvl;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateKeys(int current, int max)
    {
        keysText.text = $"Keys: {current}/{max}";
    }

    public void UpdatePotions(int current, int max)
    {
        potionsText.text = $"Potions: {current}/{max}";
    }

    public void UpdateHealth(float current, float max)
    {
        healthBar.value = current / max;
    }

    public void UpdateWeapon(string weaponName)
    {
        weaponText.text = $"Weapon: {weaponName}";
    }

    public void UpdateLevel(int level)
    {
        playerLvl.text = $"Level: {level}";
    }

    public void UpdateRoomNumber(int floor)
    {
        roomNumberText.text = $"Floor: {floor}";
    }
}
