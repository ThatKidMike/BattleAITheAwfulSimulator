using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeselector : MonoBehaviour {

    private GameObject[] infantryUnits;
    private GameObject[] cannonUnits;
    private bool isAnyUnitHighlighted;

    void Start() {

        infantryUnits = GameObject.FindGameObjectsWithTag("Infantry");
        cannonUnits = GameObject.FindGameObjectsWithTag("Cannon");
        
    }

    // Update is called once per frame
    void Update() {

        isAnyUnitHighlighted = false;

        foreach(GameObject infantry in infantryUnits)
        {
            foreach(GameObject cannon in cannonUnits)
            {
                if(cannon.transform.Find("Sphere").gameObject.activeInHierarchy)
                {
                    isAnyUnitHighlighted = true;
                    break;
                }
            }

            if(infantry.transform.Find("Sphere").gameObject.activeInHierarchy)
            {
                isAnyUnitHighlighted = true;
                break;
            }
        }

        if(!isAnyUnitHighlighted)
        {
            EventHandler.OnDeselectUnit(true);
        }
        
    }
}
