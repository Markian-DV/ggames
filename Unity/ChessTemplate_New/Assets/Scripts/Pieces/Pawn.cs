using UnityEngine;
using UnityEngine.UI;

public class Pawn : BasePiece
{
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        // Base setup
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // Pawn Stuff
        mMovement = mColor == Color.white ? new Vector3Int(0, 1, 1) : new Vector3Int(0, -1, -1);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Pawn");
    }

    public override void Move()
    {
        base.Move();

        CheckForPromotion();
    }

    public override void MoveEnemy()
    {
        // If there is an enemy piece, remove it
        base.MoveEnemy();
        CheckForPromotion();
    }

    private bool MatchesStateCheck(int targetX, int targetY, CellState targetState)
    {
        CellState cellState = CellState.None;
        cellState = mCurrentCell.mBoard.ValidateCell(targetX, targetY, this);

        if (cellState == targetState)
        {
            mHighlightedCells2.Add(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
            return true;
        }

        return false;
    }

    private bool MatchesState(int targetX, int targetY, CellState targetState, int originalX, int originalY)
    {
        CellState cellState = CellState.None;
        cellState = mCurrentCell.mBoard.ValidateCell(targetX, targetY, this);

        if (cellState == targetState)
        {
            mCurrentCell.mBoard.mAllCells[targetX, targetY].mPreviousPiece = null;

            FakeMove(targetX, targetY);
            int checkRes = mPieceManager.CheckCheck();
            FakeMove(originalX, originalY);

            if (mCurrentCell.mBoard.mAllCells[targetX, targetY].mPreviousPiece != null)
            {
                 mCurrentCell.mBoard.mAllCells[targetX, targetY].mPreviousPiece.Place(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
                 mCurrentCell.mBoard.mAllCells[targetX, targetY].mPreviousPiece = null;
            }

            if ((checkRes == 1 && mColor == Color.black) || checkRes == 2)
            {
                return true;
            }
            else if ((checkRes == 0 && mColor == Color.white) || checkRes == 2)
            {
                return true;
            }

            mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
            return true;
        }

        return false;
    }

    private void CheckForPromotion()
    {
        // Target position
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;
        CellState cellState;
        Debug.Log("Heey");
        if (mColor == Color.white)
        {
            // Check if pawn has reached the end of the board
            cellState = mCurrentCell.mBoard.ValidateCell(currentX, currentY + mMovement.y, this);
        }
        else
        {
            Debug.Log("Hello + " + currentX + " = " + (currentY - 1));
            // Check if pawn has reached the end of the board
            cellState = mCurrentCell.mBoard.ValidateCell(currentX, currentY - 1, this);
        }

        if (cellState == CellState.OutOfBounds)
        {
            Color spriteColor = GetComponent<Image>().color;
            mPieceManager.PromotePiece(this, mCurrentCell, mColor, spriteColor);
        }
    }

    public override void CheckPathing(int t = 0)
    {
        int originalX = mCurrentCell.mBoardPosition.x;
        int originalY = mCurrentCell.mBoardPosition.y;

        // Target position
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        if (t == 1)
        {
            // Top left
            MatchesStateCheck(currentX - mMovement.z, currentY + mMovement.z, CellState.Enemy);

            // Forward
            if (MatchesStateCheck(currentX, currentY + mMovement.y, CellState.Free))
            {
                // If the first forward cell is free, and first move, check for next
                if (mIsFirstMove)
                {
                    MatchesStateCheck(currentX, currentY + (mMovement.y * 2), CellState.Free);
                }
            }

            // Top right
            MatchesStateCheck(currentX + mMovement.z, currentY + mMovement.z, CellState.Enemy);
        }
        else
        {
            // Top left
            MatchesState(currentX - mMovement.z, currentY + mMovement.z, CellState.Enemy, originalX, originalY);

            // Forward
            if (MatchesState(currentX, currentY + mMovement.y, CellState.Free, originalX, originalY))
            {
                // If the first forward cell is free, and first move, check for next
                if (mIsFirstMove)
                {
                    MatchesState(currentX, currentY + (mMovement.y * 2), CellState.Free, originalX, originalY);
                }
            }

            // Top right
            MatchesState(currentX + mMovement.z, currentY + mMovement.z, CellState.Enemy, originalX, originalY);
        }
    }
}
