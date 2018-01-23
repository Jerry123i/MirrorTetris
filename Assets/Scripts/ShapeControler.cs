using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public enum ShapeType {I, J, L, O, S, T, Z }

public class ShapeControler : MonoBehaviour
{
    public Sprite blueprintSprite;
    public Sprite solidSprite;

    public HolderScript holderScript;
    public GameObject[] squares;
    public ShapeType type;

    protected int rotationState;
    public bool endReached;

    ShapeAudioControler shapeAudioControler;

    private void Awake()
    {
        endReached = false;

        holderScript = FindObjectOfType<HolderScript>();
        shapeAudioControler = this.GetComponent<ShapeAudioControler>();

        for (int i = 0; i<squares.Length; i++)
        {
            squares[i].GetComponent<QuadradoScript>().shape = this;

            if(FindGameState() == GameState.BUILDING)
            {
                squares[i].GetComponent<SpriteRenderer>().sprite = solidSprite;
            }
            else
            {
                squares[i].GetComponent<SpriteRenderer>().sprite = blueprintSprite;
            }

        }

    }

    private void Update()
    {
        
    }

    public void MovePiece(int x, int y)
    {
        bool safetyLock = false;

        for (int i = 0; i < squares.Length; i++)
        {
            QuadradoScript quadrado;
            quadrado = squares[i].GetComponent<QuadradoScript>();

            if (quadrado.FindCoordinates(x, y) != null)
            {
                if (quadrado.FindCoordinates(x, y).thing != null && quadrado.FindCoordinates(x, y).thing.GetComponent<QuadradoScript>().shape != this)
                {
                    safetyLock = true;
                }
            }
            else
            {
                safetyLock = true;               
                
            }

        }

        if (!safetyLock)
        {
            for (int i = 0; i < squares.Length; i++)
            {
                QuadradoScript quadrado;
                quadrado = squares[i].GetComponent<QuadradoScript>();

                quadrado.MoveByCoordinates(x, y);
            }
        }
        
        if(safetyLock && y == -1)
        {
            if (FindGameState() == GameState.DRAWING)
            {
                shapeAudioControler.PlayHitGroundDrawing();
            }
            else
            {
                shapeAudioControler.PlayHitGroundSolid();
            }
            
            endReached = true;
            enabled = false;            
        }
    }

    public virtual void Rotate(int direction)
    {

    }

    public void RemoveAllSquaresAndDie()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            QuadradoScript quadrado;
            quadrado = squares[i].GetComponent<QuadradoScript>();

            quadrado.tile.ClearTile();
        }

        Destroy(this.gameObject);
    }

    GameState FindGameState()
    {
        return FindObjectOfType<GameMasterScript>().gameState;
    }
    
}
