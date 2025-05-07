using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class CellGrid : MonoBehaviour
{
    /*
   Берёт префаб ячейки
   генерирует количество ячеек
   расставляет в порядке*/
    [Header("Settings")]
    public GameObject cellPrefab;
    public int cellCount = 0;
    public Vector2 spacing = new Vector2(10, 10);
    public Vector2 cellSize = new Vector2(100, 100);
    [Range(0,10)] public int maxColumns = 3;
    [Header("Centering")]
    public bool centerGrid = true;
    public bool fitToContainer = false;

    private GridLayoutGroup gridLayout;
    private RectTransform rectTransform;
    private void Awake()
    {
        //кэшируем
        gridLayout = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cellPrefab != null) GenerateGrid();
    }
    public void GenerateGridTask(int _cellCount)
    {
        if (_cellCount > 0 && _cellCount < 110)
        {
            cellCount = _cellCount;
            GenerateGrid();
        }
    }
    public void GetGridData()
    {
        
    }

    private void GenerateGrid()
    {
        // Очищаем старые ячейки
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        //рассчёт строк и столбцов 
        int columns = Mathf.Min(maxColumns, cellCount);
        int rows = Mathf.CeilToInt((float)cellCount / columns);
        //настройка GridLoyout 
        gridLayout.cellSize = cellSize;
        gridLayout.spacing = spacing;
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = columns;
        //создаём ячейки
        for (int i = 0; i < cellCount; i++)
        {
            Instantiate(cellPrefab, transform);
        }
        // Опциональное центрирование
        if (centerGrid) CenterGrid(columns, rows);

        // Опциональное растяжение по контейнеру
        if (fitToContainer) FitGridToContainer(columns, rows);
    }
    private void CenterGrid(int columns, int rows)
    {
        //рассчитываем общий размер сетки
        float totalWidth = columns * cellSize.x + (columns - 1) * spacing.x;
        float totalHeight = rows * cellSize.y + (rows - 1) * spacing.y;
        //устанавливаем смещение для центрирования
        gridLayout.padding.left = Mathf.FloorToInt((rectTransform.rect.width - totalWidth) / 2);
        gridLayout.padding.top = Mathf.FloorToInt((rectTransform.rect.height - totalHeight) / 2);
        gridLayout.padding.right = gridLayout.padding.left;
        gridLayout.padding.bottom = gridLayout.padding.top;
    }
    private void FitGridToContainer(int columns, int rows)
    {
        //рассчитываем доступное пространство
        float availableWidth = rectTransform.rect.width - (spacing.x * (columns - 1));
        float availableHeight = rectTransform.rect.height - (spacing.y * (rows - 1));
        //новыйй размер ячеек
        Vector2 newCellSize = new Vector2(
            availableWidth / columns,
            availableHeight / rows
            );
        gridLayout.cellSize = newCellSize;
    }
    //центрирование для неполных строк
    private void CenterPartialRow(int columns, int itemsInLastRow)
    {
        if (itemsInLastRow == columns) return;

        float emptySpace = (columns - itemsInLastRow) * (cellSize.x + spacing.x);
        gridLayout.padding.left += Mathf.FloorToInt(emptySpace / 2);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
