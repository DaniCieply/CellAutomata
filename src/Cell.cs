using SFML.System;
using SFML.Graphics;

namespace CellAutomata {
    public class Cell {
        public RectangleShape shape;
        public List<Cell> neighbors;
        public Vector2f pos;
        public Vector2f size;
        public bool isAlive;
        public bool nextAliveState; 

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

        public void draw(RenderWindow window) {
            if (isAlive) {window.Draw(shape);}
        }
    }
}