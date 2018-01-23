using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolderScript : MonoBehaviour {

    public List<TetrisTileScript> allTiles;

    private void OnLevelWasLoaded(int level)
    {
        ClearAllTiles();
    }

    public TetrisTileScript FindTileByCoordenate(int x, int y)
    {

        for (int i =0; i<allTiles.Count; i++)
        {
            if(allTiles[i].GetComponent<TetrisTileScript>().x == x && allTiles[i].GetComponent<TetrisTileScript>().y == y)
            {
                return allTiles[i];
            }
        }

        return null;
    }

    public void ClearAllTiles()
    {
        allTiles.ForEach(delegate (TetrisTileScript tile)
        {
            tile.ClearTile();
        });
    }

}
