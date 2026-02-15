using UnityEngine;
using TMPro;

public class InvantoryItem : MonoBehaviour
{
    public int cost = 10;
    private MoneyManager manager;
    public int count = 0;
    public TMP_Text countText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager= GameObject.Find("MoneyCanvas").GetComponent<MoneyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        countText.text="count: " + count;
    }
    public void Buy(){
       if(manager.money>=cost){
        count++;
        manager.money-=cost;
       } 
    }
    public void Sell(){
       if(count>0){
        count--;
        manager.money+=cost;
       } 
    }
}
