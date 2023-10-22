using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text UpgradeCost;
    public Text UpgradeCostLV_2;
    public Text UpgradeCostLV_3;
    public Button UpgradeButton;
    public Button UpgradeButtonLV_2;
    public Button UpgradeButtonLV_3;
    [HideInInspector]
    private Node target;
    public Text Sell_amount;
    public void Start()
    {
        UpgradeButtonLV_2.interactable = false;
        UpgradeButtonLV_3.interactable = false;
    }
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        UpgradeCost.text = "$" + target.turretBluePrint.UpgradeCost;
        UpgradeButton.interactable = true;
        

        if (target.UpgradeTime == 1)
        {
            UpgradeCostLV_2.text = "$" + target.turretBluePrint.UpgradeCostLV_2;
            UpgradeCost.text = "Done";
            UpgradeButtonLV_2.interactable = true;
            UpgradeButton.interactable = false;

        }
        
        if (target.UpgradeTime == 2)
        {
            UpgradeCostLV_3.text = "$" + target.turretBluePrint.UpgradeCostLV_3;
            UpgradeCostLV_2.text = "Done";
            UpgradeButtonLV_3.interactable = true;
            UpgradeButton.interactable = false;
            UpgradeButtonLV_2.interactable = false;
        }
        
        else if (target.UpgradeTime >= 3)
        {
            
            UpgradeCostLV_3.text = "Done";
            
        }
        
        Sell_amount.text = "$" + target.turretBluePrint.GetSellAmount();
        ui.SetActive(true);


    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        
        BuildManager.instance.DeselectNode();
        
    }
    public void UpgradeLV_2()
    {
        target.UpgradeTurretLV_2();
        BuildManager.instance.DeselectNode();
        UpgradeButtonLV_2.interactable = false;
    }
    public void UpgradeLV_3()
    {
        target.UpgradeTurretLV_3();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
