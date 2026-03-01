using UnityEngine;
using TMPro;

public class InvantoryItem : MonoBehaviour
{
    public int cost = 10;
    private MoneyManager manager;
    public int count = 0;
    public TMP_Text countText;
    public GameObject item;
    private PlaceFurniture place;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager= GameObject.Find("MoneyCanvas").GetComponent<MoneyManager>();
        place = GameObject.Find("PlaceHandler").GetComponent<PlaceFurniture>();
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

    public void OnClick()
    {
        if (count > 0 && place.curr == null)
        {
            place.curr = Instantiate(item);
            count--;
        }
        else if (place.curr != null && place.curr.GetComponent<Dimensions>().name == item.GetComponent<Dimensions>().name)
        {
            place.curr = null;
            count++;
        }
    }
}
