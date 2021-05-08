using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DiscoLights : MonoBehaviour
{

    public Tilemap groundTilemap;
    public GameObject discoLight;

    public float nextTimeToSwitch;
    public float moduloResult;
    public bool moduloSwitch;

    public List<GameObject> availablePlaces;

    public Conductor conductor;

    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        availablePlaces = new List<GameObject>();

        nextTimeToSwitch = 1f;

        moduloResult = 0.5f;

        InstantiateDiscoLights();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for(int i = groundTilemap.cellBounds.xMin; i < groundTilemap.cellBounds.xMax; i++)
        {
            for (int j = groundTilemap.cellBounds.yMin; j < groundTilemap.cellBounds.yMax; j++)
            {
                Vector3Int localPlace = new Vector3Int(i, j, (int) groundTilemap.transform.position.y);
                Vector3 place = groundTilemap.CellToWorld(localPlace);
                place.x += 0.5f;
                place.y += 0.5f;

                if (groundTilemap.HasTile(localPlace) && place.y % 2 == moduloResult){
                    GameObject light = Instantiate(discoLight, place, Quaternion.identity);

                    availablePlaces.Add(light);
                }
            }
        }
        */
        DestroyDiscoLights();
        InstantiateDiscoLights();

        if (conductor.songPositionInBeats >= nextTimeToSwitch)
        {
            moduloSwitch = !moduloSwitch;
            /*DestroyDiscoLights();
            InstantiateDiscoLights();*/

            nextTimeToSwitch = Mathf.Floor(conductor.songPositionInBeats) + 1;
        }
    }

    public void InstantiateDiscoLights()
    {
        float moduloResult2;
        if (moduloSwitch)
        {
            moduloResult = 0f;
            moduloResult2 = 1.5f;
        }
        else
        {
            moduloResult = 1f;
            moduloResult2 = 0.5f;
        }


        for (int i = groundTilemap.cellBounds.xMin; i < groundTilemap.cellBounds.xMax; i++)
        {
            for (int j = groundTilemap.cellBounds.yMin; j < groundTilemap.cellBounds.yMax; j++)
            {
                Vector3Int localPlace = new Vector3Int(i, j, (int)groundTilemap.transform.position.y);
                Vector3 place = groundTilemap.CellToWorld(localPlace);
                /*place.x += 0.5f;
                place.y += 0.5f;*/

                
                Collider2D collision = Physics2D.OverlapCircle(
                    new Vector3(place.x + 0.5f, place.y + 0.5f, 0), 0.1f, layerMask);
               
                

                if (groundTilemap.HasTile(localPlace) && 
                    (Mathf.Abs(place.x) + (Mathf.Abs(place.y) % 2)) %2 == moduloResult 
                    && collision == null)
                {
                    place.x += 0.5f;
                    place.y += 0.5f;
                    GameObject light = Instantiate(discoLight, place, Quaternion.identity);

                    //Debug.Log(moduloResult);

                    availablePlaces.Add(light);
                }
            }
        }
    }

    public void DestroyDiscoLights()
    {
        foreach(GameObject light in availablePlaces)
        {
            Destroy(light);
        }

        availablePlaces.Clear();
    }
}
