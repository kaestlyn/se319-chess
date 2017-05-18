using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using ChessGame.Graphics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ChessGame.Input;

namespace ChessGame.Objects
{
     /// <summary>
    /// A Chess board. It keeps track of everything to do with a game of chess
    /// as well as handles all the game logic.
    /// </summary>
    class ChessBoard
    {
        const string WHITE = "Player 1";
        const string BLACK = "Player 2";
        const string CHECK = " in Check";
        const string TURN = @"'s Turn";
        const string CHECK_MATE = " Check Mate!";
        const string WIN = " Wins!";

        #region Member Variables (board, player1, player2, selectedSpaceLocation, spaceSelected, content, currentPlayersTurn)

        GameSquare[,] board;

        Piece[] player1;
        Piece[] player2;

        Vector2 selectedSpaceLocation;
        bool spaceSelected;
        ContentManager content;

        int currentPlayersTurn;

        InputHandler input;

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        SpriteFont spriteFont2;

        string gameMessage;
        string playerTurn;
        string winnerMessage;

        bool isGameOver;
        bool isGameQuit;
        bool isHelpOpen;
        bool isOptionsOpen;

        #endregion

        #region Properties (Board, Player1, Player2)

        public GameSquare[,] Board
        {
            get { return board; }
        }

        public Piece[] Player1
        {
            get { return player1; }
        }

        public Piece[] Player2
        {
            get { return player2; }
        }

        public bool IsGameOver
        {
            get { return isGameOver; }
        }

        //blah blah blah
        public bool IsGameQuit
        {
            get { return isGameQuit; }
        }

        #endregion

        public ChessBoard(InputHandler inp)
        {
            isHelpOpen = false;
            isOptionsOpen = false;
            isGameQuit = false;
            gameMessage = string.Empty;
            winnerMessage = string.Empty;
            playerTurn = WHITE + TURN;
            input = inp;
            currentPlayersTurn = 1;
            selectedSpaceLocation = new Vector2(-1, -1);
            spaceSelected = false;
            isGameOver = false;
            Color gameSpaceColor = Color.White;
            board = new GameSquare[8,8];
            player1 = new Piece[16];
            player2 = new Piece[16];

            //Create All the GameSquares
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (y == 0 || y == 7) //create back row of characters
                    {
                        CreateBackRowPeiceAt(x, y);
                    }
                    else if (y == 1 || y == 6)
                    {
                        CreatePawnAt(x, y);
                    }
                    else
                    {
                        board[x,y] = new GameSquare(null);
                    }
                    board[x, y].DefaultColor = gameSpaceColor;
                    if (x != 7)
                    {
                        if (gameSpaceColor == Color.White)
                        {
                            gameSpaceColor = Color.Gray;
                        }
                        else
                        {
                            gameSpaceColor = Color.White;
                        }
                    }
                }
            }

            //Move the kings to the end of the array
            Piece temp = player1[15];
            player1[15] = player1[12];
            player1[12] = temp;

            temp = player2[15];
            player2[15] = player2[12];
            player2[12] = temp;
        }

        #region Main Methods (Initialize, LoadGraphicsContent, Update, Draw)

        /// <summary>
        /// Initializes the ChessBoard. Sets up all the member variables that are value based
        /// as well as Initializing the peices of the game.
        /// </summary>
        /// <param name="content">Where all the game's content is for loading graphics.</param>
        /// <param name="game">Current XNA Game, used to center the gameboard on the window.</param>
        public void Initialize(ContentManager content, Game game)
        {
            this.content = content;

            int startx = (game.Window.ClientBounds.Width - 400) / 2;
            int starty = (game.Window.ClientBounds.Height - 400) / 2;

            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (board[x, y].HasPiece)
                    {
                        board[x, y].CurrentPiece.Initialize(new Vector2(startx + (50 * x), starty + (50 * y)));
                    }
                    board[x, y].Initialize(new Vector2( startx + (50 * x ), starty + ( 50 * y ) ));
                }
            }
            CalculateNextTurnMoves();
        }

        /// <summary>
        /// Sets up all the graphics for the chess board.
        /// </summary>
        /// <param name="spriteBatch">Used to draw the graphics.</param>
        public void LoadGraphicsContent(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            Texture2D whites = content.Load<Texture2D>(@"Content\Whites");
            Texture2D gameSquare = content.Load<Texture2D>(@"Content\GameSquare");

            //Loop through all Spaces and Load their Graphics Content
            for (int i = 0 ; i < board.GetLength(0) ; i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j].LoadGraphicsContent(spriteBatch, gameSquare);
                    if (board[i, j].HasPiece)
                    {
                        board[i, j].CurrentPiece.LoadGraphicsContent(spriteBatch, whites);
                    }
                }
            }

            //Load Font for Displaying Messages
            spriteFont = content.Load<SpriteFont>(@"Content\SpriteFont1");
            spriteFont2 = content.Load<SpriteFont>(@"Content\SpriteFont2");
        }

        /// <summary>
        /// Updates the game logic. This is called as fast as possible.
        /// </summary>
        /// <param name="gameTime">The amount of time since the last time.</param>
        public void Update(GameTime gameTime)
        {
            if (isOptionsOpen == false)
            {
                HandleKeyboard();
                HandleMouse();
            }
        }
            
        /// <summary>
        /// Draws all the sprites to the screen.
        /// </summary>
        /// <param name="gameTime">The amount of time since the last time.</param>
        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            //Loop through all Spaces and Draw them
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j].Draw(gameTime);
                    if (board[i, j].HasPiece)
                    {
                        board[i, j].CurrentPiece.Draw(gameTime);
                    }
                }
            }
            //Display Help
            spriteBatch.DrawString(spriteFont2, "  Legend", new Vector2(625, 500), Color.White);
            spriteBatch.DrawString(spriteFont2, "ESC = Quit", new Vector2(625, 520), Color.White);
            spriteBatch.DrawString(spriteFont2, " H  = Help", new Vector2(625, 540), Color.White);
            spriteBatch.DrawString(spriteFont2, " O  = Options", new Vector2(625, 560), Color.White);
            spriteBatch.DrawString(spriteFont2, " F  = Forfeit", new Vector2(625, 580), Color.White);

            //Display the Messages
            spriteBatch.DrawString(spriteFont, gameMessage, new Vector2(625, 287), Color.White);
            spriteBatch.DrawString(spriteFont, winnerMessage, new Vector2(625, 323), Color.White);
            //Display whose turn it is
            spriteBatch.DrawString(spriteFont, playerTurn, new Vector2(45, 287), Color.White);
            spriteBatch.End();
        }

        #endregion

        #region Public Methods (BoardLayout)

        public Hashtable BoardLayout()
        {
            Hashtable boardLayout = new Hashtable();
            foreach (Piece p1 in player1)
            {
                if (p1.IsDead) { }
                else
                {
                    boardLayout.Add(p1.Position, p1);
                }
            }
            foreach (Piece p2 in player2)
            {
                if (p2.IsDead) { }
                else
                {
                    boardLayout.Add(p2.Position, p2);
                }
            }
            return boardLayout;
        }

        #endregion

        #region Private Methods (CreatePawn, CreateBackRowPeices, HandleMouse, HandleController)

        private void CreatePawnAt(int columnIndex, int rowIndex)
        {
            Piece piece = new Pawn();
            piece.CurrentLocation = new Vector2(columnIndex, rowIndex);
            if (rowIndex == 1)
            {
                piece.PlayerIndex = 2;
                player2[columnIndex] = piece;
            }
            else
            {
                piece.PlayerIndex = 1;
                player1[columnIndex] = piece;
            }
            board[columnIndex, rowIndex] = new GameSquare(piece);
        }

        private void CreateBackRowPeiceAt(int columnIndex, int rowIndex)
        {
            Piece piece;

            switch (columnIndex)
            {
                case 0:
                case 7:
                    piece = new Rook();
                    break;
                case 1:
                case 6:
                    piece = new Knight();
                    break;
                case 2:
                case 5:
                    piece = new Bishop();
                    break;
                case 3:
                    piece = new Queen();
                    break;
                default:
                    piece = new King();
                    break;
            }
            piece.CurrentLocation = new Vector2(columnIndex, rowIndex);
            if (rowIndex == 0)
            {
                piece.PlayerIndex = 2;
                player2[8 + columnIndex] = piece;
            }
            else
            {
                piece.PlayerIndex = 1;
                player1[8 + columnIndex] = piece;
            }
            board[columnIndex, rowIndex] = new GameSquare(piece);
        }

        private void HandleMouse()
        {
            input.MouseState.Update();
            //User clicked something, so lets see what it was

            if (input.MouseState.WasLeftButtonPressed() == true)
            {
                //First find out what square they clicked
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        //First toggle is unselected

                        //If they clicked this space...set it to be selected
                        if (input.MouseState.ButtonClick(board[x, y]) == true)
                        {
                            if (spaceSelected) //They want to move current selection to this space.
                            {
                                if (board[x, y] != board[(int)selectedSpaceLocation.X, (int)selectedSpaceLocation.Y])
                                {
                                    //CHECK IF IT IS A VALID MOVE
                                    if (board[(int)selectedSpaceLocation.X, (int)selectedSpaceLocation.Y].CurrentPiece.PossibleMoves.Contains(new Vector2(x, y)))
                                    {
                                        gameMessage = string.Empty;
                                        winnerMessage = string.Empty;
                                        // Store current location and Piece on new location
                                        Vector2 oldLocation = new Vector2(selectedSpaceLocation.X, selectedSpaceLocation.Y);
                                        Piece oldPiece = board[x, y].CurrentPiece; // can be null
                                        if (oldPiece != null)
                                        {
                                            oldPiece.CurrentLocation = new Vector2(-1, -1);
                                        }
                                        List<Vector2> oldPossibleMoves = board[(int)selectedSpaceLocation.X, (int)selectedSpaceLocation.Y].CurrentPiece.PossibleMoves;
                                       
                                        //If there is a piece there capture it.
                                        board[x, y].CurrentPiece = board[(int)selectedSpaceLocation.X, (int)selectedSpaceLocation.Y].CurrentPiece;

                                        //Move the piece and unselect the space
                                        board[(int)selectedSpaceLocation.X, (int)selectedSpaceLocation.Y].CurrentPiece = null;
                                        board[(int)selectedSpaceLocation.X, (int)selectedSpaceLocation.Y].IsSelected = false;

                                        //Tell the peice its new location
                                        board[x, y].CurrentPiece.CurrentLocation = new Vector2(x, y);
                                               
                                        CalculateNextTurnMoves();
                                        
                                        QueeningCheck(x, y);
                                        //Check if they moved themselves into check
                                        bool movedIntoCheck = CalculateCheck(currentPlayersTurn);
                                        if (movedIntoCheck)
                                        {
                                            //un-capture piece
                                            board[(int)oldLocation.X, (int)oldLocation.Y].CurrentPiece = board[x, y].CurrentPiece;
                                            
                                            //Move the piece and unselect the space
                                            board[(int)oldLocation.X, (int)oldLocation.Y].CurrentPiece = board[x, y].CurrentPiece;
                                            board[(int)oldLocation.X, (int)oldLocation.Y].IsSelected = true;

                                            board[x, y].CurrentPiece = oldPiece;
                                            
                                            //Tell the peice its new location
                                            if (board[x, y].HasPiece)
                                            {
                                                board[x, y].CurrentPiece.CurrentLocation = new Vector2(x, y);
                                            }
                                            board[(int)oldLocation.X, (int)oldLocation.Y].CurrentPiece.CurrentLocation = new Vector2((int)oldLocation.X, (int)oldLocation.Y);
                                            

                                            CalculateNextTurnMoves();
                                            //TODO: Indicate to user they are trying to move in check
                                            winnerMessage = "Invalid Move"; 

                                            
                                        }
                                        else
                                        {
                                            // TODO: move outside to check for check - FIX ME!!!!!
                                            if (oldPiece != null && oldPiece.PlayerIndex != currentPlayersTurn)
                                            {
                                                oldPiece.IsDead = true;
                                            }
                                            else if (oldPiece != null && oldPiece.PlayerIndex == currentPlayersTurn)
                                            {
                                                if (oldPiece.GetType().Equals(new King().GetType()))
                                                {
                                                    if (oldLocation.X == 0)
                                                    {
                                                        oldPiece.CurrentLocation = new Vector2(2, oldLocation.Y);
                                                        board[2, (int)oldLocation.Y].CurrentPiece = oldPiece;
                                                        board[3, y].CurrentPiece = board[x, y].CurrentPiece;
                                                        board[3, y].CurrentPiece.CurrentLocation = new Vector2(3, y);
                                                        board[x, y].CurrentPiece = null;
                                                    }
                                                    else
                                                    {
                                                        oldPiece.CurrentLocation = new Vector2(6, oldLocation.Y);
                                                        board[6, (int)oldLocation.Y].CurrentPiece = oldPiece;
                                                        board[5, y].CurrentPiece = board[x, y].CurrentPiece;
                                                        board[5, y].CurrentPiece.CurrentLocation = new Vector2(5, y);
                                                        board[x, y].CurrentPiece = null;
                                                    }
                                                }
                                                else
                                                {
                                                    if (x == 0)
                                                    {
                                                        oldPiece.CurrentLocation = new Vector2(3, oldLocation.Y);
                                                        board[3, (int)oldLocation.Y].CurrentPiece = oldPiece;
                                                        board[2, y].CurrentPiece = board[x, y].CurrentPiece;
                                                        board[2, y].CurrentPiece.CurrentLocation = new Vector2(2, y);
                                                        board[x, y].CurrentPiece = null; 
                                                    }
                                                    else
                                                    {
                                                        oldPiece.CurrentLocation = new Vector2(5, oldLocation.Y);
                                                        board[5, (int)oldLocation.Y].CurrentPiece = oldPiece;
                                                        board[6, y].CurrentPiece = board[x, y].CurrentPiece;
                                                        board[6, y].CurrentPiece.CurrentLocation = new Vector2(6, y);
                                                        board[x, y].CurrentPiece = null;
                                                        
                                                    }
                                                }                                      
                                            }

                                            //Check if they put opponent in check
                                            bool opponentInCheck = CalculateCheck(currentPlayersTurn + 1);
                                            if(opponentInCheck)
                                            {
                                                bool checkMate = CalculateCheckMate(currentPlayersTurn + 1);
                                                if (checkMate)
                                                {
                                                    if (currentPlayersTurn % 2 == 1)
                                                    {
                                                        gameMessage = BLACK + CHECK_MATE;
                                                        winnerMessage = WHITE + WIN;
                                                    }
                                                    else
                                                    {
                                                        gameMessage = WHITE + CHECK_MATE;
                                                        winnerMessage = BLACK + WIN;
                                                    }
                                                    isGameOver = true; //TODO: GameOver!!!!
                                                }
                                                else
                                                {
                                                    if (currentPlayersTurn % 2 == 1)
                                                    {
                                                        gameMessage = BLACK + CHECK;
                                                    }
                                                    else
                                                    {
                                                        gameMessage = WHITE + CHECK;
                                                    }
                                                }
                                            }

                                            //Do after move code
                                            if (board[x, y].CurrentPiece != null)
                                            {
                                                board[x, y].CurrentPiece.AfterMove();
                                            }
                                            //Setup the new ChessBoard Member Variables
                                            spaceSelected = false;
                                            foreach (Vector2 vec in oldPossibleMoves)
                                            {
                                                board[(int)vec.X, (int)vec.Y].IsPossibleMove = false;
                                            }
                                            selectedSpaceLocation = new Vector2(-1, -1);
                                            ChangePlayersTurn();                              
                                        }
                                    }
                                    else 
                                    {
                                        //Not a possible move
                                    }
                                }
                                else
                                {
                                    selectedSpaceLocation = new Vector2(-1, -1);
                                    spaceSelected = false;
                                    board[x, y].IsSelected = false;
                                    foreach (Vector2 vec in board[x, y].CurrentPiece.PossibleMoves)
                                    {
                                        board[(int)vec.X, (int)vec.Y].IsPossibleMove = false;
                                    }
                                }

                            }
                            else
                            {
                                if (board[x, y].HasPiece && board[x, y].CurrentPiece.PlayerIndex == currentPlayersTurn)
                                {
                                    board[x, y].IsSelected = true;
                                    foreach (Vector2 vec in board[x, y].CurrentPiece.PossibleMoves)
                                    {
                                        board[(int)vec.X, (int)vec.Y].IsPossibleMove = true;
                                    }
                                    spaceSelected = true;
                                    selectedSpaceLocation = new Vector2(x, y);
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void HandleKeyboard()
        {
            input.KeyboardState.Update();
            //See if they want to quit
            if (input.KeyboardState.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.Escape) == true)
            {
                if (System.Windows.Forms.MessageBox.Show("Are you sure you want to quit this game?", "Quit", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    isGameQuit = true;
                    return;
                }
            }

            //See if they want the options menu
            if (input.KeyboardState.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.O) == true)
            {
                isOptionsOpen = true;
                Options frmOptions = new Options();
                frmOptions.FormClosed += new FormClosedEventHandler(FormOptions_Closed);
                frmOptions.ShowDialog();
            }

            //See if they want hte help menu
            if ( isHelpOpen == false && input.KeyboardState.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.H) == true)
            {
                isHelpOpen = true;
                Help frmHelp = new Help();
                frmHelp.FormClosed += new FormClosedEventHandler(FormHelp_Closed);
                frmHelp.Show();
            }

            //See if they want to forfiet
            if (input.KeyboardState.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.F) == true)
            {
                if (MessageBox.Show("Would Player " + currentPlayersTurn + " like to forfeit?", "Forfeit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //End game
                    if (currentPlayersTurn == 1)
                    {
                        gameMessage = WHITE + CHECK_MATE;
                        winnerMessage = BLACK + WIN;
                    }
                    else
                    {
                        gameMessage = BLACK + CHECK_MATE;
                        winnerMessage = WHITE + WIN;
                    }
                    isGameOver = true; 
                }
                while (input.MouseState.WasLeftButtonPressed() == true)
                {
                    input.MouseState.Update();
                }

            }
        }

        private void FormOptions_Closed(object sender, FormClosedEventArgs e)
        {
            isOptionsOpen = false;
            //Dump the closing mouse left click
            while (input.MouseState.WasLeftButtonPressed() == true)
            {
                input.MouseState.Update();
            }

            for (int i = 0; i < 16; i++)
            {
                player1[i].UpdateColors();
                player2[i].UpdateColors();
            }
        }

        private void FormHelp_Closed(object sender, FormClosedEventArgs e)
        {
            isHelpOpen = false;
        }


        private bool CalculateCheck(int player)
        {
            Piece king;
            Piece[] opponentPieces;
            if (player % 2 == 1)
            {
                king = player1[15];
                opponentPieces = player2;
            }
            else
            {
                king = player2[15];
                opponentPieces = player1;
            }
            bool retValue = false;
            for (int index = 0; index < opponentPieces.Length && retValue == false; index++)
            {
                if (!opponentPieces[index].IsDead)
                {
                    retValue = opponentPieces[index].PossibleMoves.Contains(king.CurrentLocation);
                }
            }
            return retValue;
        }

        private bool CalculateCheckMate(int player)
        {
            Piece king;
            Piece[] allyPieces;
            Piece[] opponentPieces;
            if (player % 2 == 1)
            {
                allyPieces = player1;
                king = player1[15];
                opponentPieces = player2;
            }
            else
            {
                allyPieces = player2;
                king = player2[15]; 
                opponentPieces = player1;
            }
            bool retValue = true;

            // Store current location and possible moves
            Vector2 originalKingLocation = king.CurrentLocation;
            List<Vector2> kingPossibleMoves = king.PossibleMoves;

            foreach (Vector2 vec in kingPossibleMoves)
            {
                // Store current piece on possible move 
                Piece piece = board[(int)vec.X, (int)vec.Y].CurrentPiece;

                //Simulate moving the king to the possible gamesquare and capture of opponent piece if it exists              
                if (piece != null)
                {
                    piece.CurrentLocation = new Vector2(-1, -1);
                }
                king.CurrentLocation = new Vector2(vec.X, vec.Y);
                board[(int)king.CurrentLocation.X, (int)king.CurrentLocation.Y].CurrentPiece = king;
            
                CalculateNextTurnMoves();
                //Check if they moved themselves into check
                bool movedIntoCheck = CalculateCheck(currentPlayersTurn + 1);
                king.CurrentLocation = originalKingLocation;
                board[(int)king.CurrentLocation.X, (int)king.CurrentLocation.Y].CurrentPiece = king;
                if (piece != null)
                {
                    piece.CurrentLocation = new Vector2(vec.X, vec.Y);
                    board[(int)piece.CurrentLocation.X, (int)piece.CurrentLocation.Y].CurrentPiece = piece;
                }
                else
                {
                    board[(int)vec.X, (int)vec.Y].CurrentPiece = null;
                }
                CalculateNextTurnMoves(); 
                if (!movedIntoCheck)
                {
                    retValue = false;
                    break;
                }
                
                // Else king cannot move to gamesquare - ally piece on gamesquare
            }
            king.CurrentLocation = originalKingLocation;
            board[(int)king.CurrentLocation.X, (int)king.CurrentLocation.Y].CurrentPiece = king;
            CalculateNextTurnMoves(); // calculates moves for orignal king location
                                
            if(retValue) // King cannot move itself out of check - check for possible block/capture
            {
                foreach (Piece opponent in opponentPieces)
                {
                    if (!opponent.IsDead)
                    {
                        // opponent piece has king in check
                        if (opponent.PossibleMoves.Contains(king.CurrentLocation))
                        {
                            // TODO: Get line to king 
                            List<Vector2> lineToKing = opponent.CaptureLine(king.CurrentLocation);
                            // can ally piece capture or block opponent?
                            foreach (Piece ally in allyPieces)
                            {
                                if (!ally.IsDead && !(ally.GetType().Equals(new Graphics.King().GetType())))
                                {
                                    #region simulate blocking
                                    foreach (Vector2 line in lineToKing)
                                    {
                                        if (ally.PossibleMoves.Contains(line))
                                        {
                                            // Yes
                                            //  -> simulate move & calculate next moves & calculate check (check is false->return false & break loop)

                                            // Store current piece on possible move 
                                            Piece opPiece = board[(int)line.X, (int)line.Y].CurrentPiece;

                                            //Simulate moving the ally to the possible gamesquare and capture of opponent piece if it exists 
                                            if (opPiece != null)
                                            {
                                                opPiece.CurrentLocation = new Vector2(-1, -1);
                                            }
                                            Vector2 allyLocation = ally.CurrentLocation;
                                            ally.CurrentLocation = new Vector2(line.X, line.Y);
                                            board[(int)line.X, (int)line.Y].CurrentPiece = ally;

                                            CalculateNextTurnMoves();
                                            //Check if they moved themselves into check
                                            bool movedIntoCheck = CalculateCheck(currentPlayersTurn);

                                            ally.CurrentLocation = allyLocation;
                                            board[(int)ally.CurrentLocation.X, (int)ally.CurrentLocation.Y].CurrentPiece = ally;
                                            if (opPiece != null)
                                            {
                                                opPiece.CurrentLocation = new Vector2(line.X, line.Y);
                                                board[(int)line.X, (int)line.Y].CurrentPiece = opPiece;
                                            }
                                            else
                                            {
                                                board[(int)line.X, (int)line.Y].CurrentPiece = null;
                                            }
                                            if (!movedIntoCheck)
                                            {
                                                retValue = false;
                                                break;
                                            }
                                        }
                                        if (!retValue)
                                        {
                                            break;
                                        }
                                    }
                                    #endregion
                                }
                                if (!retValue)
                                {
                                    break;
                                }

                            }
                            if (!retValue)
                            {
                                break;
                            }
                        }
                    }
                    
                }
            }
            CalculateNextTurnMoves();
            return retValue;
        }



        private void QueeningCheck(int x, int y)
        {
            if (board[x, y].CurrentPiece != null && board[x, y].CurrentPiece.GetType().Equals(new Pawn().GetType()))
            {
                if (board[x, y].CurrentPiece.CurrentLocation.Y == 0 || board[x, y].CurrentPiece.CurrentLocation.Y == 7)
                {
                    Piece transfer = new Queen();
                    transfer.PlayerIndex = board[x, y].CurrentPiece.PlayerIndex;
                    transfer.CurrentLocation = board[x, y].CurrentPiece.CurrentLocation;
                    transfer.Position = board[x, y].CurrentPiece.Position;
                    transfer.Color = board[x, y].CurrentPiece.Color;
                    transfer.Initialize(board[x, y].CurrentPiece.Position);
                    transfer.LoadGraphicsContent(spriteBatch, content.Load<Texture2D>(@"Content\Whites"));
                    transfer.CalculateMoves(this);
                    board[x, y].CurrentPiece = transfer;
                    if (transfer.PlayerIndex == 1)
                    {
                        for (int index = 0; index < 8; index++)
                        {
                            if (player1[index].CurrentLocation.Equals(board[x, y].CurrentPiece.CurrentLocation))
                            {
                                player1[index] = transfer;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int index = 0; index < 8; index++)
                        {
                            if (player2[index].CurrentLocation.Equals(board[x, y].CurrentPiece.CurrentLocation))
                            {
                                player2[index] = transfer;
                                break;
                            }
                        }
                    }
                }
            }
            CalculateNextTurnMoves();

        }

        private void ChangePlayersTurn()
        {
            //Don't ask!
            currentPlayersTurn = (currentPlayersTurn % 2) + 1;
            if (currentPlayersTurn % 2 == 1)
            {
                playerTurn = WHITE + TURN;
            }
            else
            {
                playerTurn = BLACK + TURN;
            }
        }

        private void CalculateNextTurnMoves()
        {
            for (int i = 0; i < 16; i++)
            {
                player1[i].CalculateMoves(this);
                player2[i].CalculateMoves(this);
            }
        }

        #endregion
    }
}
