using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    [SerializeField] private TextMeshProUGUI keysText;
    [SerializeField] private TextMeshProUGUI potionsText;
    [SerializeField] private Slider healthBar;
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
}
