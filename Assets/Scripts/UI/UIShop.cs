using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    // private Transform container;
    // private Transform shopItemTemplate;

    // private void Awake(){
    //     container = transform.Find("Container");
    //     shopItemTemplate = container.Find("ShopItemTemplate");
    //     shopItemTemplate.gameObject.SetActive(false);
    // }

    // private void Start(){
    //     CreateItemButton(Item.GetSprite(Item.Item))
    // }

    // private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int positionIndex){
    //     Tranform shopItemTemplate = Instanciate(shopItemTemplate, container);
    //     RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

    //     float shopItemHeight = 30f;
    //     shopItemRectTransform.anchorPosition = new Vector2(0, -shopItemHeight*positionIndex);

    //     shopItemTransform.Find("itemName").GetComponent<TextMeshProGUI>();SetText(itemName);
    //     shopItemTransform.Find("costText").GetComponent<TextMeshProGUI>().SetText(itemCost.ToString());

    //     shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
    // }
}
