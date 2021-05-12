using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fog : MonoBehaviour
{

    public GameObject fog;
    public Transform player;

    public Tilemap walls;

    public List<GameObject> availablePlaces;

    public Vector3 prevPlayer;

    // Start is called before the first frame update
    void Start()
    {
        availablePlaces = new List<GameObject>();

        prevPlayer = new Vector3(player.position.x, player.position.y);

        InstantiateFog();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x != prevPlayer.x || player.position.y != prevPlayer.y)
        {
            DestroyFog();
            InstantiateFog();

            prevPlayer.x = player.position.x;
            prevPlayer.y = player.position.y;
        }
    }

    public void InstantiateFog()
    {
        for (int i = walls.cellBounds.xMin; i < walls.cellBounds.xMax; i++)
        {
            for (int j = walls.cellBounds.yMin; j < walls.cellBounds.yMax; j++)
            {
                Vector3Int localPlace = new Vector3Int(i, j, (int)walls.transform.position.y);
                Vector3 place = walls.CellToWorld(localPlace);
                place.x += 0.5f;
                place.y += 0.5f;

                if (Mathf.Abs(place.x - player.position.x) >= 4 || Mathf.Abs(place.y - player.position.y) >= 4)
                {
                    GameObject a = Instantiate(fog, place, Quaternion.identity);
                    availablePlaces.Add(a);
                }
            }
        }
    }

    public void DestroyFog()
    {
        foreach (GameObject fog in availablePlaces)
        {
            Destroy(fog);
        }

        availablePlaces.Clear();
    }
}
