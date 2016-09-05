namespace Batman.Common.Drawers
{
    using System.IO;

    using Contracts;

    public class StreamDrawer : IDrawer
    {
        private StreamWriter streamWriter;

        public StreamDrawer(string filePath)
        {
            this.streamWriter = new StreamWriter(filePath, false);
        }

        public void CloseStream()
        {
            this.streamWriter.Close();
        }

        public void DrawEmptyLine()
        {
            this.streamWriter.WriteLine();
        }

        public void DrawWhiteSpace()
        {
            this.streamWriter.Write(" ");
        }

        public void DrawWhiteSpace(int count)
        {
            this.streamWriter.Write(new string(' ', count));
        }

        public void NewLineDraw(char symbol)
        {
            this.streamWriter.WriteLine(symbol);
        }

        public void NewLineDraw(char symbol, int count)
        {
            this.streamWriter.WriteLine(new string(symbol, count));
        }

        public void SameLineDraw(char symbol)
        {
            this.streamWriter.Write(symbol);
        }

        public void SameLineDraw(char symbol, int count)
        {
            this.streamWriter.Write(new string(symbol, count));
        }
    }
}