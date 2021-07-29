using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetting : MonoBehaviour
{
    public static Action GameTheEnd;
    public static Action GameRestar;
    private void OnEnable()
    {
        Score.ScoreUpdated +=CheckWin;
        Helth.OnCharacterDead +=GameEnd;
    }
    private void OnDisable()
    {
        Score.ScoreUpdated -=CheckWin;
        Helth.OnCharacterDead -=GameEnd;
    }
    [SerializeField] private int _countPointToWin = 10;

    private void CheckWin(int score){
        if(score>=_countPointToWin){
            GameEnd();
        }
    }

    private void GameEnd(){
            GameTheEnd?.Invoke();
        }
    public void RestartGame(){
        GameRestar?.Invoke();
        SceneManager.LoadScene(0);
    }
}
