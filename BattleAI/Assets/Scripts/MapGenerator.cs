using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject grass;
    public GameObject denseGrass;
    public GameObject stone;
    public GameObject forrest;
    public GameObject water;
    public GameObject solidWay;

    private int width = 25;
    private int length = 25;
    private readonly float readonlyY = 0;

    List<GameObject> landscapeList = new List<GameObject>();
    System.Random rndNumLandscape = new System.Random();

    private GameObject generatedLandscape;
    private LandscapeValues generatedLandscapeScript;
    public MapInfoJSON generatedMapJSON = new MapInfoJSON();

    void Start()
    {
        landscapeList.Add(water);
        landscapeList.Add(grass);
        landscapeList.Add(denseGrass);
        landscapeList.Add(stone);
        landscapeList.Add(forrest);
        landscapeList.Add(solidWay);

        generateMap();
    }

    private int generateRandomLandscapeNum(bool withoutWater)
    {

        int rndNumber = 10;

        if (withoutWater)
        {
            rndNumber = rndNumLandscape.Next(1, 6);
        }
        else
        {
            rndNumber = rndNumLandscape.Next(0, 6);
        }
        return rndNumber;
    }

    private void generateMap()
    {

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                if ((z == 0) || (z == length - 1))
                {
                    generatedLandscape = landscapeList[generateRandomLandscapeNum(true)];
                    generatedLandscape = Instantiate(generatedLandscape, new Vector3(x, readonlyY, z), Quaternion.identity);
                    generatedLandscapeScript = generatedLandscape.GetComponent<LandscapeValues>();
                    if (generatedLandscapeScript != null)
                        generatedMapJSON.map[x, z] = generatedLandscapeScript.FieldType.ToString();
                }
                else
                {
                    generatedLandscape = landscapeList[generateRandomLandscapeNum(false)];
                    generatedLandscape = Instantiate(generatedLandscape, new Vector3(x, readonlyY, z), Quaternion.identity);
                    generatedLandscapeScript = generatedLandscape.GetComponent<LandscapeValues>();
                    if (generatedLandscapeScript != null)
                        generatedMapJSON.map[x, z] = generatedLandscapeScript.FieldType.ToString();
                }
            }
        }



    }

}
