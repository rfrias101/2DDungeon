using UnityEngine;
public interface IInput
{
    Vector2 GetInputDetection();
    bool GetInteractPressed();
    bool GetAttackPressed();
    bool GetSwitchWeaponPressed();
    bool GetConsumePressed();

}
