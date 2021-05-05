using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerMovementToBeat : MonoBehaviour
{
    public float inputTime;
    public Vector3 moveDir;

    public bool movedThisBeat;
    public float nextTimeToMove;

    SpriteRenderer renderer;
    public Sprite glowSprite;
    public Sprite normalSprite;

    public Conductor conductor;

    public Tilemap groundTilemap;
    public Tilemap collisionTilemap;

    public int score;
    public int numberOfCollectibles;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        /* ___ */
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(songPositionInBeats);
        //Debug.Log(nextTimeToMove);

        /*
        if(songPositionInBeats >= nextTimeToMove)
        {
            
            transform.position += new Vector3(1, 0, 0);
            if(transform.position.x % 0.5 != 0)
            {
                transform.position = new Vector3((float)Math.Truncate(transform.position.x) + 0.5f, transform.position.y, transform.position.z);
            }
            nextTimeToMove = Mathf.Floor(songPositionInBeats) + 1;
            Debug.Log(nextTimeToMove);
        }
        */

        if (Input.GetKeyDown(KeyCode.W))
        {
            inputTime = conductor.songPositionInBeats;
            moveDir = Vector2.up;
            //Debug.Log("current " + songPositionInBeats);
            //Debug.Log("next " + Mathf.Round(nextTimeToMove));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputTime = conductor.songPositionInBeats;
            moveDir = Vector2.left;
            //Debug.Log("current " + songPositionInBeats);
            //Debug.Log("next " + Mathf.Round(nextTimeToMove));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inputTime = conductor.songPositionInBeats;
            moveDir = Vector2.down;
            //Debug.Log("current " + songPositionInBeats);
            //Debug.Log("next " + Mathf.Round(nextTimeToMove));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            inputTime = conductor.songPositionInBeats;
            moveDir = Vector2.right;
            //Debug.Log("current " + songPositionInBeats);
            //Debug.Log("next " + Mathf.Round(nextTimeToMove));
        }

        //
        Vector3Int gridPos = groundTilemap.WorldToCell(transform.position + moveDir);

        if(nextTimeToMove >= inputTime - 0.2f && nextTimeToMove <= inputTime + 0.2f  && !movedThisBeat && groundTilemap.HasTile(gridPos))
        {
            transform.position += moveDir;
            nextTimeToMove = Mathf.Round(conductor.songPositionInBeats) + 1;
            
            movedThisBeat = true;
        }

        if(conductor.songPositionInBeats >= nextTimeToMove - 0.2f)
        {
            movedThisBeat = false;
        }
        //Debug.Log("beat " + Mathf.Round(nextTimeToMove));

    }

    private void FixedUpdate()
    {
        if (conductor.songPositionInBeats > nextTimeToMove + 0.2f)
        {
            nextTimeToMove = Mathf.Floor(conductor.songPositionInBeats) + 1;

            movedThisBeat = false;
            //Debug.Log("beat " + Mathf.Round(songPositionInBeats));
        }

        if(conductor.songPositionInBeats >= nextTimeToMove -0.2f && conductor.songPositionInBeats <= nextTimeToMove + 0.2f)
        {
            //renderer.color = new Color(0, 1, 0);
            // change to glow
            renderer.sprite = glowSprite;
        }
        else
        {
            //renderer.color = new Color(0, 0, 0);
            renderer.sprite = normalSprite;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Collectible"))
        {
            Debug.Log("Hit Collectible");

            Destroy(collision.gameObject);

            score++;

            Debug.Log(score);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Goal") && score == numberOfCollectibles)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
