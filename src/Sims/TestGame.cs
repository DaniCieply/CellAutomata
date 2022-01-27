using SFML.Graphics;

namespace CellAutomata {
    class TestGame {
        /*
            RULES:
                If alive and less than two alive neighbors, die
                If alive and two or three alive neighbors, survive
                If alive and more than three alive neighbors, die
                If dead and exactly three alive neighbors, become alive
        */

        public void changeCellStates(Cell[,] cellArr, int GRID_SIZE) {
            /*
                Look at each cell on the grid, and record how many dead neighbors it has
                and how many dead ones it has
                then change the life state of current cell according to rules above
            */
            for (int y = 0; y < GRID_SIZE; y++) {
                for (int x = 0; x < GRID_SIZE; x++) {
                    Cell currentCell = cellArr[y, x];

                    int livingNeighbors = 0;
                    int deadNeighbors = 0;

                    foreach (Cell neighbor in currentCell.neighbors) {
                        if (neighbor.isAlive) {
                            livingNeighbors++;
                        } else {
                            deadNeighbors++;
                        }
                    }

                    if (currentCell.isAlive && livingNeighbors < 2) {
                        currentCell.nextAliveState = false;
                    } else if (currentCell.isAlive && livingNeighbors == 2 || livingNeighbors == 3) {
                        currentCell.nextAliveState = true; // Cell survives
                    } else if (currentCell.isAlive && livingNeighbors > 3) {
                        currentCell.nextAliveState = false;
                    } else if (!currentCell.isAlive && livingNeighbors == 3) {
                        currentCell.nextAliveState = true;
                    }
                }
            }

            // After deciding fate of each cell, life states are changed
            for (int y = 0; y < GRID_SIZE; y++) {
                for (int x = 0; x < GRID_SIZE; x++) {
                    Cell currentCell = cellArr[y, x];

                    currentCell.isAlive = currentCell.nextAliveState;

                    // Changes cell colors to reflect life state, TODO: make seperate function and possibly into seperate class. 
                    if (currentCell.isAlive) {
                        currentCell.shape.FillColor = Color.White;
                    } else {
                        currentCell.shape.FillColor = Color.Black;
                    }
                }
            }
        }
    }
}