using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    // Board Data
    public class CellData {
        public bool passable;
    }

    private CellData[,] m_boardData;

    // Variables
    private Tilemap m_Tilemap;

    public int width;
    public int height;
    public Tile[] groundTiles;
    public Tile[] wallTiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();

        for (int y = 0; y < height; ++y) {
            for (int x = 0; x < width; ++x) {
                Tile tile;
                m_boardData[x, y] = new CellData();
                
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1) {
                    tile = wallTiles[Random.Range(0, wallTiles.Length)];
                    m_boardData[x, y].passable = false;
                } else {
                    tile = groundTiles[Random.Range(0, groundTiles.Length)];
                    m_boardData[x, y].passable = true;
                }
               
                m_Tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
