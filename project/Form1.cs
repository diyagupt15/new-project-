using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace project
{
    /* 
	 * Naming changes:
	 *  - HighlightAllPossibleMoves --> HighlightAllPossibleOctaMoves
	 *  - HighlightPossibleMoves --> HighlightPossibleOctaMoves
	 *  - HighlightPossibleMovesSUB1 --> HighlightPossibleMoves
	 *  - FlipRays --> FlipOctaRay
	 *  - FlipRaysSUB1 --> FlipRay
	 *  - int variable end @CheckIfGameEnded --> winnerteam
	*/

    public partial class Form1 : Form
    {
        private TextBox textBoxPlayer1;
        private TextBox textBoxPlayer2;
        private string player1Name = "Player 1";
        private string player2Name = "Player 2";


        public Form1()
        {
            Methods.RESET();
            InitializeComponent();
            panel1.Visible = true;
            informationPanel.Checked = panel1.Visible;
            // Set the initial text of the text boxes to player names.
            textBox1.Text = player1Name;
            textBox2.Text = player2Name;

            // Attach event handlers to the TextChanged events of the text boxes.
            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Update player1Name when the text in textBoxPlayer1 changes.
            player1Name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Update player2Name when the text in textBoxPlayer2 changes.
            player2Name = textBox2.Text;
        }
        private void UpdateTileCounts()
        {
            int blackCount = 0;
            int whiteCount = 0;

            for (int x = 0; x < DATA.gridSize; x++)
            {
                for (int y = 0; y < DATA.gridSize; y++)
                {
                    if (DATA.tileTeamValues[x, y] == (int)DATA.TeamValue.Black)
                    {
                        blackCount++;
                    }
                    else if (DATA.tileTeamValues[x, y] == (int)DATA.TeamValue.White)
                    {
                        whiteCount++;
                    }
                }
            }

            label1.Text = "Black Count: " + blackCount;
            label2.Text = "White Count: " + whiteCount;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialization tasks can be added here
            Methods.RESET();
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            int wind_x = this.ClientSize.Width;
            DATA.wind_x = wind_x;
            int wind_y = this.ClientSize.Height;
            DATA.wind_y = wind_y;

            int gridsize = DATA.gridSize;
            int edge = DATA.edge;
            int tileSize = ((wind_x < wind_y ? wind_x : wind_y) - 2 * edge) / gridsize;
            DATA.tileSize = tileSize;
            if (tileSize < 0) return;


            bool colorSwitch = false, colorSwitch2 = gridsize % 2 == 0;
            int x, y;
            int sizeIn = -4, sizeOut = -3;
            for (int iX = 0; iX < gridsize; iX++)
            {
                if (colorSwitch2) colorSwitch = !colorSwitch;
                for (int iY = 0; iY < gridsize; iY++)
                {
                    x = iX * tileSize + edge; y = iY * tileSize + edge;
                    G.FillRectangle(colorSwitch ? Brushes.Green : Brushes.ForestGreen, x, y, tileSize, tileSize);
                    colorSwitch = !colorSwitch;
                    DATA.tileCoords[iX, iY].X = x;
                    DATA.tileCoords[iX, iY].Y = y;

                    x -= 1; y -= 1;
                    switch (DATA.tileTeamValues[iX, iY])
                    {
                        case (int)DATA.TeamValue.Empty:
                            break;
                        case (int)DATA.TeamValue.Black:
                            G.FillEllipse(Brushes.DimGray, x - sizeOut, y - sizeOut, tileSize + 1 + sizeOut * 2, tileSize + 1 + sizeOut * 2);
                            G.FillEllipse(Brushes.Black, x - sizeIn, y - sizeIn, tileSize + 1 + sizeIn * 2, tileSize + 1 + sizeIn * 2);
                            break;
                        case (int)DATA.TeamValue.White:
                            G.FillEllipse(Brushes.DimGray, x - sizeOut, y - sizeOut, tileSize + 1 + sizeOut * 2, tileSize + 1 + sizeOut * 2);
                            G.FillEllipse(Brushes.LightGray, x - sizeIn, y - sizeIn, tileSize + 1 + sizeIn * 2, tileSize + 1 + sizeIn * 2);
                            break;
                    }
                }
                UpdateTileCounts();
            }

            // text display
            string displayedText = "Team " + (DATA.currentTeam == 1 ? "Black" : "White") + "'s turn";
            SizeF stringWidth = G.MeasureString(displayedText, Font);
            G.DrawString(displayedText, Font, Brushes.White, (wind_x - stringWidth.Width) / 2, 2);
            label3.Text = "Turn: " + (DATA.currentTeam == 1 ? "Black" : "White");
            // borders aka highlight
            if (DATA.doHighlight)
            {
                int borderWidth = 1 + tileSize / 30; // actual width is borderwidth * 2
                for (int iA = 0; iA < gridsize; iA++)
                {
                    for (int iB = 0; iB < 1 + gridsize; iB++)
                    {
                        //vertical borders
                        if ((iB - 1 >= 0 && DATA.tileMarked[iB - 1, iA]) || (iB < gridsize && DATA.tileMarked[iB, iA]))
                        {
                            x = tileSize * iB + edge; y = tileSize * iA + edge;
                            G.FillRectangle(Brushes.White, x - borderWidth, y, borderWidth * 2 - 1, tileSize - 1);
                        }
                        //horizontal borders
                        if ((iB - 1 >= 0 && DATA.tileMarked[iA, iB - 1]) || (iB < gridsize && DATA.tileMarked[iA, iB]))
                        {
                            x = tileSize * iA + edge; y = tileSize * iB + edge;
                            G.FillRectangle(Brushes.White, x, y - borderWidth, tileSize - 1, borderWidth * 2 - 1);
                        }
                    }
                }
            }

        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Methods.IsClickInside(e.Location)) return;
            Point pos = Methods.GetTileAtPos(e.Location);
            if (DATA.tileMarked[pos.X, pos.Y])
            {
                DATA.tileTeamValues[pos.X, pos.Y] = DATA.currentTeam;
                Methods.FlipOctaRay(pos);
                // team switch
                if (DATA.currentTeam == (int)DATA.TeamValue.White) DATA.currentTeam = (int)DATA.TeamValue.Black;
                else if (DATA.currentTeam == (int)DATA.TeamValue.Black) DATA.currentTeam = (int)DATA.TeamValue.White;

                Methods.GridClearHighlight();
                Methods.HighlightAllPossibleOctaMoves();


                Refresh();

                Methods.CheckIfGameEnded();
                Refresh();
                UpdateTileCounts();
            }

        }
        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }
        private void button_highlight_Click(object sender, EventArgs e)
        {
            DATA.doHighlight = !DATA.doHighlight;
            Refresh();
        }
        private void button_restart_Click(object sender, EventArgs e)
        {
            Methods.RESET();
            UpdateTileCounts();
            Refresh();
        }

        // ----- -----  ----- -----  ----- -----  ----- -----  ----- -----  ----- -----  ----- -----  ----- -----  

        static class DATA
        {
            public enum TeamValue
            {
                Empty,
                Black,
                White,
                Both
            }

            public static int gridSize = 8; // amount of tiles (squared)
            public static int edge = 40; // width in pixels for the edge

            public static int wind_x = 0, wind_y = 0, tileSize = 0; // are updated during runtime (value in pixels)
            public static int amountOfMovesForCurrentTeam = 0; // updated during runtime
            /// <summary>
            /// Stores values found in the DATA.TeamValue enumerate
            /// </summary>
            public static int[,] tileTeamValues = new int[gridSize, gridSize];
            public static Point[,] tileCoords = new Point[gridSize, gridSize];
            public static bool[,] tileMarked = new bool[gridSize, gridSize];
            public static int currentTeam = (int)TeamValue.Black;
            public static bool doHighlight = false;




        }

        // ----- -----  ----- -----  ----- -----  ----- -----  ----- -----  ----- -----  ----- -----  ----- -----  

        static class Methods
        {
            public static bool IsClickInside(Point pos)
            {
                return pos.X >= DATA.tileCoords[0, 0].X
                    && pos.Y >= DATA.tileCoords[0, 0].Y
                    && pos.X < DATA.tileCoords[DATA.gridSize - 1, DATA.gridSize - 1].X + DATA.tileSize
                    && pos.Y < DATA.tileCoords[DATA.gridSize - 1, DATA.gridSize - 1].Y + DATA.tileSize;
            }
            public static Point GetTileAtPos(Point pos)
            {
                int tileSize = DATA.tileSize, tCx = DATA.tileCoords[0, 0].X, tCy = DATA.tileCoords[0, 0].Y;
                Point pt = new Point(
                    // Formula: moves grid to zero and divides the new upper-grid-end by the tilesize.
                    // Additionally decides if it is negative and adjusts the value by -1.
                    pos.X - tCx >= 0 ? (pos.X - tCx) / tileSize : (pos.X - tCx) / tileSize - 1,
                    pos.Y - tCy >= 0 ? (pos.Y - tCy) / tileSize : (pos.Y - tCy) / tileSize - 1);
                return pt;
            }
            public static void HighlightAllPossibleOctaMoves()
            {
                DATA.amountOfMovesForCurrentTeam = 0;
                for (int x = 0; x < DATA.gridSize; x++)
                    for (int y = 0; y < DATA.gridSize; y++)
                        if (DATA.tileTeamValues[x, y] == DATA.currentTeam)
                            HighlightPossibleOctaMoves(new Point(x, y));
            }
            private static void HighlightPossibleOctaMoves(Point pos)
            {
                List<Point> path;
                for (int i = 0; i < 16; i += 2) // goes through every path
                {
                    path = HighlightPossibleMoves(pos, VAR_directions[i], VAR_directions[i + 1]);
                    if (path.Count != 0)
                        for (int i2 = path.Count - 1; i2 >= 0; i2--) // goes through the currently indexed path
                        {
                            DATA.amountOfMovesForCurrentTeam++;
                            DATA.tileMarked[path[i2].X, path[i2].Y] = true;
                            break;
                        }
                }
            }
            private static readonly int[] VAR_directions = new int[16] {
                1, 0, 0, 1,
                -1, 0, 0, -1,
                1, 1, 1, -1,
                -1, 1, -1, -1};
            private static List<Point> HighlightPossibleMoves(Point pos, int stepX, int stepY)
            {
                int gridsize = DATA.gridSize; bool badcase = false, finish = false;
                List<Point> path = new List<Point>();
                for (int i = 1; i < gridsize - 1; i++)
                {
                    if (pos.X + i * stepX >= 0 && pos.X + i * stepX < gridsize
                        && pos.Y + i * stepY >= 0 && pos.Y + i * stepY < gridsize)
                        if (DATA.tileTeamValues[pos.X + i * stepX, pos.Y + i * stepY] == (int)DATA.TeamValue.Empty)
                        {
                            path.Add(new Point(pos.X + i * stepX, pos.Y + i * stepY));
                            finish = true; break;
                        }
                        else if (DATA.tileTeamValues[pos.X + i * stepX, pos.Y + i * stepY] != DATA.currentTeam)
                        {
                            path.Add(new Point(pos.X + i * stepX, pos.Y + i * stepY));
                        }
                        else { badcase = true; break; }
                }
                if (badcase || !finish || path.Count == 1) path.Clear();
                return path;
            }
            public static void FlipOctaRay(Point pos)
            {
                List<Point> path;
                int selectedTeam = DATA.tileTeamValues[pos.X, pos.Y];
                for (int i = 0; i < 16; i += 2) // goes through every path
                {
                    path = FlipRay(pos, VAR_directions[i], VAR_directions[i + 1]);
                    for (int i2 = 0; i2 < path.Count; i2++) // goes through the currently indexed path	
                        DATA.tileTeamValues[path[i2].X, path[i2].Y] = selectedTeam;

                }
            }
            private static List<Point> FlipRay(Point pos, int stepX, int stepY)
            {
                int gridsize = DATA.gridSize, selectedTeam = DATA.tileTeamValues[pos.X, pos.Y]; bool badcase = true;
                List<Point> path = new List<Point>();
                for (int i = 1; i < gridsize - 1; i++)
                {
                    if (pos.X + i * stepX >= 0 && pos.X + i * stepX < gridsize
                        && pos.Y + i * stepY >= 0 && pos.Y + i * stepY < gridsize)
                        if (DATA.tileTeamValues[pos.X + i * stepX, pos.Y + i * stepY] == (int)DATA.TeamValue.Empty)
                            break;
                        else if (DATA.tileTeamValues[pos.X + i * stepX, pos.Y + i * stepY] == selectedTeam)
                        { badcase = false; break; }
                        else if (DATA.tileTeamValues[pos.X + i * stepX, pos.Y + i * stepY] != selectedTeam)
                            path.Add(new Point(pos.X + i * stepX, pos.Y + i * stepY));
                }
                if (badcase) path.Clear();
                return path;
            }
            public static void GridClearHighlight()
            {
                for (int x = 0; x < DATA.gridSize; x++)
                    for (int y = 0; y < DATA.gridSize; y++)
                        DATA.tileMarked[x, y] = false;
            }
            public static void CheckIfGameEnded()
            {
                int black = 0, white = 0;
                for (int x = 0; x < DATA.gridSize; x++)
                    for (int y = 0; y < DATA.gridSize; y++)
                        if (DATA.tileTeamValues[x, y] == (int)DATA.TeamValue.Black) black++;
                        else if (DATA.tileTeamValues[x, y] == (int)DATA.TeamValue.White) white++;
                int winnerTeam = (int)DATA.TeamValue.Empty;
                if (black == 0) winnerTeam = (int)DATA.TeamValue.White;
                else if (white == 0) winnerTeam = (int)DATA.TeamValue.Black;
                else if (black + white == DATA.gridSize * DATA.gridSize)
                {
                    if (black == white) winnerTeam = (int)DATA.TeamValue.Both;
                    else if (black > white) winnerTeam = (int)DATA.TeamValue.Black;
                    else if (black < white) winnerTeam = (int)DATA.TeamValue.White;
                }
                else if (DATA.amountOfMovesForCurrentTeam == 0)
                    if (DATA.currentTeam == (int)DATA.TeamValue.Black) winnerTeam = (int)DATA.TeamValue.White;
                    else if (DATA.currentTeam == (int)DATA.TeamValue.White) winnerTeam = (int)DATA.TeamValue.Black;
                if (winnerTeam != (int)DATA.TeamValue.Empty)
                    switch (MessageBox.Show("Game ended: " +
                        (winnerTeam == (int)DATA.TeamValue.Black ? "Black won!" : winnerTeam == (int)DATA.TeamValue.White ? "White won!" : "Draw!"),
                        "Select something. Play again?", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            RESET();
                            break;
                        case DialogResult.No:
                            break;
                    }

            }
            public static void RESET()
            {
                if (DATA.gridSize >= 5)
                {
                    for (int x = 0; x < DATA.gridSize; x++)
                        for (int y = 0; y < DATA.gridSize; y++)
                            DATA.tileTeamValues[x, y] = (int)DATA.TeamValue.Empty;
                    DATA.tileTeamValues[3, 3] = 1;
                    DATA.tileTeamValues[3, 4] = 2;
                    DATA.tileTeamValues[4, 3] = 2;
                    DATA.tileTeamValues[4, 4] = 1;
                    DATA.currentTeam = (int)DATA.TeamValue.Black;
                    GridClearHighlight();
                    HighlightAllPossibleOctaMoves();
                }
            }
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Check if a game is in progress
            if (IsGameInProgress())
            {
                // Prompt the user to save the current game state
                DialogResult result = MessageBox.Show("Do you want to save the current game state before exiting?", "Save Game State", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    // Save the game state
                    SaveGameState();
                }
                else if (result == DialogResult.Cancel)
                {
                    // User canceled the exit action
                    return;
                }
            }

            // Close the game
            Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Check if a game is in progress
            if (IsGameInProgress())
            {
                // Prompt the user to save the current game state
                DialogResult result = MessageBox.Show("Do you want to save the current game state?", "Save Game State", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    // Save the game state
                    SaveGameState();
                }
                else if (result == DialogResult.Cancel)
                {
                    // User canceled the new game action
                    return;
                }
            }

            StartNewGame();
        }
        private void StartNewGame()
        {
            // Your existing logic for starting a new game goes here
            Methods.RESET();
            UpdateTileCounts();
            Refresh();
        }

        private bool IsGameInProgress()
        {
            for (int x = 0; x < DATA.gridSize; x++)
            {
                for (int y = 0; y < DATA.gridSize; y++)
                {
                    if (DATA.tileTeamValues[x, y] != (int)DATA.TeamValue.Empty)
                    {
                        // If any tile is filled, the game is in progress
                        return true;
                    }
                }
            }

            // If no tiles are filled, the game is not in progress
            return false;
        }

        private void SaveGameState()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files|*.json|All Files|*.*";
                saveFileDialog.Title = "Save Game State";
                saveFileDialog.DefaultExt = "json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    // Serialize game state to JSON
                    string jsonGameState = SerializeGameState();

                    // Save the serialized JSON to the selected file
                    File.WriteAllText(fileName, jsonGameState);

                    // Save the game state data to the game_data.json file
                    SaveToGameDataFile(fileName);
                }
            }
        }
        private void SaveToGameDataFile(string fileName)
        {
            const string gameDataFileName = "game_data.json";
            List<string> gameDataList = LoadGameDataList();

            if (gameDataList.Count >= 5)
            {
                // If the maximum number of game states is reached, prompt the user to specify which game state to overwrite
                string selectedGameState = PromptForGameState(gameDataList);
                if (selectedGameState == null)
                {
                    // User canceled the operation
                    return;
                }

                // Remove the selected game state from the list
                gameDataList.Remove(selectedGameState);
            }

            // Add the new game state to the list
            gameDataList.Add(fileName);

            // Save the updated list to game_data.json
            File.WriteAllText(gameDataFileName, JsonSerializer.Serialize(gameDataList));
        }

        private List<string> LoadGameDataList()
        {
            const string gameDataFileName = "game_data.json";

            if (File.Exists(gameDataFileName))
            {
                // Load the existing list of game states from game_data.json
                string json = File.ReadAllText(gameDataFileName);
                return JsonSerializer.Deserialize<List<string>>(json);
            }
            else
            {
                // Create a new list if game_data.json doesn't exist
                return new List<string>();
            }
        }


        private string SerializeGameState()
        {
            // Create a class or structure to represent the game state
            // Serialize the game state to a JSON string using a library

            GameState gameState = new GameState
            {
                GridSize = DATA.gridSize,
                TileTeamValues = DATA.tileTeamValues,
                CurrentTeam = DATA.currentTeam
            };

            // Serialize the game state to JSON
            string jsonGameState = JsonSerializer.Serialize(gameState);

            return jsonGameState;
        }
        private string PromptForGameState(List<string> gameDataList)
        {
            if (gameDataList.Count == 0)
            {
                // No existing game states to choose from
                return null;
            }

            string message = "Choose a game state to overwrite:\n";
            for (int i = 0; i < gameDataList.Count; i++)
            {
                message += $"{i + 1}. {Path.GetFileNameWithoutExtension(gameDataList[i])}\n";
            }

            message += "\nEnter the number (1-5) or press Cancel to skip:";

            string input = Microsoft.VisualBasic.Interaction.InputBox(message, "Choose Game State", "");

            if (int.TryParse(input, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= gameDataList.Count)
            {
                return gameDataList[selectedIndex - 1];
            }

            // Return null if the user cancels the operation or enters an invalid value
            return null;
        }


        [Serializable]
        public class GameState
        {
            public int GridSize { get; set; }
            public int[,] TileTeamValues { get; set; }
            public int CurrentTeam { get; set; }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            informationPanel.Checked = panel1.Visible;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

            // Check if a game is in progress
            if (IsGameInProgress())
            {
                // Save the game state
                SaveGameState();
            }
            else
            {
                MessageBox.Show("No game in progress to save.", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            List<string> gameDataList = LoadGameDataList();

            // Check if there are any game states saved
            if (gameDataList.Count == 0)
            {
                MessageBox.Show("No game states are saved.", "Restore Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // If only one game state is saved, restore the game to this state
            if (gameDataList.Count == 1)
            {
                string gameStateFilePath = gameDataList[0];
                RestoreGameState(gameStateFilePath);
            }
            else
            {
                // If more than one game state is saved, allow the user to select a state to restore
                string selectedGameState = PromptForGameState(gameDataList);
                if (selectedGameState != null)
                {
                    RestoreGameState(selectedGameState);
                }
            }
        }

        private void RestoreGameState(string gameStateFilePath)
        {
            // Load the selected game state
            string jsonGameState = File.ReadAllText(gameStateFilePath);

            // Deserialize the JSON to the GameState object
            GameState gameState = JsonSerializer.Deserialize<GameState>(jsonGameState);

            // Restore the game state
            DATA.gridSize = gameState.GridSize;
            DATA.tileTeamValues = gameState.TileTeamValues;
            DATA.currentTeam = gameState.CurrentTeam;

            // Update UI or any other necessary actions based on the restored game state
            UpdateTileCounts();
            Refresh();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
