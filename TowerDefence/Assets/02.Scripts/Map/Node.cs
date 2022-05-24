using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // 마우스 클릭시 색변화
    public float towerOffsetY;
    private Tower towerBuilt;
    private Renderer rend;
    private Color originalColor;
    public Color buildAvailableColor;
    public Color buildNotAvailableColor;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if (TowerHandler.instance.isSelected)
        {
            TowerHandler.instance.transform.position = transform.position + Vector3.up * towerOffsetY;

            if (towerBuilt == null)
            {
                rend.material.color = buildAvailableColor;
            }
            else
            {
                rend.material.color = buildNotAvailableColor;
            }
        }
        rend.material.color = buildAvailableColor;
    }

    private void OnMouseExit()
    {
        TowerHandler.instance.SendFar();
        rend.material.color = originalColor;
    }
}
