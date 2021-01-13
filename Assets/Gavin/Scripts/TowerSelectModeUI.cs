using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerSelectModeUI : MonoBehaviour
{
    public bool isLeftArrow;
    public Color hoverColor;
    public Color clickColor;
    public Color defaultColor;

    public GameObject gameMaster;
    private void Start()
    {
        gameObject.GetComponent<TextMeshPro>().color = defaultColor;
    }

    // Start is called before the first frame update
    private void OnMouseEnter()
    {
        gameObject.GetComponent<TextMeshPro>().color = hoverColor;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<TextMeshPro>().color = defaultColor;
    }

    private void OnMouseDown()
    {
        gameMaster.GetComponent<TowerInfo>().NextTowerSelection(isLeftArrow);
        gameObject.GetComponent<TextMeshPro>().color = clickColor;
    }
}
