using SFML.System;
using SFML.Graphics;

namespace CellAutomata {
    public static class CellManager {
        public static void initializeCells(Cell[,] cellArr, int gridSize, int cellSize) {
            initCellArr(cellArr, gridSize, cellSize);
            setNeighbors(cellArr, gridSize);   
        }

        private static void initCellArr(Cell[,] cellArr, int gridSize, int cellSize) {
            Random rand = new Random();

            for (int y = 0; y < gridSize; y++) {
                for (int x = 0; x < gridSize; x++) {
                    int randNum = rand.Next(0, 13);
                    bool isAlive = false;

                    if (randNum <= 6) {
                        isAlive = true;
                    } 

                    cellArr[y, x] = new Cell(new Vector2f(x * cellSize, y * cellSize), new Vector2f(cellSize, cellSize), isAlive);
                }
            }
        }

        private static void setNeighbors(Cell[,] cellArr, int gridSize) {
            // Sets the neighbors of each cell
            for (int y = 0; y < gridSize; y++) {
                for (int x = 0; x < gridSize; x++) {
                        if (x + 1 <= gridSize - 1) 
                            cellArr[y, x].neighbors.Add(cellArr[y, x+1]); //        ->
                        if (x - 1 >= 0) 
                            cellArr[y, x].neighbors.Add(cellArr[y, x-1]); //     <-
                        if (y - 1 >= 0) 
                            cellArr[y, x].neighbors.Add(cellArr[y-1, x]); //       ^
                        if (y + 1 <= gridSize - 1) 
                            cellArr[y, x].neighbors.Add(cellArr[y+1, x]); //       v
                        if (x - 1 >= 0 && y - 1 >= 0) 
                            cellArr[y, x].neighbors.Add(cellArr[y-1, x-1]); //   <-^
                        if (x + 1 <= gridSize - 1 && y - 1 >= 0) 
                            cellArr[y, x].neighbors.Add(cellArr[y-1, x+1]); //     ^->
                        if (x - 1 >= 0 && y + 1 <= gridSize - 1)
                            cellArr[y, x].neighbors.Add(cellArr[y+1, x-1]); //   <-v
                        if (x + 1 <= gridSize - 1 && y + 1 <= gridSize - 1)
                            cellArr[y, x].neighbors.Add(cellArr[y+1, x+1]); //     v->
                }
            }
        }

        public static void drawCells(Cell[,] cellArr, RenderWindow window, int gridSize) {
            for (int y = 0; y < gridSize; y++) {
                for (int x = 0; x < gridSize; x++) {
                    cellArr[y, x].draw(window);
                }
            }
        }
    }
}