using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public enum GameState {DRAWING, BUILDING, PAUSED }

public class GameMasterScript : MonoBehaviour
{

    public int numberOfDrawingPieces;
    public int numberOfBuildingPieces;
    public int wave;

    public PointsCounter pointsCounter;

    public GameObject endGameObject;

    public GameState gameState;

    public SpawnerControler spawnerControler;
    public HolderScript holderScript;

    public float buildingSpeed;
    public float drawingSpeed;

    private float fallSpeed;
    public ShapeControler activeShape;

    IEnumerator routineGravity;
    IEnumerator routineSpawn;

    public int pieceCounter;

    public virtual void Start()
    {
        Debug.Log("Start");
        drawingSpeed = buildingSpeed * 1.75f;
        routineGravity = Gravity();
        StartCoroutine(DelayBetwenStates(GameState.DRAWING));
    }
    
    private void Update()
    {
        Controlls();                
    }

    protected IEnumerator DelayBetwenStates(GameState stateToGo)
    {
        Debug.Log("Wave:" + wave.ToString());
        yield return new WaitForSeconds(2.0f);
        
        switch (stateToGo)
        {
            case GameState.BUILDING:
                GoToBuilding();
                break;

            case GameState.DRAWING:
                GoToDrawing();
                break;

            case GameState.PAUSED:
                Debug.Log("Endgame");
                FinishGame();
                break;                
        }

    }

    IEnumerator PieceSpawn()
    {
        StopCoroutine(routineGravity);
        activeShape = spawnerControler.Spawn().GetComponent<ShapeControler>();
        StartCoroutine(routineGravity);
        yield return new WaitUntil(IsShapeEnded);

        activeShape = null;
        StopCoroutine(routineGravity);
        pieceCounter++;

        if(pieceCounter == numberOfDrawingPieces && gameState == GameState.DRAWING)
        {            
            pieceCounter = 0;
            FinishDrawing();
            StopCoroutine(routineSpawn);
        }
        else if (pieceCounter == numberOfBuildingPieces && gameState == GameState.BUILDING)
        {
            pieceCounter = 0;
            FinishBuilding();
            StopCoroutine(routineSpawn);
        }
        else
        {
            routineSpawn = PieceSpawn();
            StartCoroutine(routineSpawn);
        }
        
    }

    IEnumerator Gravity()
    {
        yield return new WaitForSeconds(1 / fallSpeed);

        if(activeShape != null)
        {
            activeShape.MovePiece(0, -1);
            routineGravity = Gravity();
            StartCoroutine(routineGravity);

        }
        else
        {
            StopCoroutine(routineGravity);
        }
        
    }

    void FinishGame()
    {
        holderScript.ClearAllTiles();
        pointsCounter.EndGamePoints();
        pointsCounter.pointsDisplay.gameObject.SetActive(false);

        Analytics.CustomEvent("GameOver", new Dictionary<string, object>
        {
            { "score", pointsCounter.points }
        });

        endGameObject.SetActive(true);
    }

    void FinishBuilding()
    {
        gameState = GameState.PAUSED;

        List<TetrisTileScript> markedForClearing;
        markedForClearing = new List<TetrisTileScript>();

        holderScript.allTiles.ForEach(delegate (TetrisTileScript tile)
        {
            if (tile.isOnTheBlueprint)
            {
                markedForClearing.Add(tile);
            }

            else if (tile.thing != null)
            {
                markedForClearing.Add(tile);
            }

        });

       
        StartCoroutine(FinishBuildingEnumerator(markedForClearing, 0));

    }

    protected virtual IEnumerator FinishBuildingEnumerator(List<TetrisTileScript> list, int i)
    {
        float waitTime;

        waitTime = 0.2f;

        if (list[i].isOnTheBlueprint)
        {
            if (list[i].thing != null)
            {
                pointsCounter.AddPoints(50);
                list[i].tileAudio.PlayPoints();
            }

            else
            {
                list[i].tileAudio.PlayEmpty();
            }

            list[i].ClearTile();
        }

        else if (list[i].thing != null)
        {
            pointsCounter.AddPoints(-35);
            list[i].thing.GetComponent<SpriteRenderer>().color = Color.white;
            list[i].tileAudio.PlayBad();
        }
                
        yield return new WaitForSeconds(waitTime);
        
        i++;
        if(i< list.Count)
        {
            StartCoroutine(FinishBuildingEnumerator(list, i));
        }
        else
        {
            wave++;
            UpdateSpeed();

            if(wave >= 3)
            {
                StartCoroutine(DelayBetwenStates(GameState.PAUSED));
            }
            else
            {
                StartCoroutine(DelayBetwenStates(GameState.DRAWING));
            }
        }
    }

    void UpdateSpeed()
    {
        buildingSpeed *= 1.35f;
    }
     
    void FinishDrawing()
    {
        gameState = GameState.PAUSED;

        holderScript.allTiles.ForEach(delegate (TetrisTileScript tile)
        {
            tile.ReadyBlueprint();
        });

        StartCoroutine(DelayBetwenStates(GameState.BUILDING));

    }

    void Controlls()
    {
        if(activeShape != null)
        {
            if (Input.GetKey("s"))
            {
                activeShape.MovePiece(0, -1);
            }
            if (Input.GetKeyDown("a"))
            {
                activeShape.MovePiece(-1, 0);
            }
            if (Input.GetKeyDown("d"))
            {
                activeShape.MovePiece(1, 0);
            }

            if (Input.GetKeyDown("e"))
            {
                activeShape.Rotate(1);
            }
            if (Input.GetKeyDown("q"))
            {
                activeShape.Rotate(-1);
            }
            StorePieceControls();
        }
    }

    void StorePieceControls()
    {
        if (Input.GetKeyDown("w"))
        {
            spawnerControler.StorePiece(this, activeShape.gameObject);
        }

    }

    void GoToDrawing()
    {
        gameState = GameState.DRAWING;
        fallSpeed = drawingSpeed;
        routineSpawn = PieceSpawn();
        StartCoroutine(routineSpawn);
    }

    void GoToBuilding()
    {
        gameState = GameState.BUILDING;
        fallSpeed = buildingSpeed;
        routineSpawn = PieceSpawn();
        StartCoroutine(routineSpawn);
    }

    public bool IsShapeEnded()
    {
        if (activeShape != null)
        {
            return activeShape.endReached;
        }
        else
        {
            return true;
        }
        
    }

}
