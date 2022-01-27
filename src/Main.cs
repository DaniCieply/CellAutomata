using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace CellAutomata {
    static class CellAutomata {
        const int GRID_SIZE = 500;

        static void Main(string[] args) {
            RenderWindow window = new RenderWindow(new VideoMode(500, 500), "Cell Automata");
            window.SetFramerateLimit(3);
            Cell[,] cellArr = new Cell[GRID_SIZE, GRID_SIZE];

            // Current Rule Set
            TestGame game = new TestGame();

            initializeCells(cellArr);

            // Event handling
            window.Closed += new EventHandler(OnClose);

            while (window.IsOpen) {   
                window.DispatchEvents();

                game.changeCellStates(cellArr, GRID_SIZE);               

                window.Clear();
                drawCells(cellArr, window);
                window.Display();
            }   
        }

        static void OnClose(object sender, EventArgs e) {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void initializeCells(Cell[,] cellArr) {
            Random rand = new Random();

            // Fills cell array with objects
            for (int y = 0; y < GRID_SIZE; y++) {
                for (int x = 0; x < GRID_SIZE; x++) {
                    int randNum = rand.Next(0, 13);
                    bool isAlive = false;

                    if (randNum <= 4) {
                        isAlive = true;
                    } 

                    cellArr[y, x] = new Cell(new Vector2f(x, y), new Vector2f(10, 10), isAlive);
                }
            }

            // Sets the neighbors of each cell
            for (int y = 0; y < GRID_SIZE; y++) {
                for (int x = 0; x < GRID_SIZE; x++) {
                        if (x + 1 <= GRID_SIZE - 1) 
                            cellArr[y, x].neighbors.Add(cellArr[y, x+1]); //        ->
                        if (x - 1 >= 0) 
                            cellArr[y, x].neighbors.Add(cellArr[y, x-1]); //     <-
                        if (y - 1 >= 0) 
                            cellArr[y, x].neighbors.Add(cellArr[y-1, x]); //       ^
                        if (y + 1 <= GRID_SIZE - 1) 
                            cellArr[y, x].neighbors.Add(cellArr[y+1, x]); //       v
                        if (x - 1 >= 0 && y - 1 >= 0) 
                            cellArr[y, x].neighbors.Add(cellArr[y-1, x-1]); //   <-^
                        if (x + 1 <= GRID_SIZE - 1 && y - 1 >= 0) 
                            cellArr[y, x].neighbors.Add(cellArr[y-1, x+1]); //     ^->
                        if (x - 1 >= 0 && y + 1 <= GRID_SIZE - 1)
                            cellArr[y, x].neighbors.Add(cellArr[y+1, x-1]); //   <-v
                        if (x + 1 <= GRID_SIZE - 1 && y + 1 <= GRID_SIZE - 1)
                            cellArr[y, x].neighbors.Add(cellArr[y+1, x+1]); //     v->
                }
            }
        }

        static void drawCells(Cell[,] cellArr, RenderWindow window) {
            for (int y = 0; y < GRID_SIZE; y++) {
                for (int x = 0; x < GRID_SIZE; x++) {
                    window.Draw(cellArr[y, x].shape);
                }
            }
        }
    }
}