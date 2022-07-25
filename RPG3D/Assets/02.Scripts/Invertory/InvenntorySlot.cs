using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenntorySlot : MonoBehaviour
{
    private Image _IconImage;
    private Text _numText;

    private Item _item;
    public Item Item
    {
        set
        {
            if(val ue =)

            _inconImage.sprite = value.icon;
            if (vlaue,num>1)
            {
                _nextText.text = valuename;

            }

        }

    }

    private void Awake()
    {
        // _IconImage = transform.FindChild("Icon")
        _IconImage = transform.GetChild(0).GetComponent<Image>;
        _numText = transform.GetChild(0).GetComponent<text>;
    }




}
