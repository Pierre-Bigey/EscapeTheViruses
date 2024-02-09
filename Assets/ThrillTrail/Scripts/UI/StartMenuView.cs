
using ThrillTrail.Services;
using TMPro;
using UnityEngine;

public class StartMenuView : MonoBehaviour
{
    private PlayerPrefService _playerPrefsService;
    
    [SerializeField] private TMP_Text _scoreText;
    void Start()
    {
        _playerPrefsService = ServiceLocator.Instance.Get<PlayerPrefService>();
        UpdateHighScore();
    }
    
    //Update the highScore using _playerPrefsService
    public void UpdateHighScore()
    {
        _scoreText.text = _playerPrefsService.GetHighScore().ToString() + "m";
    }
    
    
    
    
    
}
