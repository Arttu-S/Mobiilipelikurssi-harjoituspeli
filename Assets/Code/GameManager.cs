using Unity.VisualScripting;
using UnityEngine;

namespace Harjoituspeli
{

public class GameManager : MonoBehaviour
{
    private int playerPoints = 0;

    // Metodi lisää pisteitä pelaajalle
    public void AddPoints(int points)
    {
        playerPoints += points;
        Debug.Log("Pisteet lisätty: " + points);
        Debug.Log("Uudet pisteet: " + playerPoints);
    }

    // Metodi palauttaa pelaajan pisteet
    public int GetPoints()
    {
        return playerPoints;
    }

    // Voit lisätä muita toiminnallisuuksia tarpeen mukaan
}
}