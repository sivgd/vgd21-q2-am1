using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUpgradeButtonScript : MonoBehaviour
{
    public TextMeshPro[] textMeshPros;
    public Tower selectedTower;
    public TowerInfo towerInfo;

    public Color defaultColor;
    public Color nextStageColor;
    public Color cantBuyColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (selectedTower != null)
        {
            if (selectedTower.nextStage != null)
            {
                SetNextStage();
            }
        }
    }

    private void OnMouseExit()
    {
        if (selectedTower != null)
        {
            SetCurrentStage();
        }
    }

    private void OnMouseDown()
    {
        if (selectedTower != null)
        {
            selectedTower.Upgrade();
            SetCurrentStage();

            selectedTower = null;
        }
    }

    private void SetCurrentStage()
    {
        for (int i = 0; i < textMeshPros.Length; i++)
        {
            textMeshPros[i].color = Color.white;
        }

        towerInfo.SetTowerInfo(selectedTower.gameObject);
    }

    private void SetNextStage()
    {
        
        if(selectedTower.nextStage.GetComponent<Tower>().actualCost <= CabbageCounter.cabbageAmount)
        {
            //Have enough money
            for (int i = 0; i < textMeshPros.Length; i++)
            {
                textMeshPros[i].color = nextStageColor;
            }
        }
        else
        {
            //Don't have enough money
            for (int i = 0; i < textMeshPros.Length; i++)
            {
                textMeshPros[i].color = cantBuyColor;
            }
        }
        
        towerInfo.SetTowerInfo(selectedTower.nextStage, selectedTower.transform.position);
    }
}
