using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill2048 : MonoBehaviour
{
    
    public int value;
    [SerializeField] Text valueDisplay;
    [SerializeField] float speed;
    bool isCombine;


    public void FillValueUpdate(int input)
    {
        value = input;
        valueDisplay.text = input.ToString();
    }   

    private void Update()
    {
        
        if (transform.localPosition != Vector3.zero)
        {
            isCombine = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        else if (isCombine == false)
        {
            if (transform.parent.GetChild(0) != this.transform)
                Destroy(transform.parent.GetChild(0).gameObject);
            isCombine = true;
        }
    }

    public void Double()
    {
        value *= 2;
        GameController2048.instance.HigherScore(value);
        valueDisplay.text = value.ToString();
        GameController2048.instance.WinCheck(value);
    }
}
