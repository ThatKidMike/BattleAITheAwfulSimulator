using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public delegate void SelectUnit(float x, float z);
    public static event SelectUnit InvokeSelectUnit;
    public static void OnSelectUnit(float x, float z)
    {
        InvokeSelectUnit(x, z);
    }

    public delegate void MoveUnit(float x, float z, float cannonDelay, float infantryDelay, bool validToMove);
    public static event MoveUnit InvokeMoveUnit;
    public static void OnMoveUnit(float x, float z, float cannonDelay, float infantryDelay, bool validToMove)
    {
        InvokeMoveUnit(x, z, cannonDelay, infantryDelay, validToMove);
    }

    public delegate void WasUnitMoved(bool wasMoved);
    public static event WasUnitMoved InvokeWasUnitMoved;
    public static void OnWasUnitMoved(bool wasMoved)
    {
        InvokeWasUnitMoved(wasMoved);
    }

    public delegate void CurrentHighlightedUnit(GameObject highlightedUnit);
    public static event CurrentHighlightedUnit InvokeCurrentHighlightedUnit;
    public static void OnCurrentHighlightedUnit(GameObject highlightedUnit)
    {
        InvokeCurrentHighlightedUnit(highlightedUnit);
    }

    public delegate void DeselectUnit(bool allUnitsDeselected);
    public static event DeselectUnit InvokeDeselectUnit;
    public static void OnDeselectUnit(bool allUnitsDeselected)
    {
        InvokeDeselectUnit(allUnitsDeselected);
    }

    //Distance from the target need to be added as a parameter in here later on and percentage of chances depending on the 
    //ground and so on
    public delegate void ProcedureAttack(Vector3 selectedUnit, Vector3 attackCoordinates, UnitType unitType, LandscapeValues currentLandscape, int amount, float hitChance);
    public static event ProcedureAttack InvokeProcedureAttack;
    public static void OnProcedureAttack(Vector3 selectedUnit, Vector3 attackCoordinates, UnitType unitType, LandscapeValues currentLandscape, int amount, float hitChance)
    {
        InvokeProcedureAttack(selectedUnit, attackCoordinates, unitType, currentLandscape, amount, hitChance);
    }

    public delegate void SetUnitOnField(float x, float z, GameObject unitOnField);
    public static event SetUnitOnField InvokeSetUnitOnField;
    public static void OnSetUnitOnField(float x, float z, GameObject unitOnField)
    {
        InvokeSetUnitOnField(x, z, unitOnField);
    }

    public delegate void ClearUnitOnField(float x, float z, GameObject unitOnField);
    public static event ClearUnitOnField InvokeClearUnitOnField;
    public static void OnClearUnitOnField(float x, float z, GameObject unitOnField)
    {
        InvokeClearUnitOnField(x, z, unitOnField);
    }

    public delegate void UltimateGoalUnitReport(float x, float z, char wichArmy);
    public static event UltimateGoalUnitReport InvokeUltimateGoalUnitReport;
    public static void OnUltimateGoalUnitReport(float x, float z, char wichArmy)
    {
        InvokeUltimateGoalUnitReport(x, z, wichArmy);
    }

    public delegate void TimesUp();
    public static event TimesUp InvokeTimesUp;
    public static void OnTimesUp()
    {
        InvokeTimesUp();
    }

}
