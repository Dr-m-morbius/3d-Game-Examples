using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui : MonoBehaviour
{
    public TextMeshProUGUI coinAmountText; 
    private int _coinAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
     coinAmountText.text = "Coins: " + _coinAmount.ToString();
    }

    public void UpdateCoinCount()
    {
        _coinAmount++;
        coinAmountText.text = "Coins: " + _coinAmount.ToString();
    }

    // Update is called once per frame

}
    
        
    