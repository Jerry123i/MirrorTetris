using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnerControler : MonoBehaviour
{
    public List<GameObject> shapes;
    public HolderScript holder;


    private GameObject storedPiece;
    public SpriteRenderer imageStored;
    public SpriteRenderer imageNext;

    [SerializeField]
    public SpriteEnumDictionary SEU;
        
    private void Awake()
    {

    }

    public GameObject Spawn()
    {
        GameObject piece;
        Vector3 position;

        int x = 6;
        int y = 19;

        position = new Vector3(holder.FindTileByCoordenate(x, y).transform.position.x, holder.FindTileByCoordenate(x, y).transform.position.y, 0.0f);

        piece = Instantiate(GetRandomSpecificPiece(), position, Quaternion.Euler(0, 0, 0));

        GameObject[] quadrados;

        quadrados = piece.GetComponent<ShapeControler>().squares;

        //Set tiles da nova forma
        switch (piece.GetComponent<ShapeControler>().type)
        {
            case ShapeType.I:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x-2, y));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x + 1, y));
                break;

            case ShapeType.J:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y+1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x + 1, y));
                break;

            case ShapeType.L:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x+1, y+1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x-1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x+1, y));
                break;

            case ShapeType.O:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y+1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x+1, y+1));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x+1, y));
                break;

            case ShapeType.S:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x-1, y+1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x-1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y-1));
                break;

            case ShapeType.T:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y+1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x-1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x+1, y));
                break;

            case ShapeType.Z:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y+1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x-1, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x-1, y-1));
                break;
        }

        return piece;

    }

    public GameObject Spawn(GameObject spawnPiece)
    {
        GameObject piece;
        Vector3 position;

        int x = 6;
        int y = 19;

        position = new Vector3(holder.FindTileByCoordenate(x, y).transform.position.x, holder.FindTileByCoordenate(x, y).transform.position.y, 0.0f);

        piece = Instantiate(spawnPiece, position, Quaternion.Euler(0, 0, 0));

        GameObject[] quadrados;

        quadrados = piece.GetComponent<ShapeControler>().squares;

        //Set tiles da nova forma
        switch (piece.GetComponent<ShapeControler>().type)
        {
            case ShapeType.I:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 2, y));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x + 1, y));
                break;

            case ShapeType.J:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y + 1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x + 1, y));
                break;

            case ShapeType.L:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x + 1, y + 1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x + 1, y));
                break;

            case ShapeType.O:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y + 1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x + 1, y + 1));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x + 1, y));
                break;

            case ShapeType.S:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y + 1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y - 1));
                break;

            case ShapeType.T:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y + 1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x + 1, y));
                break;

            case ShapeType.Z:
                quadrados[0].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y + 1));
                quadrados[1].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x, y));
                quadrados[2].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y));
                quadrados[3].GetComponent<QuadradoScript>().SetTile(holder.FindTileByCoordenate(x - 1, y - 1));
                break;
        }

        return piece;

    }

    public void StorePiece(GameMasterScript master , GameObject pieceToStore)
    {
        Debug.Log("Apagando um :" + pieceToStore.name);

        if(storedPiece == null)
        {
            storedPiece = FindPieceOnList(pieceToStore);
            pieceToStore.GetComponent<ShapeControler>().RemoveAllSquaresAndDie();
        }
        else{

            GameObject go;

            go = storedPiece;
            storedPiece = FindPieceOnList(pieceToStore);
            pieceToStore.GetComponent<ShapeControler>().RemoveAllSquaresAndDie();
            master.activeShape = Spawn(go).GetComponent<ShapeControler>();

            Debug.Log("Devolvendo um :" + go.name);
        }

        Debug.Log("No Store: " + storedPiece.GetComponent<ShapeControler>().type.ToString());

        imageStored.sprite = SEU.spritesDictionary[storedPiece.GetComponent<ShapeControler>().type];

    }

    private GameObject FindPieceOnList(GameObject reference)
    {
        GameObject returned;
        returned = new GameObject();

        shapes.ForEach(delegate (GameObject item)
        {
            if (item.GetComponent<ShapeControler>().type == reference.GetComponent<ShapeControler>().type)
            {
                returned = item;
            }
        });

        if(returned == null)
        {
            Debug.Log("FindPieceOnList error");
            Debug.Break();
        }

        return returned;
    }

    private GameObject GetRandomPiece()
    {
        return shapes[Random.Range(0, shapes.Count)];
    }

    private GameObject GetRandomSpecificPiece()
    {
        if(storedPiece == null)
        {
            return GetRandomPiece();
        }

        List<GameObject> list;
        list = new List<GameObject>();

        shapes.ForEach(delegate (GameObject item)
        {
            if (item.GetComponent<ShapeControler>().type != storedPiece.GetComponent<ShapeControler>().type)
            {
                list.Add(item);
            }
        });

        return shapes[Random.Range(0, list.Count)];
    }




}
