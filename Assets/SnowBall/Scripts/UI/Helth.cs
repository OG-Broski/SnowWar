
using UnityEngine;
using TMPro;
using System;



public class Helth : MonoBehaviour
{
    public static Action OnCharacterDead;
    public static Action<int> OnCharacterWin;
    [SerializeField] private int _helthCount = 3;
    [SerializeField] public int currentHelth { get=> _helthCount; set => _helthCount --;}
    [SerializeField] private TextMeshProUGUI _helthText;

    private void OnEnable()
    {
        Hit.OnHitCharacter += CheageHealth;
    }
      private void OnDisable()
    {
        Hit.OnHitCharacter -= CheageHealth;
    }

    private void Start()
    {   
        _helthText.text = Convert.ToString(_helthCount);
    }

    private void CheageHealth(){
        currentHelth--;
        _helthText.text = $"{currentHelth}";
        if(currentHelth<=0){
            OnCharacterDead?.Invoke();
        }
    }
}
