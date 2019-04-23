using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WhoSeesWho : MonoBehaviour
{
    public List<GameObject> redRange = new List<GameObject>();
    public List<GameObject> blueRange = new List<GameObject>();
    public List<GameObject> validBlueRange = new List<GameObject>();
    public List<GameObject> validRedRange = new List<GameObject>();
    public List<GameObject> collectiveUnitsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {



    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            collectiveUnitsList.AddRange(GameObject.FindGameObjectsWithTag("Cannon"));
            collectiveUnitsList.AddRange(GameObject.FindGameObjectsWithTag("Infantry"));

            /*collectiveUnitsList.RemoveAll(theGameObject => (theGameObject.transform.position.x == theGameObject.transform.position.z
            && theGameObject.transform.position.z == theGameObject.transform.position.z));*/

            SetWhoSeenWho(collectiveUnitsList);
            collectiveUnitsList.Clear();
        }
    }

    public void SetWhoSeenWho(List<GameObject> collectiveUnitsList)
    {
        blueRange.Clear();
        redRange.Clear();

        foreach (GameObject innerObject in collectiveUnitsList)
        {
            if (innerObject.transform.GetComponent<Unit>().Army == 'r')
            {
                blueRange.Add(innerObject);
            }
            else if (innerObject.transform.GetComponent<Unit>().Army == 'b')
            {
                redRange.Add(innerObject);
            }
        }

        foreach (GameObject redObject in blueRange)
        {
            foreach (GameObject blueObject in redRange)
            {
                if (CalculateDistance(redObject, blueObject) <= 5)
                {
                    if (!validRedRange.Contains(blueObject))
                    {
                        validRedRange.Add(blueObject);
                    }

                    if (!validBlueRange.Contains(redObject))
                    {
                        validBlueRange.Add(redObject);
                    }
                }
            }
        }

        foreach (GameObject innerObject in validBlueRange)
        {
            Debug.Log("Blue army sees: " + innerObject.name + " Its position: " + innerObject.transform.position);
        }

        foreach (GameObject innerObject in validRedRange)
        {
            Debug.Log("Red army sees: " + innerObject.name + " Its position: " + innerObject.transform.position);
        }

    }

    private int CalculateDistance(GameObject first, GameObject second)
    {
        float xDistance = Mathf.Abs(first.transform.position.x - second.transform.position.x);
        float yDistance = Mathf.Abs(first.transform.position.z - second.transform.position.z);
        int distance = (int)Mathf.Round(Mathf.Sqrt(Mathf.Pow(xDistance, 2) + Mathf.Pow(yDistance, 2)));
        return distance;
    }

}
