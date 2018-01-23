using UnityEngine;
using System.Collections;

public class ShapeIScript : ShapeControler
{
    void Start()
    {
        type = ShapeType.I;
    }

    public override void Rotate(int direction)
    {
        base.Rotate(direction);

        rotationState += direction;

        if (rotationState == 2)
        {
            rotationState = 0;
        }
        if (rotationState == -1)
        {
            rotationState = 1;
        }

        switch (rotationState)
        {
            case 1:
                squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(2, -2);
                squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(1, -1);
                squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(-1, 1);
                break;

            case 0:
                squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(-2, 2);
                squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(-1, 1);
                squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(1, -1);
                break;

        }

    }
}
