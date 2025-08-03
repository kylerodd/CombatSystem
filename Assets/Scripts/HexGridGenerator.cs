using UnityEngine;

public class HexGridGenerator : MonoBehaviour
{
    public GameObject hexPrefab;
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float hexSize = 1f; // Distance from center to flat side

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Pointy-topped hex geometry
        float hexWidth = Mathf.Sqrt(3f) * hexSize;
        float hexHeight = 2f * hexSize;
        float xOffset = hexWidth;
        float yOffset = hexHeight * 0.75f;

        // Calculate total size of the grid
        float totalWidth = xOffset * (gridWidth - 1) + hexWidth;
        float totalHeight = yOffset * (gridHeight - 1) + hexHeight;

        Vector2 gridCenterOffset = new Vector2(totalWidth / 2f, totalHeight / 2f);
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                float xPos = x * xOffset;
                float yPos = y * yOffset;

                if (x % 2 == 1)
                    yPos += yOffset / 2f; // Apply vertical offset for odd columns

                Vector2 position = new Vector2(xPos, yPos) - gridCenterOffset;

                GameObject hex = Instantiate(hexPrefab, position, Quaternion.identity, transform);
                hex.name = $"Hex_{x}_{y}";
                hex.transform.localScale = Vector3.one * hexSize;
            }
        }
    }

}