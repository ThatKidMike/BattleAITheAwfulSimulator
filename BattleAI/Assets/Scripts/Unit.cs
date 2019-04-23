using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public UnitType UnitType { get; set; }
    public int Amount { get; set; }
    public char Army { get; set; }
    public UnitOperation CurrentOperation { get; set; }
    public float HitChance { get; set; }
    public bool DuringFiring { get; set; }

    private GameObject selectIndicator;
    private RaycastHit landscapeHit;
    private LandscapeValues standingGround;
    public GameObject preparingDefense;
    public GameObject defenseReady;

    public bool keepFiring = false;
    public bool coroutineStarted = false;
    public bool isOnDefense = false;
    public bool defenseDuringPreparing = false;
    private bool initalFieldSet = false;
    public List<GameObject> seenUnits = new List<GameObject>();

    void Start()
    {

        selectIndicator = gameObject.transform.Find("Sphere").gameObject;

        if (gameObject.transform.tag == "Infantry")
        {
            UnitType = UnitType.Riffle;
            Amount = 1000;
        }
        else
        {
            UnitType = UnitType.Cannon;
            Amount = 10;
        }


        if (gameObject.transform.name.Contains("Red"))
        {
            Army = 'r';
        }
        else if (gameObject.transform.name.Contains("Blue"))
        {
            Army = 'b';
        }


        HitChance = 1f;

        EventHandler.InvokeWasUnitMoved += SendCurrentPosition;
        EventHandler.InvokeTimesUp += SendFinalResults;

    }

    void Update()
    {

        if (!initalFieldSet)
        {
            EventHandler.OnSetUnitOnField(transform.position.x, transform.position.z, gameObject);
            initalFieldSet = true;
        }

        if (selectIndicator.activeInHierarchy)
        {

            if (Input.GetMouseButtonDown(2))
            {
                //Way for getting info about what landscape was hit
                //Debug.DrawRay(new Vector3(0, -1f, 0), Vector3.up, Color.cyan);

                /* if(Physics.Raycast(new Vector3(0, -1f, 0), Vector3.up, out landscapeHit, 120)) {
                     Debug.Log(landscapeHit.transform.tag); //This will be used instead of out landscapeHit down there
                 } */
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out landscapeHit, 100) && !keepFiring)
                {
                    standingGround = landscapeHit.transform.gameObject.GetComponent<LandscapeValues>();
                }

                if (!keepFiring)
                {
                    keepFiring = true;
                }
                else if (keepFiring)
                {
                    keepFiring = false;
                }

            }

            //invoking defence
            if (Input.GetKeyDown(KeyCode.H))
            {
                StartCoroutine(DefenseDelay(5f));
            }

        }

        if (keepFiring)
        {
            DuringFiring = true;
            //Debug.Log(landscapeHit.transform.position);
            //EventHandler.OnProcedureAttack(gameObject.transform.position, landscapeHit.transform.position, UnitType, standingGround, Amount, HitChance);
            if (!coroutineStarted)
            {
                StartCoroutine(ProcessFiring(3f, landscapeHit.transform.position, UnitType, standingGround, Amount, HitChance));
            }

        }
        else if (!keepFiring)
        {
            DuringFiring = false;
        }

        if (DuringFiring && isOnDefense)
        {
            CurrentOperation = UnitOperation.FiringDefence;
        }

    }


    private IEnumerator DefenseDelay(float waitTime)
    {

        preparingDefense.SetActive(true);
        defenseDuringPreparing = true;
        keepFiring = false;
        CurrentOperation = UnitOperation.PreperingDefence;
        yield return new WaitForSeconds(waitTime);
        SetFinalDefense();

    }

    private void SetFinalDefense()
    {

        if (CurrentOperation == UnitOperation.PreperingDefence)
        {
            preparingDefense.SetActive(false);
            CurrentOperation = UnitOperation.IdleDefence;
            defenseReady.SetActive(true);
            isOnDefense = true;
            defenseDuringPreparing = false;
        }

    }

    private IEnumerator ProcessFiring(float waitTime, Vector3 attackCoordinates, UnitType unitType,
        LandscapeValues currentLandscape, int amount, float hitChance)
    {

        coroutineStarted = true;
        yield return new WaitForSeconds(waitTime);
        if (!defenseDuringPreparing)
        {
            EventHandler.OnProcedureAttack(gameObject.transform.position, attackCoordinates, UnitType, currentLandscape, amount, hitChance);
        }
        coroutineStarted = false;

    }

    private void SendCurrentPosition(bool wasMoved)
    {
        EventHandler.OnSetUnitOnField(transform.position.x, transform.position.z, gameObject);
    }

    private void SendFinalResults()
    {
        EventHandler.OnUltimateGoalUnitReport(transform.position.x, transform.position.z, Army);
    }


}

