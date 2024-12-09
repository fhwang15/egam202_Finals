using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public List<CarController> BacktoInitialPosition;
    //public List<PedestrainController>

    public GamePhaseManager Current;

    public WinLoseCondition winLose;



    public void OnPressed()
    {

        if (winLose.win)
        {
            
        } 
        
        else if (!winLose.win)
        {
                 foreach (CarController objects in BacktoInitialPosition)
                 {
                     Current.currentPhase = GamePhase.SetUp;

                     objects.ResetPlayerPosition();
                     objects.reachedGoal = false;
            
                 }
        }



    }

}
