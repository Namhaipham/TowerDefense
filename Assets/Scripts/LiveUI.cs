using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour
{
    public Text text_live;

    public void Update()
    {
        text_live.text = PlayerStates.HealthCurrency.ToString() + " Lives"; 
    }

}
