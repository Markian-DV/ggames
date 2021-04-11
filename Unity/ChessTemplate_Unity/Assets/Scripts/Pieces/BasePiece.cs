using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public abstract class BasePiece : EventTrigger
{

    public Color mColor = Color.clear;
    public bool mIsFirstMove = true;

    public Cell mOriginalCell = null;
    public Cell mCurrentCell = null;
    public Cell mPreviousCell = null;

    protected RectTransform mRectTransform = null;
    public PieceManager mPieceManager;

    public Cell mTargetCell = null;

    protected Vector3Int mMovement = Vector3Int.one;
    public List<Cell> mHighlightedCells = new List<Cell>();
    public List<Cell> mHighlightedCells2 = new List<Cell>();
    List<Cell> attackList = new List<Cell>();

    public virtual void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        mPieceManager = newPieceManager;

        mColor = newTeamColor;
        GetComponent<Image>().color = newSpriteColor;
        mRectTransform = GetComponent<RectTransform>();

    }

    public virtual void Place(Cell newCell)
    {
        // Cell stuff
        mCurrentCell = newCell;
        mOriginalCell = newCell;
        mCurrentCell.mCurrentPiece = this;

        // Object stuff
        transform.position = newCell.transform.position;
        gameObject.SetActive(true);
    }

    public void Reset()
    {
        Kill();

        mIsFirstMove = true;

        Place(mOriginalCell);
    }

    public virtual void Kill()
    {
        // Clear current cell
        mCurrentCell.mCurrentPiece = null;

        // Remove piece
        gameObject.SetActive(false);
    }

    public bool HasMove()
    {
        CheckPathing(0);

        // If no moves
        if (mHighlightedCells.Count == 0)
            return false;

        // If moves available
        return true;
    }

    public void ComputerMove()
    {
        // Get random cell
        int i = UnityEngine.Random.Range(0, mHighlightedCells.Count);
        mTargetCell = mHighlightedCells[i];

        ClearCells();

        // Move to new cell
        Move();

        // End turn
        mPieceManager.SwitchSides(mColor);
    }

    #region Movement
    private void CreateCellPathCheck(int xDirection, int yDirection, int movement)
    {
        // Target position
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        // Check each cell
        for (int i = 1; i <= movement; i++)
        {
            currentX += xDirection;
            currentY += yDirection;

            // Get the state of the target cell
            CellState cellState = CellState.None;
            cellState = mCurrentCell.mBoard.ValidateCell(currentX, currentY, this);

            // If enemy, add to list, break
            if (cellState == CellState.Enemy)
            {
                mHighlightedCells2.Add(mCurrentCell.mBoard.mAllCells[currentX, currentY]);
                break;
            }

            // If the cell is not free, break
            if (cellState != CellState.Free)
                break;

            // Add to list
            mHighlightedCells2.Add(mCurrentCell.mBoard.mAllCells[currentX, currentY]);
        }
    }

    private void CreateCellPath(int xDirection, int yDirection, int movement)
    {
        // Target position
        int originalX = mCurrentCell.mBoardPosition.x;
        int originalY = mCurrentCell.mBoardPosition.y;

        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        // Check each cell
        for (int i = 1; i <= movement; i++)
        {
            currentX += xDirection;
            currentY += yDirection;

            // Get the state of the target cell
            CellState cellState = CellState.None;
            cellState = mCurrentCell.mBoard.ValidateCell(currentX, currentY, this);

            // Check

            if (cellState != CellState.OutOfBounds)
            {

                mCurrentCell.mBoard.mAllCells[currentX, currentY].mPreviousPiece = mCurrentCell.mBoard.mAllCells[currentX, currentY].mCurrentPiece;

                if (mCurrentCell.mBoard.mAllCells[currentX, currentY].mCurrentPiece != null)
                {
                    mCurrentCell.mBoard.mAllCells[currentX, currentY].mCurrentPiece.mCurrentCell.mBoardPosition.x = -20;
                    mCurrentCell.mBoard.mAllCells[currentX, currentY].mCurrentPiece.mCurrentCell.mBoardPosition.y = -20;
                }
                mCurrentCell.mBoard.mAllCells[currentX, currentY].mCurrentPiece = this;

                mCurrentCell.mBoard.mAllCells[originalX, originalY].mCurrentPiece.mCurrentCell.mBoardPosition.x = -20;
                mCurrentCell.mBoard.mAllCells[originalX, originalY].mCurrentPiece.mCurrentCell.mBoardPosition.y = -20;
                mCurrentCell.mBoard.mAllCells[originalX, originalY].mCurrentPiece = null;

                mCurrentCell.mBoardPosition.x = currentX;
                mCurrentCell.mBoardPosition.y = currentY;
                mCurrentCell.mCurrentPiece = this;

                int checkRes = mPieceManager.CheckCheck();

                mCurrentCell.mBoard.mAllCells[currentX, currentY].mCurrentPiece = mCurrentCell.mBoard.mAllCells[currentX, currentY].mPreviousPiece;

                if (mCurrentCell.mBoard.mAllCells[currentX, currentY].mCurrentPiece != null)
                {
                    mCurrentCell.mBoard.mAllCells[currentX, currentY].mCurrentPiece.mCurrentCell.mBoardPosition.x = currentX;
                    mCurrentCell.mBoard.mAllCells[currentX, currentY].mCurrentPiece.mCurrentCell.mBoardPosition.y = currentY;
                }

                mCurrentCell.mBoard.mAllCells[originalX, originalY].mCurrentPiece = this;
                mCurrentCell.mBoardPosition.x = originalX;
                mCurrentCell.mBoardPosition.y = originalY;
                mCurrentCell.mCurrentPiece = this;


                if ((checkRes == 1 && mColor == Color.black) || checkRes == 2)
                {
                    Debug.Log("Hello" + currentX + " " + currentY);
                    continue;
                }
                else if ((checkRes == 0 && mColor == Color.white) || checkRes == 2)
                {
                    Debug.Log("Wrong" + currentX + " " + currentY);
                    continue;
                }


            }

            // If enemy, add to list, break
            if (cellState == CellState.Enemy)
            {
                mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[currentX, currentY]);
                break;
            }

            Debug.Log("--Here " + currentX + " " + currentY + " " + cellState);
            // If the cell is not free, break
            if (cellState != CellState.Free)
                break;
            Debug.Log("--Break " + currentX + " " + currentY);
            // Add to list
            mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[currentX, currentY]);
        }
    }

    public virtual void CheckPathing(int t = 0)
    {
        if (t == 1)
        {
            // Horizontal
            CreateCellPathCheck(1, 0, mMovement.x);
            CreateCellPathCheck(-1, 0, mMovement.x);

            // Vertical 
            CreateCellPathCheck(0, 1, mMovement.y);
            CreateCellPathCheck(0, -1, mMovement.y);

            // Upper diagonal
            CreateCellPathCheck(1, 1, mMovement.z);
            CreateCellPathCheck(-1, 1, mMovement.z);

            // Lower diagonal
            CreateCellPathCheck(-1, -1, mMovement.z);
            CreateCellPathCheck(1, -1, mMovement.z);
        }
        else
        {
            // Horizontal
            CreateCellPath(1, 0, mMovement.x);
            CreateCellPath(-1, 0, mMovement.x);

            // Vertical 
            CreateCellPath(0, 1, mMovement.y);
            CreateCellPath(0, -1, mMovement.y);

            // Upper diagonal
            CreateCellPath(1, 1, mMovement.z);
            CreateCellPath(-1, 1, mMovement.z);

            // Lower diagonal
            CreateCellPath(-1, -1, mMovement.z);
            CreateCellPath(1, -1, mMovement.z);
        }
    }

    protected void ShowCells()
    {
        foreach (Cell cell in mHighlightedCells)
            cell.mOutlineImage.enabled = true;
    }

    public void ClearCells()
    {
        foreach (Cell cell in mHighlightedCells)
            cell.mOutlineImage.enabled = false;

        mHighlightedCells.Clear();
    }

    public virtual void MoveEnemy()
    {
        // If there is an enemy piece, remove it
        mTargetCell.RemovePiece();

        // Clear current
        mCurrentCell.mCurrentPiece = null;

        // Switch cells
        mCurrentCell = mTargetCell;
        mCurrentCell.mCurrentPiece = this;

        // Move on board
        transform.position = mCurrentCell.transform.position;
        mTargetCell = null;
    }

    public virtual void Move()
    {
        // First move switch
        mIsFirstMove = false;

        string sendRes = (7 - mCurrentCell.mBoardPosition.x) + "-" + (7 - mCurrentCell.mBoardPosition.y);
        sendRes += " " + (7 - mTargetCell.mBoardPosition.x) + "-" + (7 - mTargetCell.mBoardPosition.y);

        // If there is an enemy piece, remove it
        mTargetCell.RemovePiece();

        // Clear current
        mCurrentCell.mCurrentPiece = null;

        // Switch cells
        mCurrentCell = mTargetCell;
        mCurrentCell.mCurrentPiece = this;

        // Move on board
        transform.position = mCurrentCell.transform.position;
        mTargetCell = null;

        Connector(sendRes);
    }
    
    public void Connector(string sendRes) 
    {
        mCurrentCell.mBoard.SendMove(sendRes);
    }
    #endregion

    #region Events
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        // Test for cells
        CheckPathing(0);

        // Show valid cells
        ShowCells();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        // Follow pointer
        transform.position += (Vector3)eventData.delta;

        // Check for overlapping available squares
        foreach (Cell cell in mHighlightedCells)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(cell.mRectTransform, Input.mousePosition))
            {
                // If the mouse is within a valid cell, get it, and break.
                mTargetCell = cell;
                break;
            }

            // If the mouse is not within any highlighted cell, we don't have a valid move.
            mTargetCell = null;
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        // Hide
        ClearCells();

        // Return to original position
        if (!mTargetCell)
        {
            transform.position = mCurrentCell.gameObject.transform.position;
            return;
        }

        Move();

        // End turn
        mPieceManager.SwitchSides(mColor);
    }
    #endregion
}
