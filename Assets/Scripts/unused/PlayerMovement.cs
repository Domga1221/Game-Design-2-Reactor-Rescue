using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveRate = 1;

    public Tilemap groundTilemap;
    public Tilemap collisionTilemap;

    // Text
    public Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            // transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveRate;

            Vector3Int gridPos = groundTilemap.WorldToCell(transform.position + new Vector3(0, 1, 0));
            if (groundTilemap.HasTile(gridPos) || !collisionTilemap.HasTile(gridPos))
            {
                transform.position += new Vector3(0, 1, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            // transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * moveRate;

            Vector3Int gridPos = groundTilemap.WorldToCell(transform.position + new Vector3(-1, 0, 0));
            if (groundTilemap.HasTile(gridPos) || !collisionTilemap.HasTile(gridPos))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // transform.position += new Vector3(0, -1, 0) * Time.deltaTime * moveRate;

            Vector3Int gridPos = groundTilemap.WorldToCell(transform.position + new Vector3(0, -1, 0));
            if (groundTilemap.HasTile(gridPos) || !collisionTilemap.HasTile(gridPos))
            {
                transform.position += new Vector3(0, -1, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            // transform.position += new Vector3(1, 0, 0) * Time.deltaTime * moveRate;

            Vector3Int gridPos = groundTilemap.WorldToCell(transform.position + new Vector3(1, 0, 0));
            if (groundTilemap.HasTile(gridPos) || !collisionTilemap.HasTile(gridPos))
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }

        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Collectible"))
        {
            Debug.Log("Hit coin");
            Destroy(collision.gameObject);

            score++;
            scoreText.text = score + "/4";
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Goal") && score == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
