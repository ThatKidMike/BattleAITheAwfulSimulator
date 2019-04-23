using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateGoal : MonoBehaviour
{
    public float GoalCoordinatesX { get; set; }
    public float GoalCoordinatesZ { get; set; }
    public float TaskTime { get; set; }
    public char WhichArmy { get; set; }
    public int RedStartingUnitAmount { get; set; }
    public int BlueStartingUnitAmount { get; set; }
    public int RedUnitsLefts { get; set; }
    public int BlueUnitsLefts { get; set; }
    public float PointsRed { get; set; }
    public float PointsBlue { get; set; }
    private int VicinityUnit { get; set; } = 10000;
    private int tmpVicinityUnit { get; set; }

    public List<GameObject> redArmy { get; set; }
    public List<GameObject> blueArmy { get; set; }

    public void Start()
    {

        EventHandler.InvokeUltimateGoalUnitReport += ProcessResults;
        StartCoroutine(WaitTime(10f));

    }


    public void ProcessResults(float x, float z, char whichArmy)
    {

        Debug.Log("X: " + x + ";" + "Z: " + z + " ARMY: " + whichArmy);

        tmpVicinityUnit = CalculateDistance(x, z, GoalCoordinatesX, GoalCoordinatesZ);

        if (tmpVicinityUnit < VicinityUnit)
        {

            VicinityUnit = tmpVicinityUnit;

        }

        if (whichArmy == 'r')
        {
            PointsRed = 0;
        }
        else if (whichArmy == 'b')
        {
            PointsBlue = 0;
        }


    }

    private IEnumerator WaitTime(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        EventHandler.OnTimesUp();

    }

    private int CalculateDistance(float firstX, float firstZ, float secondX, float secondZ)
    {

        float xDistance = Mathf.Abs(firstX - secondX);
        float yDistance = Mathf.Abs(firstZ - secondZ);
        int distance = (int)Mathf.Round(Mathf.Sqrt(Mathf.Pow(xDistance, 2) + Mathf.Pow(yDistance, 2)));
        return distance;

    }


}
