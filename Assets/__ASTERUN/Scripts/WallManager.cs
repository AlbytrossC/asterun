using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

public class WallManager : MonoBehaviour
{
    [Header("Zone A")]
    public List<GameObject> wallPartsA = new List<GameObject>(); //old tile system
    public List<GameObject> wallTiles = new List<GameObject>(); //new tile system
    public GameObject playerTEMP; // TEMPORARY PLEASE MAKE IT TEMPORARY, GET FROM SOMEWHERE ELSE
    public List<GameObject> nearbyWalls = new List<GameObject>(); //walls close to player


    private float firstWallY;
    private float lastWallY;
    private const float lX = -1;
    private const float rX = 1.5f;

    public bool onTheWall = true;

    private string tagR = "WALL Right";
    private string tagL = "WALL Left";
    /*private string layerName = "WALL HITBOX";
    private int layerNum = 11;*/
    private Vector2 wallSize = new Vector2(0, 19.2f);

    private GameObject nearestWallToPlayer;
    private float lowestWallY; // lowest wall Y value;
    private float highestWallY; // highest wall Y value;
    private float nextWallY = 4.5f; // where to put the next wall
    private float nextWallY2; // where to put the next wall
    public Color spawnColour;
    public Color wallColour;

    private Color funCol;
    private float funHue = 0.95f;


    public GameObject GetNearestWallToPlayer() => nearestWallToPlayer == null ? null : nearestWallToPlayer;


    public void UpdateColour()
    {
        //SetWallColour();
        funHue += 0.05f;
        if (funHue > 1)
            funHue = 1 - funHue;
    }
    private void RandomWallColour()
    {
        wallColour = funCol;
    }

    private void Start()
    {
        //SpawnWall(nextWallY); //spawn starting walls
        SpawnTile(nextWallY2); //spawn starting walls
        wallSize.y = 19.2f;
        funHue = 0.95f;
        Fun();
    }

    void Fun()
    {
        Color col = Color.HSVToRGB(funHue, 0.8f, 0.8f);
        wallColour = col;
    }

    private void Update()
    {
        Fun(); //delete later
        FindNearestWallToPlayer();
        if (nearbyWalls.Count > 0)
            playerTEMP.GetComponentInParent<PlayerScript>().onWall = true;
        else playerTEMP.GetComponentInParent<PlayerScript>().onWall = false;

        if (playerTEMP.transform.position.y > highestWallY)
            SpawnTile(nextWallY);
            //SpawnWall(nextWallY);
    }

    private void FindNearestWallToPlayer()
    {

        foreach (GameObject wall in nearbyWalls)
        {
            if (nearestWallToPlayer == null)
            {
                nearestWallToPlayer = wall;
                return;
            }

            if (playerTEMP.GetComponent<Collider2D>().Distance(wall.GetComponent<Collider2D>()).distance < playerTEMP.GetComponent<Collider2D>().Distance(nearestWallToPlayer.GetComponent<Collider2D>()).distance)
            {
                nearestWallToPlayer = wall;
            }
        }
    }

    private void SpawnWall(float height)
    {
        foreach(GameObject wall in wallPartsA)
        {
            if (wall.tag == tagL)
            {
                GameObject newWall = Instantiate(wall, new Vector3(lX, height, 0), wall.transform.rotation);
                //newWall.GetComponent<SpriteRenderer>().color = playerTEMP.GetComponentInChildren<SpriteRenderer>().color;
                newWall.GetComponent<SpriteRenderer>().color = wallColour;
                newWall.name = "wall [L]";
            }
            else if (wall.tag == tagR)
            {
                GameObject newWall = Instantiate(wall, new Vector3(rX, height, 0), wall.transform.rotation);
                newWall.GetComponent<SpriteRenderer>().color = wallColour;
                newWall.name = "wall [R]";
            }

        }

        nextWallY = height + wallSize.y;
        highestWallY = height;
    }

    private void SpawnTile(float height)
    {
        foreach (GameObject tile in wallTiles)
        {
            GameObject newTile = Instantiate(tile, new Vector3(0, height, 0), tile.transform.rotation);
            newTile.transform.GetChild(0).GetComponent<SpriteRenderer>().color = wallColour;
            newTile.transform.GetChild(0).name = "Wall [L]";
            newTile.transform.GetChild(1).GetComponent<SpriteRenderer>().color = wallColour;
            newTile.transform.GetChild(1).name = "Wall [R]";


            /*if (wall.transform.GetChild(0).tag == tagL)
            {
                GameObject newWall = Instantiate(wall, new Vector3(lX, height, 0), wall.transform.rotation);
                //newWall.GetComponent<SpriteRenderer>().color = playerTEMP.GetComponentInChildren<SpriteRenderer>().color;
                newWall.GetComponent<SpriteRenderer>().color = wallColour;
                newWall.name = "wall [L]";
            }
            else if (wall.tag == tagR)
            {
                GameObject newWall = Instantiate(wall, new Vector3(rX, height, 0), wall.transform.rotation);
                newWall.GetComponent<SpriteRenderer>().color = wallColour;
                newWall.name = "wall [R]";
            }*/

        }

        nextWallY = height + wallSize.y;
        highestWallY = height;
    }
}
