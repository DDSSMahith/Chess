using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;

    int matrixX;
    int matrixY;

    public bool attack = false;

    void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

    }
    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
            Destroy(cp);
        }

        controller.GetComponent<Game>().SetPositionEmpty(
            reference.GetComponent<RefScript>().GetXBoard(),
            reference.GetComponent<RefScript>().GetYBoard());

        reference.GetComponent<RefScript>().SetXBoard(matrixX);
        reference.GetComponent<RefScript>().SetYBoard(matrixY);
        reference.GetComponent<RefScript>().SetCoords();
        controller.GetComponent<Game>().SetPosition(reference);
        reference.GetComponent<RefScript>().DestroyMovePlates();

    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }
    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }

}
