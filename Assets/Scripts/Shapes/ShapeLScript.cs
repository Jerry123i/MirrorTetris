using UnityEngine;
using System.Collections;

public class ShapeLScript : ShapeControler
{
    void Start()
    {
        type = ShapeType.L;
    }

    public override void Rotate(int direction)
    {
        base.Rotate(direction);

        rotationState += direction;

        if (rotationState == 4)
        {
            rotationState = 0;
        }
        if (rotationState == -1)
        {
            rotationState = 3;
        }

        switch (rotationState)
        {
            case 0:

                if (direction > 0)
                {
                    squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(2, 0);
                    squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(-1, 1);
                    squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                    squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(1, -1);
                    break;
                }
                else
                {
                    squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(0, 2);
                    squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(-1, -1);
                    squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                    squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(1, 1);
                    break;
                }

            case 1:

                if (direction > 0)
                {
                    squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(0, -2);
                    squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(1, 1);
                    squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                    squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(-1, -1);
                    break;
                }
                else
                {
                    squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(2, 0);
                    squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(-1, 1);
                    squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                    squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(1, -1);
                    break;
                }

            case 2:

                if (direction > 0)
                {
                    squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(-2, 0);
                    squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(1, -1);
                    squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                    squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(-1, 1);
                    break;
                }
                else
                {
                    squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(0, -2);
                    squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(1, 1);
                    squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                    squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(-1, -1);
                    break;
                }

            case 3:

                if (direction > 0)
                {
                    squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(0, 2);
                    squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(-1, -1);
                    squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                    squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(1, 1);
                    break;
                }
                else
                {
                    squares[0].GetComponent<QuadradoScript>().MoveByCoordinates(-2, 0);
                    squares[1].GetComponent<QuadradoScript>().MoveByCoordinates(1, -1);
                    squares[2].GetComponent<QuadradoScript>().MoveByCoordinates(0, 0);
                    squares[3].GetComponent<QuadradoScript>().MoveByCoordinates(-1, 1);
                    break;
                }

        }

    }
}
