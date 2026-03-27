using UnityEngine;
public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject gun;
    private bool _isSword = true;
    private IWeapon _currentWeapon;

    void Start()
    {
        sword.SetActive(true);
        gun.SetActive(false);
        _currentWeapon = sword.GetComponent<IWeapon>();
    }

    public void SwitchWeapon()
    {
        _isSword = !_isSword;
        sword.SetActive(_isSword);
        gun.SetActive(!_isSword);

        if (_isSword)
            _currentWeapon = sword.GetComponent<IWeapon>();
        else
            _currentWeapon = gun.GetComponent<IWeapon>();

        Debug.Log($"Switched to: {(_isSword ? "Sword" : "Gun")}");
    }

    public void Attack()
    {
        _currentWeapon?.Attack();
    }
}