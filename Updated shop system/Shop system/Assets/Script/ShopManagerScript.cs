using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[6,6];
    [HideInInspector]public float coins;
    public Text ConinsTXT;
    public int currentSelection = 0;
    public GameObject selectionPrefab, selectionHolder;

    void Start()
    {
        coins = 101;
        ConinsTXT.text = "Coins: " + coins.ToString();

        //IDs
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;

        //price
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 100;
        shopItems[2, 3] = 150;
        shopItems[2, 4] = 150;
        shopItems[2, 5] = 300;

        //quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
        shopItems[3, 5] = 0;

        selectionHolder = Instantiate(selectionPrefab);
        selectionHolder.transform.position = GetItemPosition(currentSelection);
    }
    
    public Vector2 GetItemPosition(int itemIndex)
    {
        selectionHolder.transform.SetParent(transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(itemIndex).GetChild(2));
        return transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(itemIndex).GetChild(3).position;
    }

    public void Buy(int selectedIndex = -1)
    {
        GameObject ButtonRef;
        if (selectedIndex == -1)
        {
            ButtonRef = transform.parent.GetComponent<EventSystem>().currentSelectedGameObject;
        }
        else
        {
            ButtonRef = transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(selectedIndex).gameObject;

        }
        int tempID = ButtonRef.GetComponent<ButtonInfo>().ItemID;

        if (coins >= shopItems[2, tempID])
        {
            coins -= shopItems[2, tempID];
            shopItems[3, tempID]++;
            ConinsTXT.text = "Coins: " + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, tempID].ToString();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentSelection - 1 >= 0)
            {
                currentSelection--;
                selectionHolder.transform.position = GetItemPosition(currentSelection);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentSelection + 1 <= 4)
            {
                currentSelection++;
                selectionHolder.transform.position = GetItemPosition(currentSelection);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            // Load  Scene To Big Map
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Buy(currentSelection);
        }
    }


}
