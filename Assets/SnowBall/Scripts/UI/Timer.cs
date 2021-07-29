using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public static event Action OnPause;
    [SerializeField] private TextMeshProUGUI _timerText;
    private int _seconds = 0;
    private int _minutes = 0;
    private int _delta = 1;
    private void OnEnable()
    {
        GameSetting.GameTheEnd +=StartStop;
    }
    private void OnDisable()
    {
        GameSetting.GameTheEnd -=StartStop;
    }

    private void Start()
    {
        StartCoroutine(TimerFlow());
    }

    IEnumerator TimerFlow(){
        while(true){
            if(_seconds == 59){
                _minutes++;
                _seconds = -1;
            }
            _seconds +=_delta;
            _timerText.text = _minutes.ToString("D2") + " : " + _seconds.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

    public void StartStop(){
        if(this._delta == 0){
            this._delta =1;
            Time.timeScale = 1;
        }
        else
        {
            this._delta =0;
            Time.timeScale = 0;
            OnPause?.Invoke();
        }
    }
}
