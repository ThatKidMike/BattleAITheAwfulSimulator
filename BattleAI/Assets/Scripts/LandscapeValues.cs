using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LandscapeValues : MonoBehaviour {

    public FieldType FieldType { set; get; }

    void Start() {

        EventHandler.InvokeSetUnitOnField += SetUnitOnThisField;
        EventHandler.InvokeClearUnitOnField += ClearUnitOnThisField;

        if (gameObject.tag == "Grass")
        {
            FieldType = FieldType.Grass;
            CannonMovingTime = 1f;
            InfantryMovingTime = 0.5f;
            MultiplierOfHitChanceByRiffle = 1f;
            MultiplierOfHitChanceByCannon = 1f;
            ValidToMove = true;
        }
        if(gameObject.tag == "DenseGrass")
        {
            FieldType = FieldType.DenseGrass;
            CannonMovingTime = 2f;
            InfantryMovingTime = 1f;
            MultiplierOfHitChanceByRiffle = 1f;
            MultiplierOfHitChanceByCannon = 1f;
            ValidToMove = true;
        }
        if(gameObject.tag == "SolidWay")
        {
            FieldType = FieldType.SolidWay;
            CannonMovingTime = 0.5f;
            InfantryMovingTime = 0.1f;
            MultiplierOfHitChanceByRiffle = 1f;
            MultiplierOfHitChanceByCannon = 1f;
            ValidToMove = true;
        }
        if(gameObject.tag == "Forest")
        {
            FieldType = FieldType.Forest;
            CannonMovingTime = 3f;
            InfantryMovingTime = 2f;
            MultiplierOfHitChanceByRiffle = 1f;
            MultiplierOfHitChanceByCannon = 1f;
            ValidToMove = true;
        }
        if(gameObject.tag == "Stone")
        {
            FieldType = FieldType.Stone;
            CannonMovingTime = 2f;
            InfantryMovingTime = 1f;
            MultiplierOfHitChanceByRiffle = 1f;
            MultiplierOfHitChanceByCannon = 1f;
            ValidToMove = true;
        }
        if(gameObject.tag == "Water")
        {
            FieldType = FieldType.Water;
            CannonMovingTime = 0f;
            InfantryMovingTime = 0f;
            MultiplierOfHitChanceByRiffle = 1f;
            MultiplierOfHitChanceByCannon = 1f;
            ValidToMove = false;
        }

    }

    public float CannonMovingTime { set; get; }
    public float InfantryMovingTime { set;  get; }
    public float MultiplierOfHitChanceByRiffle { set;  get; }
    public float MultiplierOfHitChanceByCannon { set;  get; }
    public GameObject UnitOnField { set;  get; }
    public int XCoordinates { set;  get; }
    public int YCoordinates { set;  get; }
    public bool ValidToMove { set; get; }
    public bool Taken { set; get; }

    /* 
    public int CalculateDistance(Field field) 
    {
        int xDistance = Math.Abs(XCoordinates - field.XCoordinates);
        int yDistance = Math.Abs(YCoordinates - field.YCoordinates);
        int distance = (int)Math.Round(Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2)));
        return distance;
    }
    */

    private void SetUnitOnThisField(float x, float z, GameObject unitOnThisField) {

        if(transform.position.x == x && transform.position.z == z)
        {
            UnitOnField = unitOnThisField;
            Taken = true;
        }

    }

    private void ClearUnitOnThisField(float x, float z, GameObject unitOnThisField) {

        if (transform.position.x == x && transform.position.z == z)
        {
            UnitOnField = null;
            Taken = false;
        }

    }



}
