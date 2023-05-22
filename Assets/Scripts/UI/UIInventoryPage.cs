using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItem itemPrefab;

    [SerializeField] private RectTransform contentPanel;

    [SerializeField] private UIInventoryDescription itemDescription;
    
    [SerializeField] private MouseFollower mouseFollower;

    List<UIInventoryItem> listOfItems = new List<UIInventoryItem>();

    public Sprite image, image2;
    public int quantity;
    public string title, description;

    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
        itemDescription.ResetDescription();
    }

    public void InitializeInventoryUI(int inventorysize){
        for(int i = 0; i < inventorysize; i++){
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }


    private void HandleItemSelection(UIInventoryItem obj){
        itemDescription.SetDescription(image, title, description);
        listOfItems[0].Select();
    }

    private void HandleBeginDrag(UIInventoryItem obj){
        mouseFollower.Toggle(true);
        mouseFollower.SetData(image, quantity);
    }

    private void HandleSwap(UIInventoryItem obj){
    }

    private void HandleEndDrag(UIInventoryItem obj){
        mouseFollower.Toggle(false);
    }
    private void HandleShowItemActions(UIInventoryItem obj){}


    public void Show(){
        gameObject.SetActive(true);
        itemDescription.ResetDescription();

        listOfItems[0].SetData(image, quantity);
        listOfItems[2].SetData(image2, quantity);
    }

    public void Hide(){
        gameObject.SetActive(false);
    }


}
