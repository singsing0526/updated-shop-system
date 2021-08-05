﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public Text Itemdis;
    public GameObject ShopManager;
    private ShopManagerScript SMS;

    private void Awake()
    {
        SMS = ShopManager.GetComponent<ShopManagerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PriceTxt.text = "Price: $" + SMS.shopItems[2, ItemID].ToString();
        QuantityTxt.text =  SMS.shopItems[3, ItemID].ToString();
    }
}
