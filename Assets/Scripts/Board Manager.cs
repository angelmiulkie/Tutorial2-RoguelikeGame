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

    // Player Controller Variables
    private Grid m_Grid;
    public PlayerController Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();
        m_Grid = GetComponentInChildren<Grid>();

        m_boardData = new CellData[width, height];

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

        Player.Spawn(this, new Vector2Int(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 CellToWorld(Vector2Int cellIndex) {
        return m_Grid.GetCellCenterWorld((Vector3Int)cellIndex);
    }
    
    public CellData GetCellData(Vector2Int cellIndex) {
        if (cellIndex.x < 0 || cellIndex.x >= width || cellIndex.y < 0 || cellIndex.y >= height) {
            return null;
        }

        return m_boardData[cellIndex.x, cellIndex.y];
    }
}
