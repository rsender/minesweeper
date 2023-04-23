namespace Minesweeper {

    public partial class GameForm : Form {
        public GameForm() {
            InitializeComponent();
        }

        Cell[,] boardArr;
        int rows = 9;
        int cols = 9;
        bool gameOver { get; set; }
        int totalMines = 10;
        int minesLeft = 10;
        Smiley smiley;

        Image[] cellNum = {
            Image.FromFile(@"icons\tile_1.png"),
            Image.FromFile(@"icons\tile_2.png"),
            Image.FromFile(@"icons\tile_3.png"),
            Image.FromFile(@"icons\tile_4.png"),
            Image.FromFile(@"icons\tile_5.png"),
            Image.FromFile(@"icons\tile_6.png"),
            Image.FromFile(@"icons\tile_7.png"),
            Image.FromFile(@"icons\tile_8.png")
        };


        private void OnGameLoad(object sender, EventArgs e) {
            smiley = new Smiley((object sender, MouseEventArgs e) => { Reset(); SetUpBoard(); });
            header.Controls.Add(smiley);

            SetUpBoard();
        }

        private void OnMenuItemClick(object sender, EventArgs e) {
            Reset();
            ToolStripMenuItem selection = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item in (menuItem).DropDownItems) {
                item.Checked = false;
            }
            selection.Checked = true;

            if (selection.Text == "Easy") {
                rows = 9;
                cols = 9;
                totalMines = 10;
            }
            else if (selection.Text == "Intermediate") {
                rows = 16;
                cols = 16;
                totalMines = 40;
            }
            else if (selection.Text == "Hard") {
                rows = 16;
                cols = 30;
                totalMines = 99;
            }

            minesLeft = totalMines;
            SetUpBoard();
        }

        private void SetUpBoard() {

            gamePanel.Width = cols * 30;
            gamePanel.Height = rows * 30;

            header.Width = gamePanel.Width;
            smiley.Location = new Point((header.Width - smiley.Width) / 2, (header.Height - smiley.Height) / 2);

            //set game panel grid size
            gamePanel.RowCount = rows;
            gamePanel.ColumnCount = cols;

            //add rows and columns to gamePanel
            for (int i = 0; i < gamePanel.RowCount; i++) {
                gamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            }
            for (int i = 0; i < gamePanel.ColumnCount; i++) {
                gamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            //add cells to the gamePanel and add them to boardArr array
            boardArr = new Cell[rows, cols];

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    Cell cell = new Cell {
                        rowNum = i,
                        colNum = j,
                        BackgroundImage = Image.FromFile(@"icons\tile_raised.png")
                    };
                    cell.MouseDown += new MouseEventHandler(this.OnCellMouseDown);
                    cell.MouseClick += new MouseEventHandler(this.OnMouseClick);
                    cell.MouseUp += new MouseEventHandler(this.OnCellMouseUp);

                    gamePanel.Controls.Add(cell);
                    boardArr[i, j] = cell;
                }
            }
            this.Controls.Add(gamePanel);

            //randomly place bombs, then increase adjacent cells' value by 1 
            Random rand = new Random();
            int bombsPlaced = 0;

            while (bombsPlaced < totalMines) {
                int row = rand.Next(rows);
                int col = rand.Next(cols);
                if (!boardArr[row, col].isMine) {
                    boardArr[row, col].isMine = true;
                    bombsPlaced++;
                    for (int i = row - 1; i < row + 2; i++) {
                        for (int j = col - 1; j < col + 2; j++) {
                            if (i >= 0 && i < rows && j >= 0 && j < cols) {
                                boardArr[i, j].adjacentMines++;
                            }
                        }
                    }
                }
            }
        }

        public void OnCellMouseDown(object sender, MouseEventArgs e) {
            Cell cell = (Cell)sender;
            if (!gameOver) {
                if (e.Button == MouseButtons.Left) {
                    smiley.Surprise();
                }
                if (!cell.isFlagged && !cell.isOpen) {
                    cell.BackgroundImage = Image.FromFile(@"icons\tile_flat.png");
                }
            }
        }

        private void OnCellMouseUp(object sender, MouseEventArgs e) {
            Cell cell = (Cell)sender;
            if (!gameOver) {
                smiley.Raise();
                if (!cell.isFlagged && !cell.isOpen) {
                    cell.BackgroundImage = Image.FromFile(@"icons\tile_raised.png");
                }
            }
        }

        //reset the game
        private void Reset() {
            gameOver = false;
            gamePanel.Controls.Clear();
            Controls.Remove(gamePanel);
            smiley.Raise();
        }
        
        private void OnMouseClick(object sender, MouseEventArgs e) {
            Cell clickedCell = (Cell)sender;
            if (!gameOver && !clickedCell.isOpen) {
                if (e.Button == MouseButtons.Left) {
                    if (!clickedCell.isFlagged) {
                        if (!clickedCell.isMine) {
                            CellClicked(clickedCell);
                        }
                        else {
                            MineCellClicked(clickedCell);
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right) {
                    clickedCell.BackgroundImage = clickedCell.isFlagged ?
                        Image.FromFile(@"icons\tile_raised.png") :
                        Image.FromFile(@"icons\flag.png");
                    if (clickedCell.isMine) {
                        if (clickedCell.isFlagged) {
                            minesLeft++;
                        }
                        else {
                            minesLeft--;
                        }
                    }
                    clickedCell.isFlagged = !clickedCell.isFlagged;
                }

                //change smiley img to sunglasses
                bool won = true;
                foreach (var cell in boardArr) {
                    won = won && (cell.isMine || cell.isOpen);
                }
                if (minesLeft <= 0 && won) {
                    gameOver = true;
                    smiley.Sunglasses();
                }
            }
        }

        private void OpenCell(Cell cell) {
            cell.isOpen = true;

            if (cell.adjacentMines == 0) {
                cell.BackgroundImage = Image.FromFile(@"icons\tile_flat.png");
            }
            else if (cell.adjacentMines > 0 && !cell.isMine) {
                cell.BackgroundImage = cellNum[cell.adjacentMines - 1];
            }
        }

        private void CellClicked(Cell cell) {
            OpenCell(cell);

            if (cell.adjacentMines > 0 && !cell.isMine) {
                return;
            }
            else {
                for (int i = cell.rowNum - 1; i < cell.rowNum + 2; i++) {
                    for (int j = cell.colNum - 1; j < cell.colNum + 2; j++) {
                        if (i >= 0 && i < rows && j >= 0 && j < cols) {
                            if (!(boardArr[i, j].isOpen)) {
                                CellClicked(boardArr[i, j]);
                            }
                        }
                    }
                }
            }
        }

        private void MineCellClicked(Cell c) {
            foreach (var cell in boardArr) {
                if (cell.isMine) {
                    if (!cell.isFlagged) {
                        cell.isOpen = true;
                        cell.BackgroundImage = Image.FromFile(@"icons\mine.png");
                    }
                }
                else if (cell.isFlagged) {
                    cell.BackgroundImage = Image.FromFile(@"icons\wrongmine.png");
                }
            }

            c.BackgroundImage = Image.FromFile(@"icons\clickedmine.gif");
            gameOver = true;
            smiley.Dead();
        }
    }
}