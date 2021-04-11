using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PieceManager : MonoBehaviourPunCallbacks
{
    private PhotonView photonView;
    public bool mAreKingsAlive = true;

    public GameObject mPiecePrefab;

    private List<BasePiece> mWhitePieces = null;
    private List<BasePiece> mBlackPieces = null;
    private List<BasePiece> mPromotedPieces = new List<BasePiece>();

    public string[] mPieceOrder = new string[16]
    {
        "P", "P", "P", "P", "P", "P", "P", "P",
        "R", "KN", "B", "Q", "K", "B", "KN", "R"
    };

    private Dictionary<string, Type> mPieceLibrary = new Dictionary<string, Type>()
    {
        {"P",  typeof(Pawn)},
        {"R",  typeof(Rook)},
        {"KN", typeof(Knight)},
        {"B",  typeof(Bishop)},
        {"K",  typeof(King)},
        {"Q",  typeof(Queen)}
    };
    
    public void Setup(Board board)
    {
        photonView = GetComponent<PhotonView>();

        // Create white pieces

        Debug.Log(DataManager.isPlayerWhite + " " + DataManager.isPlayerBlack);
        if (DataManager.isPlayerWhite && DataManager.isPlayerBlack)
        {
            mWhitePieces = CreatePieces(Color.white, new Color32(80, 124, 159, 255));
            mBlackPieces = CreatePieces(Color.black, new Color32(210, 95, 64, 255));
        }
        else
        {
            this.mPieceOrder[11] = "K";
            this.mPieceOrder[12] = "Q";

            mWhitePieces = CreatePieces(Color.white, new Color32(210, 95, 64, 255));
            mBlackPieces = CreatePieces(Color.black, new Color32(80, 124, 159, 255));
        }

        // Place pieces
        PlacePieces(1, 0, mWhitePieces, board);
        PlacePieces(6, 7, mBlackPieces, board);

        SetInteractive(mWhitePieces, false);
        SetInteractive(mBlackPieces, false);

        // White goes first
        if (DataManager.isPlayerWhite && DataManager.isPlayerBlack)
        {
            SwitchSides(Color.black);
        }
        else
        {
            SwitchSides(Color.white);
        }
    }

    private List<BasePiece> CreatePieces(Color teamColor, Color32 spriteColor)
    {
        List<BasePiece> newPieces = new List<BasePiece>();

        for (int i = 0; i < mPieceOrder.Length; i++)
        {
            // Get the type
            string key = mPieceOrder[i];
            Type pieceType = mPieceLibrary[key];

            // Create
            BasePiece newPiece = CreatePiece(pieceType);
            newPieces.Add(newPiece);

            // Setup
            newPiece.Setup(teamColor, spriteColor, this);
        }

        return newPieces;
    }

    private BasePiece CreatePiece(Type pieceType)
    {
        // Create new object
        GameObject newPieceObject = Instantiate(mPiecePrefab);
        newPieceObject.transform.SetParent(transform);

        // Set scale and position
        newPieceObject.transform.localScale = new Vector3(1, 1, 1);
        newPieceObject.transform.localRotation = Quaternion.identity;

        // Store new piece
        BasePiece newPiece = (BasePiece)newPieceObject.AddComponent(pieceType);

        return newPiece;
    }

    private void PlacePieces(int pawnRow, int royaltyRow, List<BasePiece> pieces, Board board)
    {
        for (int i = 0; i < 8; i++)
        {
            // Place pawns    
            pieces[i].Place(board.mAllCells[i, pawnRow]);

            // Place royalty
            pieces[i + 8].Place(board.mAllCells[i, royaltyRow]);
        }
    }

    private void SetInteractive(List<BasePiece> allPieces, bool value)
    {
        foreach (BasePiece piece in allPieces)
            piece.enabled = value;
    }
    

    private void MoveRandomPiece()
    {
        BasePiece finalPiece = null;
        while (!finalPiece)
        {
            // Get piece
            int i = UnityEngine.Random.Range(0, mBlackPieces.Count);
            BasePiece newPiece = mBlackPieces[i];
            // Does this piece have any moves?
            if (!newPiece.HasMove())
                continue;
            // Is piece active?
            if (newPiece.gameObject.activeInHierarchy)
                finalPiece = newPiece;
        }
        finalPiece.ComputerMove();
    }

    public static void EndMove(string movement, Board board)
    {
        int prev_x, prev_y = 0;
        int next_x, next_y = 0;
        
        prev_x = int.Parse(movement.Split()[0].Split('-')[0]);
        prev_y = int.Parse(movement.Split()[0].Split('-')[1]);
        next_x = int.Parse(movement.Split()[1].Split('-')[0]);
        next_y = int.Parse(movement.Split()[1].Split('-')[1]);


        board.mAllCells[prev_x, prev_y].mCurrentPiece.mTargetCell = board.mAllCells[next_x, next_y];
        board.mAllCells[prev_x, prev_y].mCurrentPiece.MoveEnemy();

        if (DataManager.isPlayerWhite && DataManager.isPlayerBlack)
        {
            board.mAllCells[next_x, next_y].mCurrentPiece.mPieceManager.SwitchSides(Color.black);
        }
        else
        {
            board.mAllCells[next_x, next_y].mCurrentPiece.mPieceManager.SwitchSides(Color.black);
        }
        
    }


    public void SwitchSides(Color color)
    {
        if (!mAreKingsAlive)
        {
            Debug.Log("GAME OVER");
        }

        bool isBlackTurn = color == Color.white ? true : false;

        if (DataManager.isPlayerWhite && DataManager.isPlayerBlack)
        {
            // Set team interactivity
            SetInteractive(mWhitePieces, !isBlackTurn);
        }
        else
        {
            // Disable this so player can't move pieces
            SetInteractive(mWhitePieces, !isBlackTurn);
        }

        // Set promoted interactivity
        foreach (BasePiece piece in mPromotedPieces)
        {
            bool isBlackPiece = piece.mColor != Color.white ? true : false;
            bool isPartOfTeam = isBlackPiece == true ? isBlackTurn : !isBlackTurn;

            piece.enabled = isPartOfTeam;
        }

        // Move random piece
        
        /* if (isBlackTurn)
            MoveRandomPiece(); */
        
    }

    public void ResetPieces()
    {
        foreach (BasePiece piece in mPromotedPieces)
        {
            piece.Kill();
            Destroy(piece.gameObject);
        }

        mPromotedPieces.Clear();

        foreach (BasePiece piece in mWhitePieces)
            piece.Reset();

        foreach (BasePiece piece in mBlackPieces)
            piece.Reset();
    }

    public void PromotePiece(Pawn pawn, Cell cell, Color teamColor, Color spriteColor)
    {
        // Kill Pawn
        pawn.Kill();

        // Create
        BasePiece promotedPiece = CreatePiece(typeof(Queen));
        promotedPiece.Setup(teamColor, spriteColor, this);

        // Place piece
        promotedPiece.Place(cell);

        // Add
        mPromotedPieces.Add(promotedPiece);
    }

    public int CheckCheck()
    {
        bool isWhiteUnder = false;
        bool isBlackUnder = false;

        foreach (BasePiece piece in mWhitePieces)
        {
            piece.CheckPathing(1);
            List<Cell> highlighted = piece.mHighlightedCells2;
            foreach (Cell newOne in highlighted)
            {
                if (newOne.mCurrentPiece != null && newOne.mCurrentPiece.GetType().Name == "King" && newOne.mCurrentPiece.mColor == Color.black)
                {
                    isWhiteUnder = true;
                    break;
                }
            }
            piece.mHighlightedCells2.Clear();
        }

        foreach (BasePiece piece in mBlackPieces)
        {
            piece.CheckPathing(1);
            List<Cell> highlighted = piece.mHighlightedCells2;
            foreach (Cell newOne in highlighted)
            {
                if (newOne.mCurrentPiece != null && newOne.mCurrentPiece.GetType().Name == "King" && newOne.mCurrentPiece.mColor == Color.white)
                {
                    isBlackUnder = true;
                    break;
                }
            }
            piece.mHighlightedCells2.Clear();
        }


        if (isBlackUnder && isWhiteUnder)
        {
            return 2;
        }

        if (isWhiteUnder)
        {
            return 1;
        }

        if (isBlackUnder)
        {
            return 0;
        }

        return -1;
    }
}