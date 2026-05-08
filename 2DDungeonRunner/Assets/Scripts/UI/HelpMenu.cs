using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    [SerializeField] private GameObject _helpMenu;
    
    public void PauseGame()
    {
        Time.timeScale = 0f;
        _helpMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        _helpMenu.SetActive(false);
    }
}
