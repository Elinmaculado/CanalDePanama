using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    BaseState currentState;
    public GameObject ship;
    public List<GameObject> water;
    public List<GameObject> poles;

    private int waterIndex = 0;
    private int poleIndex = 0;

    public ShipMovingState ShipMovingState = new ShipMovingState();
    public WaterMovingState WaterMovingState = new WaterMovingState();
    public Allup Allup = new Allup();

    private void Start()
    {
        currentState = ShipMovingState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    public GameObject GetNextWater()
    {
        if (waterIndex < water.Count)
        {
            return water[waterIndex++];
        }
        return null; // Si no hay m�s agua, devuelve null
    }

    public GameObject GetNextPole()
    {
        if (poleIndex < poles.Count)
        {
            return poles[poleIndex++];
        }
        return null;
    }
}
