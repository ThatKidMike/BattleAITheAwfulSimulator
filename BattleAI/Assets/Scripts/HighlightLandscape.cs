using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightLandscape : MonoBehaviour
{

    private Color tmpColor;

    private void OnMouseEnter() {

        tmpColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.blue;

        
    }
    
    private void OnMouseExit() {

        GetComponent<Renderer>().material.color = tmpColor;

    }


}
