using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    [SerializeField] private GameObject _restarPanel;
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private Helth _helt;

    private void OnEnable()
    {
        GameSetting.GameTheEnd +=ShowPanel;
    }
    private void OnDisable()
    {
        GameSetting.GameTheEnd -=ShowPanel;
    }

    private void ShowPanel(){
        _restarPanel.SetActive(true);
        if(_helt.currentHelth >=1){
            for(int i = 0; i<_helt.currentHelth;i++){
                _stars[i].SetActive(true);
            }
        }
    }

}
