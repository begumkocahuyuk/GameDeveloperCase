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
        totalGreenGem = PlayerPrefs.GetInt("totalGreenGem");
        totalPinkGem = PlayerPrefs.GetInt("totalPinkGem");
        totalYellowGem = PlayerPrefs.GetInt("totalYellowGem");
        totalGold = PlayerPrefs.GetInt("totalGold");
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
        PlayerPrefs.SetInt("totalGold", totalGold);
        totalGoldtext.text = totalGold.ToString();
    }

    public void salesGem(float gemScale,string gemName)
    {
        if(gemName == "GemGreen")
        {
            totalGreenGem++;
            PlayerPrefs.SetInt("totalGreenGem",totalGreenGem);
            increaseTotalGold((gemScale + 20)*100);
            totalGreenText.text = totalGreenGem.ToString();

        }
        if (gemName == "GemPink")
        {
            totalPinkGem++;
            PlayerPrefs.SetInt("totalPinkGem", totalPinkGem);
            increaseTotalGold((gemScale + 10)*100);
            totalPinkText.text = totalPinkGem.ToString();

        }
        if (gemName == "GemYellow")
        {
            totalYellowGem++;
            PlayerPrefs.SetInt("totalYellowGem", totalYellowGem);
            increaseTotalGold((gemScale + 30)*100);
            totalYellowText.text = totalYellowGem.ToString();

        }
    }
}
