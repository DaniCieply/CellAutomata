using SFML.System;
using SFML.Graphics;

namespace CellAutomata {
    public class Cell {
        public RectangleShape shape;
        public List<Cell> neighbors;
        Vector2f pos;
        Vector2f size;
        public bool isAlive;

        public Cell(Vector2f position, Vector2f size, bool isAlive) {
            this.pos = position;
            this.size = size;
            this.isAlive = isAlive;

            neighbors = new List<Cell>();

            shape = new RectangleShape(size);
            shape.Position = position;

            if (this.isAlive) {
                shape.FillColor = Color.White;
            } else {
                shape.FillColor = Color.Black;
            }
        }
    }
}