using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int money = 100;
    public TMP_Text moneyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text="count: " + money;
    }
}
