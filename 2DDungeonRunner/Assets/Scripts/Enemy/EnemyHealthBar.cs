using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    private Camera _camera;

    void Awake()
    {
        _camera = Camera.main;
    }
    void LateUpdate()
    {
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _camera.transform.up);
    }
    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void UpdateHealth(float currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}
