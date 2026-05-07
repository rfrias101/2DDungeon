using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField] private GameObject _gameOverPanel;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    public void OnPlayerDied()
    {
        Debug.Log("Game Over!");
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
