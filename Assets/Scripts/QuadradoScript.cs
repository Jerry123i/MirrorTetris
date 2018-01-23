using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadradoScript : MonoBehaviour {

    public TetrisTileScript tile;
    public ShapeControler shape;

    public void MoveToTile(TetrisTileScript tileToMove)
    {
        GameObject go;
        go = tileToMove.gameObject;

        this.gameObject.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0.0f);
        SetTile(tileToMove);
    }

    public void MoveByCoordinates(int x, int y)
    {
        int currentX;
        int currentY;
        currentX = this.tile.x;
        currentY = this.tile.y;

        //Safety locks boundaries
        if(currentX + x <0)
        {
            shape.MovePiece(1,0);
        }
        else if (currentX + x > 13)
        {
            shape.MovePiece(-1,0);
        }
        
        if(currentY + y < 0)
        {
            shape.MovePiece(0,1);
        }
        else if(currentY + y > 20)
        {
            shape.MovePiece(0,-1);
        }

        //Safety lock pieces
        if(FindCoordinates(x,y).thing != null && FindCoordinates(x,y).thing.GetComponent<QuadradoScript>().shape != shape)
        {
            shape.MovePiece(-x,-y);
        }

        //Movement
        MoveToTile(FindCoordinates(x, y));
    }

    public TetrisTileScript FindCoordinates(int x, int y)
    {
        TetrisTileScript target;
        HolderScript holder;

        int currentX;
        int currentY;

        currentX = this.tile.x;
        currentY = this.tile.y;

        holder = FindObjectOfType<HolderScript>();

        target = holder.FindTileByCoordenate(currentX+x, currentY+y);

        return target;
    }

    public void SetTile(TetrisTileScript t)
    {
        StartCoroutine(EnumSetTile(t));
    }

    public IEnumerator EnumSetTile(TetrisTileScript tileToSet)
    {
        if (tile != null)
        {
            if(tile.thing != null)
            {
                tile.thing = null;
            }

            tile.full = false;
        }
        tile = tileToSet;
        yield return new WaitForEndOfFrame();             
        tile.full = true;
        tile.thing = this.gameObject;
    }
}
