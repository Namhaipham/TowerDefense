using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Node  : MonoBehaviour
{
    public Color hovercolor;
   
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startColor;

    public Color notEnoughMoneyColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public int UpgradeTime = 0;
    
    
    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
        
       
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    
    private void OnMouseDown()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if(turret != null)
        {
            buildManager.selectNode(this);
            return; 
        }
        if (!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.GetTurretToBuild());
    }
    

    void BuildTurret(TurretBluePrint blueprint)
    {
        if (PlayerStates.Money < blueprint.cost)
        {
            
            Notice.notice_audio.Play();
            
            return;
        }
        
        PlayerStates.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = blueprint;

        Debug.Log("Turret build! Money left: " + PlayerStates.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStates.Money < turretBluePrint.UpgradeCost)
        {
            Debug.Log("Not enough money to upgrade");
            Notice.notice_audio.Play();
            return;
        }
        else
        {
            PlayerStates.Money -= turretBluePrint.UpgradeCost;
            // Xoa di cai cong trinh cu
            Destroy(turret);

            //Nang cap 
            GameObject _turret = (GameObject)Instantiate(turretBluePrint.UpgradePrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            UpgradeTime++;
            Debug.Log("Turret Upgraded!");
        }
    }
    public void UpgradeTurretLV_2()
    {
        if (PlayerStates.Money < turretBluePrint.UpgradeCostLV_2)
        {
            Debug.Log("Not enough money to upgrade");
            Notice.notice_audio.Play();
            return;
        }
        else
        {
            PlayerStates.Money -= turretBluePrint.UpgradeCostLV_2;
            // Xoa di cai cong trinh cu
            Destroy(turret);

            //Nang cap 
            GameObject _turret = (GameObject)Instantiate(turretBluePrint.UpgradePrefab_2, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            UpgradeTime++;
            Debug.Log("Turret Upgraded!");
        }
    }
    public void UpgradeTurretLV_3()
    {
        if (PlayerStates.Money < turretBluePrint.UpgradeCostLV_3)
        {
            Debug.Log("Not enough money to upgrade");
            Notice.notice_audio.Play();
            return;
        }
        else
        {
            PlayerStates.Money -= turretBluePrint.UpgradeCostLV_3;
            // Xoa di cai cong trinh cu
            Destroy(turret);

            //Nang cap 
            GameObject _turret = (GameObject)Instantiate(turretBluePrint.UpgradePrefab_3, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            UpgradeTime++;
            Debug.Log("Turret Upgraded!");
        }
    }
    public void SellTurret()
    {
        PlayerStates.Money += turretBluePrint.GetSellAmount();

        Destroy(turret);
        turretBluePrint = null;
    }
    void OnMouseEnter()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;  

        if (buildManager.HasMoney)
        {
            rend.material.color = hovercolor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    } 


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
