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

    protected Cell mOriginalCell = null;
    protected Cell mCurrentCell = null;

    protected RectTransform mRectTransform = null;
    protected PieceManager mPieceManager;

    protected Cell mTargetCell = null;

    protected Vector3Int mMovement = Vector3Int.one;
    public List<Cell> mHighlightedCells = new List<Cell>();
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
    private void CreateCellPath(int xDirection, int yDirection, int movement, int t)
    {

        if (t == 0)
        {
            attackList = mPieceManager.CheckCheck();
        }

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

            if (t == 1 || attackList.Count < 1)
            {
                // If enemy, add to list, break
                if (cellState == CellState.Enemy)
                {
                    mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[currentX, currentY]);
                    break;
                }

                // If the cell is not free, break
                if (cellState != CellState.Free)
                    break;

                // Add to list
                mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[currentX, currentY]);
            }
            else if (mCurrentCell.mCurrentPiece.GetType().Name == "King")
            {
                if (cellState != CellState.Free)
                    break;

                if (mCurrentCell.mBoard.mAllCells[currentX, currentY].isAttack == false)
                {


                    // If enemy, add to list, break
                    if (cellState == CellState.Enemy)
                    {
                        mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[currentX, currentY]);
                        break;
                    }

                    // If the cell is not free, break
                    if (cellState != CellState.Free)
                        break;

                    // Add to list
                    mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[currentX, currentY]);
                }
            }
            else
            {

                if (cellState != CellState.Free)
                {
                    break;
                }

                if (mCurrentCell.mBoard.mAllCells[currentX, currentY].isAttack == true)
                {
                    mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[currentX, currentY]);
                    break;
                }
            }
        }
    }

    public virtual void CheckPathing(int t)
    {
        if (t == 1)
        {
            // Horizontal
            CreateCellPath(1, 0, mMovement.x, t);
            CreateCellPath(-1, 0, mMovement.x, t);

            // Vertical 
            CreateCellPath(0, 1, mMovement.y, t);
            CreateCellPath(0, -1, mMovement.y, t);

            // Upper diagonal
            CreateCellPath(1, 1, mMovement.z, t);
            CreateCellPath(-1, 1, mMovement.z, t);

            // Lower diagonal
            CreateCellPath(-1, -1, mMovement.z, t);
            CreateCellPath(1, -1, mMovement.z, t);
        }
        else
        {
            // Horizontal
            CreateCellPath(1, 0, mMovement.x, 0);
            CreateCellPath(-1, 0, mMovement.x, 2);

            // Vertical 
            CreateCellPath(0, 1, mMovement.y, 2);
            CreateCellPath(0, -1, mMovement.y, 2);

            // Upper diagonal
            CreateCellPath(1, 1, mMovement.z, 2);
            CreateCellPath(-1, 1, mMovement.z, 2);

            // Lower diagonal
            CreateCellPath(-1, -1, mMovement.z, 2);
            CreateCellPath(1, -1, mMovement.z, 2);

            mCurrentCell.mBoard.unSetAllAttack();
            attackList = new List<Cell>();
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

    protected virtual void Move()
    {
        // First move switch
        mIsFirstMove = false;

        string sendRes = mCurrentCell.mBoardPosition.x + "-" + mCurrentCell.mBoardPosition.y;
        sendRes += " " + mTargetCell.mBoardPosition.x + "-" + mTargetCell.mBoardPosition.y;
        Connector(sendRes);

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
