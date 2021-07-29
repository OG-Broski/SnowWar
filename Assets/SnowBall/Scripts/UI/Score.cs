using System;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public static  Action<int> ScoreUpdated;
    [SerializeField]private TextMeshProUGUI _scoreText;
    private void OnEnable()
    {
        Hit.OnHitEnemy += UpdateScore;
    }
    private void OnDisable()
    {
        _scoreText.text = "0";
        Hit.OnHitEnemy -= UpdateScore;
    }

    private void UpdateScore(Enemy enemy){
        _scoreText.text = $"{Convert.ToInt16(_scoreText.text) + enemy.dataEnemy.coins}";
        ScoreUpdated?.Invoke(Convert.ToInt16(_scoreText.text));
    }   
    
}
