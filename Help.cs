using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            Color bg=Color.FromArgb(100,149,237);
            this.BackColor = bg;
            picMoves.Image = new Bitmap(GetPath() + @"\Content\FullSet.png");
            picPiece.Image = null;
            lblName.Text = "Game Flow";
            lblDefinition.Text = "The ultimate aim in the game of chess is to win by trapping your opponent's king. (This is called checkmate)\n\nWhite is always first to move and players take turns alternately moving one piece at a time. Movement is required.\n\nEach type of piece has its own method of movement (described in the following sections). A piece may be moved to another position or may capture an opponent's piece. This is done by landing on the appropriate square with the moving piece and removing the defending piece from play.\n\nWith the exception of the knight, a piece may not move over or through any of the other pieces.\n\nIn tournament play, once a piece has been touched by a player, it must be moved. In sandlot chess this rule is not always strictly adhered to.";

        }
        private string GetPath()
        {
            return Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf(@"\"));
        }

        private void btnPawn_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\PawnMoves.png");
            picPiece.Image = new Bitmap(GetPath() + @"\Content\pawn.png");
            lblName.Text = "Pawn";
            lblDefinition.Text = "There are eight pawns situated on each side of the board. They are the least powerful piece on the chess board, but have the potential to become equal to the most powerful. \n\nPawns cannot move backward or sideways, but must move straight ahead unless they are taking another piece. \n\nGenerally pawns move only one square at a time. The exception is the first time a pawn is moved, it may move forward two squares as long as there are no obstructing pieces. A pawn cannot take a piece directly in front of him but only one at a forward angle. In the diagram the blue and green dots show where the pawn may move and the red dots show where the pawn may capture a piece. In the case of a capture the pawn replaces the captured piece and the captured piece is removed from play.";
        }

        private void btnRook_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\RookMoves.png");
            picPiece.Image = new Bitmap(GetPath() + @"\Content\rook.png");
            lblName.Text = "Rook";
            lblDefinition.Text = "The rook, shaped like a castle, is one of the more powerful pieces on the board. The rooks, grouped with the queen, are often thought of as the \"major pieces\". Rooks are worth a bishop or a knight plus two pawns.\n\nThe rook can move any number of squares in a straight line along any column or row. They CANNOT move diagonally. In the example shown in the diagram on the right, the rook can move or capture in any square that has a blue dot. The simplicity of the rook's movement is indeed what makes it powerful. It can cover a significant area of the board and there are no areas which an opponent's piece - moving one square at a time - can slip through.";

        }

        private void btnBishop_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\BishopMoves.png");
            picPiece.Image = new Bitmap(GetPath() + @"\Content\Bishop.png");
            lblName.Text = "Bishop";
            lblDefinition.Text = "The bishop may move any number of squares in a diagonal direction until it is prevented from continuing by another piece.\n\nEach player begins with two bishops, one originally situated on a light square, the other on a dark square. Because of the nature of their movement, the bishops always remain on the same colored squares.\n\nBishops are a powerful piece (though less so than the queen or rooks). It is roughly equal in power to a knight or three pawns. Nevertheless, the bishop is a great piece to have in open situations when it can range the board. The knight is better in cluttered situations where it can utilize its ability to jump over other pieces.";
        }

        private void Knight_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\KnightMoves.png");
            picPiece.Image = new Bitmap(GetPath() + @"\Content\Knight.png");
            lblName.Text = "Knight";
            lblDefinition.Text = "The knight is the only piece on the board that may jump over other pieces. This gives it a degree of flexibility that makes it a powerful piece.\n\nSince obstructions are not a bar to movement (unless there is a friendly piece on the square where the knight would move) the knight's path of movement has never been well defined. \n\nThe knight can be thought of as moving one square along any rank or file and then at an angle, as defined in the diagram at right. (The blue dot is the space where the knight may move and may also capture opposition pieces.) The knight's movement can also be viewed as an \"L\" laid out at any horizontal or vertical angle.\n\nNote that the squares to where the knight can move are all of the opposite colored squares two steps away from his starting square. This may help you visualize the knights range of influence on the board.";
        }

        private void btnQueen_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\QueenMoves.png");
            picPiece.Image = new Bitmap(GetPath() + @"\Content\Queen.png");
            lblName.Text = "Queen";
            lblDefinition.Text = "The queen is, without doubt, the most powerful piece on the chessboard. She can move as many squares as she desires and in any direction (barring any obstructions). In the diagram on the right, the blue dots indicate to which squares this particular queen may move. As you can see, she can cover 27 squares. This is a healthy percentage of the board.\n\nShe captures in the same way that she moves, replacing the unlucky opposing piece that got in her way. (She must, of course, stop in the square of the piece she has captured - unlike the knight the queen does not jump other pieces.)\n\nThe queen's power is so great that she is considered to be worth more than any combination of two other pieces (with the exception of two rooks). Thus it would be better, under normal circumstances, to sacrifice a rook and a bishop (for example) than to give up a queen.\n\nStrategy Note: It is generally thought to be unwise to bring the queen out too early. The cluttered board makes her more vulnerable to entrapment.";
        }

        private void btnKing_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\KingMoves.png");
            picPiece.Image = new Bitmap(GetPath() + @"\Content\King.png");
            lblName.Text = "King";
            lblDefinition.Text = "Though not the most powerful piece on the board, the king is the most vital, for once he is lost the game is lost (more about this in the end game section). \n\nAs shown in the movement diagram, the king can only move one square in any direction. There is only one restriction on his movement - he may not move into a position where he may be captured by an opposing piece. Because of this rule, two kings may never stand next to each other or capture each other.\n\nStrategy Note: Guard the king closely. His loss means loss of the game. He is typically not a good piece to use on offense, but will be a help in a carefully constructed defense.";
        }

        private void lblGameFlow_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\FullSet.png");
            picPiece.Image = null;
            lblName.Text = "Game Flow";
            lblDefinition.Text = "The ultimate aim in the game of chess is to win by trapping your opponent's king. (This is called checkmate)\n\nWhite is always first to move and players take turns alternately moving one piece at a time. Movement is required.\n\nEach type of piece has its own method of movement (described in the following sections). A piece may be moved to another position or may capture an opponent's piece. This is done by landing on the appropriate square with the moving piece and removing the defending piece from play.\n\nWith the exception of the knight, a piece may not move over or through any of the other pieces.\n\nIn tournament play, once a piece has been touched by a player, it must be moved. In sandlot chess this rule is not always strictly adhered to.";
        }

        private void btnCastling_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\Castling.png");
            picPiece.Image = new Bitmap(GetPath() + @"\Content\King.png");
            lblName.Text = "Castling";
            lblDefinition.Text = "Castling is a special defensive maneuver. It is the only time in the game when more than one piece may be moved during a turn.\n\nThis move was invented in the 1500's to help speed up the game and to help balance the offense and defense. \n\nThe castling move has some fairly rigid caveats:\n\nIt can only occur if there are no pieces standing between the king and the rook. \n\nNeither king nor rook may have moved from its original position. \n\nThere can be no opposing piece that could possibly capture the king in his original square, the square he moves through or the square that he ends the turn. \n\nThe king moves two squares toward the rook he intends to castle with (this may be either rook). The rook then moves to the square through which the king passed. Hopefully, the diagram to the right makes this clear.\n\nStrategy Note: Castling is a great aid in defensive strategy. It also has a tendency to bring a powerful rook into play when under normal circumstances it might be stuck behind a wall of pawns.";

        }

        private void btnQueening_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\FullSet.png");
            picPiece.Image = new Bitmap(GetPath() + @"\Content\Queen.png");
            lblName.Text = "Queening";
            lblDefinition.Text = "Should a pawn get all the way across the board to reach the opponent's edge of the table, it will be promoted. The pawn may now become any piece that the moving player desires (except a king or pawn). Thus a player may end up having more than one queen on the board. Under normal circumstances a player will want to promote his pawn to be a queen since that piece is the most powerful and flexible. The new piece is placed where the pawn ended its movement.";

        }

        private void btnEndGame_Click(object sender, EventArgs e)
        {
            picMoves.Image = new Bitmap(GetPath() + @"\Content\FullSet.png");
            picPiece.Image = new Bitmap(GetPath() + @"\Content\pawn.png");
            lblName.Text = "End Game";
            lblDefinition.Text = "The game ends when one of the players captures his opponent's king, when one of the player's resigns or there is a stalemate.\n\nWhen a player's king is threatened by an opposing piece, it is said to be 'in check'. When a player places the opposing king in check he should announce, 'check'. The object of a player is not merely to place his opponent's king in check but to make certain that every square where the king has a possibility of movement is also covered. This is called checkmate. The king is considered captured.\n\nEither player may resign at any time. This generally happens when a player loses a major piece and the outlook for victory in his case appears bleak.\n\nStalemate is considered a tie. A stalemate occurs when a player's only move is to place his own king in check, but its current square is not threatened. As long as he can move another piece or the king can move to an open square, stalemate may not occur.\n\nA draw also results when the only two pieces on the board are Kings, regardless of their position. If the pieces remaining on the board make check mate impossible, for example one cannot checkmate an opponent with only a king and a bishop a draw would also result.";
        }
    }
}