using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


public class Grid : MonoBehaviour
{
    public GameObject block;
    public float spacing;
    public List<GameObject> blocks =  new List<GameObject>();

    public GameObject winScreen;

    private void Start()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        // this loop destroys all the old blocks before creating a new grid so that it doesnt overlap
        foreach (GameObject b in blocks)
        {
            if (b != null)
                Destroy(b);
        }
        blocks.Clear();

        int columns = 8;
        int rows = 3;

        // Creates a grid of 3x8 brick wall using the brick prefab and addings spacing to it 
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector2 offset = new Vector2(i * spacing, j * spacing);
                Vector2 spawnPos = (Vector2)transform.position + offset;

                GameObject obj = Instantiate(block, spawnPos, Quaternion.identity, transform);
                blocks.Add(obj);
            }
        }
    }

    // this function is used to show the Win Screen once user destroys all blocks and it pauses the game by setting time scale to 0
    public void ShowWinScreen()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f; 
        }
    }
}
