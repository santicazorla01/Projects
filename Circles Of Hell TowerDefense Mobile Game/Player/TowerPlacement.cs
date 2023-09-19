using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private LayerMask PlacementCheckMask;
    [SerializeField] private LayerMask PlacementCollideMask;

    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private PlayerStats PlayerStatistics;

    private GameObject CurrentPlacingTower;

    // Update is called once per frame
    void Update()
    {
        if(CurrentPlacingTower != null)
        {
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo; 
            if(Physics.Raycast(camray, out HitInfo, 100f, PlacementCollideMask))
            {
                CurrentPlacingTower.transform.position = HitInfo.point;
            }

            if (Input.GetKeyDown(KeyCode.Q)){ //Stop Placing tower
                Destroy(CurrentPlacingTower);
                CurrentPlacingTower = null;
                return;
            }

            if (Input.GetMouseButtonDown(0) && HitInfo.collider.gameObject != null)
            {
                if (!HitInfo.collider.gameObject.CompareTag("CantPlace"))
                {
                    BoxCollider TowerCollider = CurrentPlacingTower.gameObject.GetComponent<BoxCollider>();
                    TowerCollider.isTrigger = true;

                    Vector3 BoxCenter = CurrentPlacingTower.gameObject.transform.position + TowerCollider.center;
                    Vector3 HalfExtents = TowerCollider.size / 2;
                   
                    if (!Physics.CheckBox(BoxCenter, HalfExtents, Quaternion.identity, PlacementCheckMask, QueryTriggerInteraction.Ignore))
                    {
                        TowerBehaviour CurrentTowerBehaviour = CurrentPlacingTower.GetComponent<TowerBehaviour>();
                        GameLoopManager.TowersInGame.Add(CurrentTowerBehaviour);

                        PlayerStatistics.AddMoney(-CurrentTowerBehaviour.SummonCost); //Substract money when placing tower

                        TowerCollider.isTrigger = false;
                        CurrentPlacingTower = null;
                    }
                }
            }

        }
    }

    public void SetTowerToPlace(GameObject tower)
    {
        int TowerSummonCost = tower.GetComponent<TowerBehaviour>().SummonCost;
        
        if(PlayerStatistics.GetMoney() >= TowerSummonCost) //if you have Money..
        {
            CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity); //Place a tower
        }
        else
        {
            Debug.Log("You neeed more money to purchase a " + tower.name);
        }     
    }
}
