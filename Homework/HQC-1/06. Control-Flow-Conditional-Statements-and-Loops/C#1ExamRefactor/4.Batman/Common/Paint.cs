namespace Batman.Common
{
    using Contracts;

    public class Paint
    {
        private IDrawer drawer;

        public Paint(IDrawer drawer)
        {
            this.drawer = drawer;
        }

        public void DrawBatman(int drawingSize, char drawingChar)
        {
            // Top part
            for (int i = 0; i < drawingSize / 2; i++)
            {
                this.drawer.DrawWhiteSpace(i);

                this.drawer.SameLineDraw(drawingChar, drawingSize - i);

                if (i == (drawingSize / 2) - 1)
                {
                    this.drawer.DrawWhiteSpace((drawingSize / 2) - 1);
                    this.drawer.SameLineDraw(drawingChar);
                    this.drawer.DrawWhiteSpace();
                    this.drawer.SameLineDraw(drawingChar);
                    this.drawer.DrawWhiteSpace((drawingSize / 2) - 1);
                }
                else
                {
                    this.drawer.DrawWhiteSpace(drawingSize);
                }

                this.drawer.SameLineDraw(drawingChar, drawingSize - i);

                this.drawer.DrawEmptyLine();
            }

            // Middle part
            for (int i = 1; i <= drawingSize / 3; i++)
            {
                this.drawer.DrawWhiteSpace(drawingSize / 2);
                this.drawer.SameLineDraw(drawingChar, (2 * drawingSize) + 1);

                this.drawer.DrawEmptyLine();
            }

            // Bottom part
            for (int i = 0, j = 2; i < drawingSize / 2; i++, j += 2)
            {
                this.drawer.DrawWhiteSpace(drawingSize + 1 + i);
                this.drawer.SameLineDraw(drawingChar, drawingSize - j);

                this.drawer.DrawEmptyLine();
            }
        }
    }
}