using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public int userID;
    public int userPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int pointsAdded)
    {
        userPoints = (userPoints + pointsAdded);
    }

    public void SubPoints(int pointsSubtracted)
    {
        userPoints = (userPoints - pointsSubtracted);
    }
}
