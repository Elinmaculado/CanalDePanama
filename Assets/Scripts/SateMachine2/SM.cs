using System.Collections.Generic;
using UnityEngine;

public class SM : MonoBehaviour
{
    BS currentState;
    // Estados
    public VaciandoAgua VaciandoAgua = new VaciandoAgua();
    public AbriendoPuerta AbriendoPuerta = new AbriendoPuerta();
    public Avanzando Avanzando = new Avanzando();
    public CerrandoPuerta CerrandoPuerta = new CerrandoPuerta();
    public LlenandoAgua LlenandoAgua = new LlenandoAgua();
    public StandBy StandBy = new StandBy();

    // Objetos
    public GameObject ship;
    public List<GameObject> water;
    public List<GameObject> poles;

    public int waterIndex = 0;
    public int poleIndex = 0;

    public bool atTop = false;

    private void Start()
    {
        currentState = VaciandoAgua;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BS state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    public void GetNextWater()
    {
        waterIndex++;
    }

    public void GetNextPole()
    {
        poleIndex++;
    }
}
