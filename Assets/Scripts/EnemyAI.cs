using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class EnemyAI : MonoBehaviour
{
    public Conductor conductor;

    public bool movedThisBeat;
    public float nextTimeToMove;

    public EnemyDirections enemyDirections;

    public Sprite []sprites;

    public int index;

    SpriteRenderer spriteRenderer;

    // Vision cones
    public GameObject coneSide;
    public GameObject coneUp;
    public GameObject coneDown;

    public GameObject[] sideVision;
    public GameObject[] upVision;
    public GameObject[] downVision;

    public Vector3 lookDir;
    public int lookDist;

    public Transform player;

    public Tilemap groundTilemap;
    public Tilemap collisionTilemap;

    // Start is called before the first frame update
    void Start()
    {
        nextTimeToMove = 0.5f;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lookDist);

        if(conductor.songPositionInBeats > nextTimeToMove )
        {
            nextTimeToMove = Mathf.Floor(conductor.songPositionInBeats) + 1;

            Move();
        }

        // check if player in sight
        for(int i = 1; i <= lookDist; i++)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position + (lookDir * i));

            if(distance == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    public void Move()
    {
        // Move
        if (enemyDirections.directions[index] == EnemyDirections.Direction.RIGHT)
        {
            transform.position += Vector3.right;

            lookDir = Vector3.right;
        }

        if (enemyDirections.directions[index] == EnemyDirections.Direction.LEFT)
        {
            transform.position += Vector3.left;

            lookDir = Vector3.left;
        }

        if (enemyDirections.directions[index] == EnemyDirections.Direction.UP)
        {
            transform.position += Vector3.up;

            lookDir = Vector3.up;
        }

        if (enemyDirections.directions[index] == EnemyDirections.Direction.DOWN)
        {
            transform.position += Vector3.down;

            lookDir = Vector3.down;
        }

        // Turn
        if (enemyDirections.directions[index] == EnemyDirections.Direction.TURN_RIGHT)
        {
            spriteRenderer.sprite = sprites[0];
            transform.rotation = Quaternion.Euler(0, 0, 0);

            coneSide.SetActive(true);
            coneDown.SetActive(false);
            coneUp.SetActive(false);

            lookDir = Vector3.right;
        }

        if (enemyDirections.directions[index] == EnemyDirections.Direction.TURN_LEFT)
        {
            spriteRenderer.sprite = sprites[0];
            transform.rotation = Quaternion.Euler(0, 180, 0);

            coneSide.SetActive(true);
            coneDown.SetActive(false);
            coneUp.SetActive(false);

            lookDir = Vector3.left;
        }

        if (enemyDirections.directions[index] == EnemyDirections.Direction.TURN_UP)
        {
            spriteRenderer.sprite = sprites[2];
            transform.rotation = Quaternion.Euler(0, 0, 0);

            coneSide.SetActive(false);
            coneDown.SetActive(false);
            coneUp.SetActive(true);

            lookDir = Vector3.up;
        }

        if (enemyDirections.directions[index] == EnemyDirections.Direction.TURN_DOWN)
        {
            spriteRenderer.sprite = sprites[1];
            transform.rotation = Quaternion.Euler(0, 0, 0);

            coneSide.SetActive(false);
            coneDown.SetActive(true);
            coneUp.SetActive(false);

            lookDir = Vector3.down;
        }

        Vision();

        index++;

        if(index >= enemyDirections.directions.Length)
        {
            index = 0;
        }
    }

    public void Vision()
    {
        Vector3Int gridPos;

        for(int i = 0; i < 3; i++)
        {
            sideVision[i].SetActive(false);
            upVision[i].SetActive(false);
            downVision[i].SetActive(false);
        }

        int j;

        for (j = 0; j < 3; j++)
        {
            gridPos = groundTilemap.WorldToCell(transform.position + (lookDir * (j + 1f)));

            if (!collisionTilemap.HasTile(gridPos))
            {
                if(enemyDirections.directions[index] == EnemyDirections.Direction.RIGHT ||
                    enemyDirections.directions[index] == EnemyDirections.Direction.TURN_RIGHT)
                {
                    Debug.Log("vision right");
                    sideVision[j].SetActive(true);
                }

                if (enemyDirections.directions[index] == EnemyDirections.Direction.LEFT ||
                    enemyDirections.directions[index] == EnemyDirections.Direction.TURN_LEFT)
                {
                    sideVision[j].SetActive(true);
                }

                if (enemyDirections.directions[index] == EnemyDirections.Direction.UP ||
                    enemyDirections.directions[index] == EnemyDirections.Direction.TURN_UP)
                {
                    upVision[j].SetActive(true);
                }

                if (enemyDirections.directions[index] == EnemyDirections.Direction.DOWN ||
                    enemyDirections.directions[index] == EnemyDirections.Direction.TURN_DOWN)
                {
                    downVision[j].SetActive(true);
                }
            }
            else
            {
                break;
            }
        }

        lookDist = j;
    }
}
