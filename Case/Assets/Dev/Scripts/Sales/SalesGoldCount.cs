using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalesGoldCount : MonoBehaviour
{
    Grid grid;
    public static SalesGoldCount instance;

    public int totalYellowGem, totalGreenGem, totalPinkGem;
    public int totalGold;
    public Text totalGoldtext, totalYellowText, totalPinkText,totalGreenText;
    void Start()
    {
        instance = this;
        totalGreenGem = 0;
        totalPinkGem = 0;
        totalYellowGem = 0;
        totalGold = 0;
        totalGoldtext.text = totalGold.ToString();
        totalYellowText.text = totalYellowGem.ToString();
        totalPinkText.text = totalGreenGem.ToString();
        totalGreenText.text = totalPinkGem.ToString();
    }

    
    void Update()
    {

    }

    private void increaseTotalGold(float goldPrice)
    {
        totalGold =(int)(totalGold + goldPrice);
        totalGoldtext.text = totalGold.ToString();
    }

    public void salesGem(float gemScale,string gemName)
    {
        if(gemName == "GemGreen")
        {
            totalGreenGem++;
            increaseTotalGold((gemScale + 20)*100);
            totalGreenText.text = totalGreenGem.ToString();

        }
        if (gemName == "GemPink")
        {
            totalPinkGem++;
            increaseTotalGold((gemScale + 10)*100);
            totalPinkText.text = totalPinkGem.ToString();

        }
        if (gemName == "GemYellow")
        {
            totalYellowGem++;
            increaseTotalGold((gemScale + 30)*100);
            totalYellowText.text = totalYellowGem.ToString();

        }
    }
}
