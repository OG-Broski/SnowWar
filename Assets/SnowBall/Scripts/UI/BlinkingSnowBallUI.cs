using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BlinkingSnowBallUI : MonoBehaviour
{
    [SerializeField] private float _speedBlinking = 2f;
    [SerializeField] private bool _stopBlinking = false;
    [SerializeField] private Image _image;

    private void OnEnable()
    {
        ShootingState.OnAfterShot += GoTimer;
        Character.OnCanShoot +=StopBlinking;
    }
    private void OnDisable()
    {
        ShootingState.OnAfterShot -= GoTimer;
         Character.OnCanShoot -= StopBlinking;
    }
    private void Start()
    {   
        
        _image = GetComponent<Image>();
        StartCoroutine(Blinking(_image));
    }
 
    IEnumerator Blinking(Image image)
    {
        Color color = image.color;
        float alpha = 1.0f;

        while (true)
        {
            color.a = Mathf.MoveTowards(color.a, alpha, Time.deltaTime * _speedBlinking);
 
            image.color = color;
            if (color.a == alpha)
            {
                if (alpha == 1.0f)
                {
                    alpha = 0.0f;
                }
                else
                    alpha = 1.0f;
            }
           if(_stopBlinking){
                 color.a = 1f;
                 image.color= color;
                 break;
            }
            yield return null;
        }
    }
    private void GoTimer(){
        _stopBlinking = false;
        StartCoroutine(Blinking(_image));
    }
    private void StopBlinking(){
        _stopBlinking=true;
    }
}
