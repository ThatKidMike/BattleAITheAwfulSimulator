using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUnits : MonoBehaviour {

    void Start() {

        if(gameObject.name == "RedCannon")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        
        if(gameObject.name == "RedInfantry")
        {
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        }

        if (gameObject.name == "BlueCannon")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        if (gameObject.name == "BlueInfantry")
        {
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.blue;
        }

        EventHandler.InvokeSelectUnit += HighlightUnit;
    }


    void HighlightUnit(float x, float z) {

        if(gameObject.transform.position.x == x && gameObject.transform.position.z == z)
        {
            gameObject.transform.Find("Sphere").gameObject.SetActive(true);
            EventHandler.OnCurrentHighlightedUnit(gameObject);
        } 
        else
        {
            gameObject.transform.Find("Sphere").gameObject.SetActive(false);
        }
    }
    

}
