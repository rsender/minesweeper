namespace Minesweeper {
    internal class Cell : Label {

        public int rowNum { get; set; }
        public int colNum { get; set; }
        public int adjacentMines { get; set; }
        public bool isMine { get; set; }
        public bool isOpen { get; set; }
        public bool isFlagged { get; set; }

        public Cell() {
            Height = 30;
            Width = 30;
            Margin = new Padding(1);
            BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
