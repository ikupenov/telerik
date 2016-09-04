namespace Batman.Contracts
{
    public interface IDrawer
    {
        void SameLineDraw(char symbol);

        void SameLineDraw(char symbol, int count);

        void NewLineDraw(char symbol);

        void NewLineDraw(char symbol, int count);

        void DrawEmptyLine();

        void DrawWhiteSpace();

        void DrawWhiteSpace(int count);
    }
}