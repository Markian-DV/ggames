using UnityEngine;
using UnityEngine.UI;

public class Knight : BasePiece
{
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        // Base setup
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // Knight stuff
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Knight");
    }


    private void CreateCellPath(int flipper, int t)
    {
        // Target position
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        if (t == 1)
        {
            // Left
            MatchesState(currentX - 2, currentY + (1 * flipper));

            // Upper left
            MatchesState(currentX - 1, currentY + (2 * flipper));

            // Upper right
            MatchesState(currentX + 1, currentY + (2 * flipper));

            // Right
            MatchesState(currentX + 2, currentY + (1 * flipper));
        }
        else
        {
            // Left
            MatchesStateCheck(currentX - 2, currentY + (1 * flipper), mCurrentCell.mBoardPosition.x, mCurrentCell.mBoardPosition.y);

            // Upper left
            MatchesStateCheck(currentX - 1, currentY + (2 * flipper), mCurrentCell.mBoardPosition.x, mCurrentCell.mBoardPosition.y);

            // Upper right
            MatchesStateCheck(currentX + 1, currentY + (2 * flipper), mCurrentCell.mBoardPosition.x, mCurrentCell.mBoardPosition.y);

            // Right
            MatchesStateCheck(currentX + 2, currentY + (1 * flipper), mCurrentCell.mBoardPosition.x, mCurrentCell.mBoardPosition.y);
        }
    }

    // New
    public override void CheckPathing(int t=1)
    {
        if (t == 1)
        {
            // Draw top half
            CreateCellPath(1, t);

            // Draw bottom half
            CreateCellPath(-1, t);
        }
        else
        {
            // Draw top half
            CreateCellPath(1, t);

            // Draw bottom half
            CreateCellPath(-1, t);
        }
    }

    // New
    private void MatchesState(int targetX, int targetY)
    {
        CellState cellState = CellState.None;
        cellState = mCurrentCell.mBoard.ValidateCell(targetX, targetY, this);

        if (cellState != CellState.Friendly && cellState != CellState.OutOfBounds)
            mHighlightedCells2.Add(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
    }

    private void MatchesStateCheck(int targetX, int targetY, int originalX, int originalY)
    {
        CellState cellState = CellState.None;
        cellState = mCurrentCell.mBoard.ValidateCell(targetX, targetY, this);

        if (cellState != CellState.OutOfBounds)
        {

            FakeMove(targetX, targetY);
            int checkRes = mPieceManager.CheckCheck();
            FakeMove(originalX, originalY);

            if (mCurrentCell.mBoard.mAllCells[targetX, targetY].mPreviousPiece != null)
            {
                mCurrentCell.mBoard.mAllCells[targetX, targetY].mPreviousPiece.Place(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
            }

            if ((checkRes == 1 && mColor == Color.black) || checkRes == 2)
            {
                return;
            }
            else if ((checkRes == 0 && mColor == Color.white) || checkRes == 2)
            {
                return;
            }


        }

        if (cellState != CellState.Friendly && cellState != CellState.OutOfBounds)
            mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
    }

}
