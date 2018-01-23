using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCounter : MonoBehaviour {

    public int points;
    public TextMeshProUGUI pointsDisplay;
    public TextMeshProUGUI endGamePointsDisplay;

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        UpdateDisplay();
    }

    public void ClearPoints()
    {
        points = 0;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        pointsDisplay.text = points.ToString();
    }

    public void EndGamePoints()
    {
        endGamePointsDisplay.text = points.ToString();
    }

}
