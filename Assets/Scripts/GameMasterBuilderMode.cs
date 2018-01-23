using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMasterBuilderMode : GameMasterScript
{
    public BuilderScheme scheme;

    public override void Start()
    {
        base.Start();
        StopAllCoroutines();
        StartCoroutine(DelayBetwenStates(GameState.BUILDING));
        ReadyBuilderScheme();
        numberOfBuildingPieces = scheme.maxPieces;
    }

    void ReadyBuilderScheme()
    {
        
        for (int j = scheme.y - 1; j >= 0; j--)
        {

            for (int i = 0; i < scheme.x; i++)
            {
                if (scheme.blueprint[i, j])
                {
                    holderScript.FindTileByCoordenate(i, j).MakeBlueprint();
                }
            }

        }
    }

    protected override IEnumerator FinishBuildingEnumerator(List<TetrisTileScript> list, int i)
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
        if (i < list.Count)
        {
            StartCoroutine(FinishBuildingEnumerator(list, i));
        }
        else
        {
            StartCoroutine(DelayBetwenStates(GameState.PAUSED));
        }
    }
}
