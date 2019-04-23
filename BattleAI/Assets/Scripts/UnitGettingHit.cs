using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGettingHit : MonoBehaviour
{


    public TextMesh amountText;
    private int calculatedDistance;
    private float hitChanceByDistance;
    private float unitHitChance;
    private Unit unitScript;

    private int loss = 0;
    private System.Random random = new System.Random();


    // Start is called before the first frame update
    void Start()
    {

        EventHandler.InvokeProcedureAttack += ProcessHit;
        unitScript = gameObject.GetComponent<Unit>();
        amountText.text = unitScript.Amount.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }


    void ProcessHit(Vector3 attackUnitPosition, Vector3 attackCoordinates, UnitType unitType, LandscapeValues currentLandscape, int amount, float hitChance)
    {

        if (attackCoordinates.x == gameObject.transform.position.x && attackCoordinates.z == gameObject.transform.position.z)
        {
            calculatedDistance = CalculateDistance(attackUnitPosition, attackCoordinates);
            hitChanceByDistance = Mathf.Pow(0.80f, calculatedDistance);
            if (unitScript.UnitType == UnitType.Riffle)
            {
                //Program.environment.HitChanceByOperation.TryGetValue(CurrentOperation, out float operationHitChance);
                hitChance *= 0.75f * hitChanceByDistance; //0.75 is a temproray environment.HitChanceByOperation

                switch (unitType)
                {
                    case UnitType.Riffle:
                        hitChance *= currentLandscape.MultiplierOfHitChanceByRiffle;
                        Debug.Log("hitChance: " + hitChance + " :: " + "hitChanceByDistance: " + hitChanceByDistance);
                        for (int i = 1; i <= amount; i++)
                        {
                            double hit = random.NextDouble();
                            if (hitChance > (float)hit)
                            {
                                loss++;
                            }
                        }
                        break;
                    case UnitType.Cannon:
                        hitChance *= currentLandscape.MultiplierOfHitChanceByCannon * Mathf.Log(amount);
                        for (int i = 1; i <= unitScript.Amount; i++)
                        {
                            double hit = random.NextDouble();
                            if (hitChance > (float)hit)
                            {
                                loss++;
                            }
                        }
                        break;
                }
            }

            Debug.Log("UNIT: " + gameObject.transform.name + " WAS HIT BY: " + unitType + " CURRENT LANDSCAPE " + currentLandscape.tag + " DISTANCE: " + calculatedDistance + " LOST: " + loss);
            if (unitScript.Amount - loss > 0)
            {
                unitScript.Amount -= loss;
            }
            else
            {
                unitScript.Amount = 0;
            }
            amountText.text = unitScript.Amount.ToString();
            loss = 0;

        }

    }

    private int CalculateDistance(Vector3 attackingUnitPosition, Vector3 attackingCoordinates)
    {

        float xDistance = Mathf.Abs(attackingUnitPosition.x - attackingCoordinates.x);
        float yDistance = Mathf.Abs(attackingUnitPosition.z - attackingCoordinates.z);
        int distance = (int)Mathf.Round(Mathf.Sqrt(Mathf.Pow(xDistance, 2) + Mathf.Pow(yDistance, 2)));
        return distance;

    }

    /*private void GetHit(Unit unit, float hitChanceByDistance) {
        int loss = 0;
        Random random = new Random();
        float hitChance = hitChanceByDistance;
        if (UnitType.Equals(UnitType.Riffle))
        {
            Program.environment.HitChanceByOperation.TryGetValue(CurrentOperation, out float operationHitChance);
            hitChance *= unit.HitChance * operationHitChance;

            switch (unit.UnitType)
            {
                case UnitType.Riffle:
                    hitChance *= CurrentField.MultiplierOfHitChanceByRiffle;
                    for (int i = 1; i <= unit.Amount; i++)
                    {
                        double hit = random.NextDouble();
                        if (hitChance > hit)
                        {
                            loss++;
                        }
                    }
                    break;
                case UnitType.Cannon:
                    hitChance *= CurrentField.MultiplierOfHitChanceByCannon * unit.Amount;
                    for (int i = 1; i <= Amount; i++)
                    {
                        double hit = random.NextDouble();
                        if (hitChance > hit)
                        {
                            loss++;
                        }
                    }
                    break;
            }
        }

    } */

}
