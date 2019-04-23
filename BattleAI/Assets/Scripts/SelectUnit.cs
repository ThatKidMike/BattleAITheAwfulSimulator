using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{

    RaycastHit hit;
    RaycastHit unitHit;
    RaycastHit landscapeHit;
    LandscapeValues landscapeValuesScript;
    GameObject selectedUnit;
    UnitType currentUnit;

    void Start() {

        EventHandler.InvokeWasUnitMoved += WasUnitMoved;
        EventHandler.InvokeCurrentHighlightedUnit += SetSelectedUnit;
        EventHandler.InvokeDeselectUnit += DeselectUnit;

    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                EventHandler.OnSelectUnit(hit.transform.position.x, hit.transform.position.z);
                landscapeValuesScript = hit.transform.GetComponent<LandscapeValues>();
                if(landscapeValuesScript.Taken)
                {
                    Debug.Log("TAKEN");
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            //testing selected unit information
            if(selectedUnit != null)
            {
                Debug.Log(selectedUnit.tag);
            } 
            else
            {
                Debug.Log("Empty");
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                //delay added
                if (hit.transform.tag == "Water")
                {
                    EventHandler.OnMoveUnit(hit.transform.position.x, hit.transform.position.z, landscapeValuesScript.CannonMovingTime, landscapeValuesScript.InfantryMovingTime, false);                   
                }
                else
                {
                    EventHandler.OnMoveUnit(hit.transform.position.x, hit.transform.position.z, landscapeValuesScript.CannonMovingTime, landscapeValuesScript.InfantryMovingTime, true);
                }

                Debug.DrawRay(hit.transform.position, Vector3.up, Color.cyan);

                if (Physics.Raycast(hit.transform.position, Vector3.up, out unitHit, 100))
                {
                    Debug.Log("HIT: " + unitHit.transform.tag);
                }
            }
            
        }

        //Need to add % chances depending on the field and distance
       /* if(Input.GetMouseButtonDown(2))
        {

            if (selectedUnit != null)
            {
                if (selectedUnit.transform.tag == "Infantry")
                {
                    currentUnit = UnitType.Riffle;
                }
                else
                {
                    currentUnit = UnitType.Cannon;
                }

                //Way for getting info about what landscape was hit
                //Debug.DrawRay(new Vector3(0, -1f, 0), Vector3.up, Color.cyan);

                if(Physics.Raycast(new Vector3(0, -1f, 0), Vector3.up, out landscapeHit, 120)) {
                    Debug.Log(landscapeHit.transform.tag);
                } 

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out landscapeHit, 100))
                {
                    Debug.Log(landscapeHit.transform.position);
                    EventHandler.OnProcedureAttack(selectedUnit.transform.position, landscapeHit.transform.position, currentUnit, landscapeHit.transform.gameObject);
                }

                

            }

        } */
        
    }

    void WasUnitMoved(bool wasMoved) {

        if(wasMoved)
        {
            landscapeValuesScript = hit.transform.GetComponent<LandscapeValues>();
        }

    }

    void SetSelectedUnit(GameObject highlightedUnit) {

        selectedUnit = highlightedUnit;

    }

    void DeselectUnit(bool allUnitsDeselected) {

        if(allUnitsDeselected)
        {
            selectedUnit = null;
        }

    }

}
