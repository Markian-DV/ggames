using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image mOutlineImage;

    [HideInInspector]
    public Vector2Int mBoardPosition = Vector2Int.zero;
    [HideInInspector]
    public Board mBoard = null;
    [HideInInspector]
    public RectTransform mRectTransform = null;

    [HideInInspector]
    public BasePiece mCurrentPiece = null;
    public BasePiece mPreviousPiece = null;

    [HideInInspector]
    public bool isAttack = false;

    public void Setup(Vector2Int newBoardPosition, Board newBoard)
    {
        mBoardPosition = newBoardPosition;
        mBoard = newBoard;

        mRectTransform = GetComponent<RectTransform>();
    }

    public void RemovePiece(int t=0)
    {
        if (t == 0)
        {
            if (mCurrentPiece != null)
            {
                mPreviousPiece = null;
                mCurrentPiece.Kill();
            }
        }
        else
        {
            if (mCurrentPiece != null)
            {
                mCurrentPiece.Delete();
            }
        }
    }

    public void SetAttack()
    {
        isAttack = true;
    }

    public void reSetAttack()
    {
        isAttack = false;
    }
}
