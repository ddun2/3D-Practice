using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData item;

    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;
    private Outline outline;
    
    public UIInventory inventory;

    public int index;
    public bool isEquipped;
    public int quantity;

    private void Awake()
    {
        outline = GetComponent<Outline>(); 
    }

    private void OnEnable()
    {
        outline.enabled = isEquipped;
    }

    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
        quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;

        if (outline != null)
        {
            outline.enabled = isEquipped;
        }
    }

    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = null;
    }

    public void OnClickButton()
    {
        inventory.SelectItem(index);
    }
}
