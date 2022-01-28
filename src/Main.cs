using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace CellAutomata {
    static class CellAutomata {
        static void Main(string[] args) {
            Conway conwayGame = new Conway();
            int gridSize = 500;
            int cellSize = 1;
            uint framerate = 60;
            
            configureGame(ref gridSize, ref cellSize, ref framerate);
            RenderWindow window = new RenderWindow(new VideoMode(500, 500), "Cell Automata");
            window.SetFramerateLimit(framerate);

            Cell[,] cellArr = new Cell[gridSize, gridSize];
            CellManager.initializeCells(cellArr, gridSize, cellSize);

            // Event handling
            window.Closed += new EventHandler(OnClose);

            while (window.IsOpen) {   
                window.DispatchEvents();

                conwayGame.changeCellStates(cellArr, gridSize);               

                window.Clear();
                CellManager.drawCells(cellArr, window, gridSize);
                window.Display();
            }   
        }

        static void configureGame(ref int gridSize, ref int cellSize, ref uint framerate) {
            Console.WriteLine("Grid size: ");
            gridSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Cell size (1, multiples of 5): ");
            cellSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Framerate: ");
            framerate = Convert.ToUInt32(Console.ReadLine());
        }

        static void OnClose(object sender, EventArgs e) {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
    }
}