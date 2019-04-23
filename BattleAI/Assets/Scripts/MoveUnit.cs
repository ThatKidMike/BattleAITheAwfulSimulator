using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnit : MonoBehaviour
{

    private Unit UnitScript { get; set; }
    RaycastHit landscapeHit;
    LandscapeValues LandscapeCheck { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        UnitScript = gameObject.GetComponent<Unit>();
        EventHandler.InvokeMoveUnit += PushTheUnit;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PushTheUnit(float x, float z, float cannonDelay, float infantryDelay, bool validToMove)
    {

        if (validToMove)
        {

            if (transform.Find("Sphere").gameObject.activeInHierarchy)
            {
                if (gameObject.name.Contains("Red"))
                {

                    if (x == transform.position.x - 1 && z == transform.position.z)
                    {
                        if (transform.gameObject.tag == "Cannon")
                        {
                            StartCoroutine(MovementDelay(cannonDelay, x, z));
                        }
                        else
                        {
                            StartCoroutine(MovementDelay(infantryDelay, x, z));
                        }
                        //call the corountine

                    }
                    else if (x == transform.position.x + 1 && z == transform.position.z)
                    {
                        if (transform.gameObject.tag == "Cannon")
                        {
                            StartCoroutine(MovementDelay(cannonDelay, x, z));
                        }
                        else
                        {
                            StartCoroutine(MovementDelay(infantryDelay, x, z));
                        }
                        //call the corountine

                    }
                    else if (x == transform.position.x && z == transform.position.z + 1)
                    {
                        if (transform.gameObject.tag == "Cannon")
                        {
                            StartCoroutine(MovementDelay(cannonDelay, x, z));
                        }
                        else
                        {
                            StartCoroutine(MovementDelay(infantryDelay, x, z));
                        }
                        //call the corountine

                    }
                    else if (x == transform.position.x && z == transform.position.z - 1)
                    {
                        if (transform.gameObject.tag == "Cannon")
                        {
                            StartCoroutine(MovementDelay(cannonDelay, x, z));
                        }
                        else
                        {
                            StartCoroutine(MovementDelay(infantryDelay, x, z));
                        }
                        //call the corountine
                    }

                }
                else
                {

                    if (x == transform.position.x - 1 && z == transform.position.z)
                    {
                        if (transform.gameObject.tag == "Cannon")
                        {
                            StartCoroutine(MovementDelay(cannonDelay, x, z));
                        }
                        else
                        {
                            StartCoroutine(MovementDelay(infantryDelay, x, z));
                        }
                        //call the corountine

                    }
                    else if (x == transform.position.x + 1 && z == transform.position.z)
                    {
                        if (transform.gameObject.tag == "Cannon")
                        {
                            StartCoroutine(MovementDelay(cannonDelay, x, z));
                        }
                        else
                        {
                            StartCoroutine(MovementDelay(infantryDelay, x, z));
                        }
                        //call the corountine

                    }
                    else if (x == transform.position.x && z == transform.position.z - 1)
                    {
                        if (transform.gameObject.tag == "Cannon")
                        {
                            StartCoroutine(MovementDelay(cannonDelay, x, z));
                        }
                        else
                        {
                            StartCoroutine(MovementDelay(infantryDelay, x, z));
                        }
                        //call the corountine

                    }
                    else if (x == transform.position.x && z == transform.position.z + 1)
                    {
                        if (transform.gameObject.tag == "Cannon")
                        {
                            StartCoroutine(MovementDelay(cannonDelay, x, z));
                        }
                        else
                        {
                            StartCoroutine(MovementDelay(infantryDelay, x, z));
                        }
                        //call the corountine
                    }

                }

            }

        }

    }

    private IEnumerator MovementDelay(float waitTime, float x, float z)
    {

        if (UnitScript.CurrentOperation == UnitOperation.PreperingDefence || UnitScript.CurrentOperation == UnitOperation.IdleDefence)
        {
            waitTime += 3f;
        }

        if (UnitScript.DuringFiring)
        {
            UnitScript.CurrentOperation = UnitOperation.MovingAndFiring;
        }
        else
        {
            UnitScript.CurrentOperation = UnitOperation.Moving;
        }
        Debug.Log(UnitScript.CurrentOperation);
        yield return new WaitForSeconds(waitTime);
        MoveUnitAfterWait(x, z);

    }

    private void MoveUnitAfterWait(float x, float z)
    {

        if (Physics.Raycast(new Vector3(x, -1f, z), Vector3.up, out landscapeHit, 120))
        {
            LandscapeCheck = landscapeHit.transform.GetComponent<LandscapeValues>();

            if (!LandscapeCheck.Taken)
            {
                EventHandler.OnClearUnitOnField(transform.position.x, transform.position.z, gameObject);
                transform.position = new Vector3(x, transform.position.y, z);
                UnitScript.preparingDefense.SetActive(false);
                UnitScript.defenseReady.SetActive(false);
                UnitScript.isOnDefense = false;

                if (UnitScript.DuringFiring)
                {
                    UnitScript.CurrentOperation = UnitOperation.Firing;
                }
                else
                {
                    UnitScript.CurrentOperation = UnitOperation.Waiting;
                }
                EventHandler.OnWasUnitMoved(true);
            }

        }

    }


}
