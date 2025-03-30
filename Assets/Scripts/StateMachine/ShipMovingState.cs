using UnityEngine;

public class ShipMovingState : BaseState
{
    private float moveDuration = 2.5f;
    private float currentTime = 0;

    // Agregamos override porque para el mismo método el comportamiento cambia en cada estado
    public override void EnterState(StateManager ship)
    {
        Debug.Log("El barco se está moviendo");
        currentTime = 0;
        //ship.transform.localScale = startSize;
    }

    public override void UpdateState(StateManager ship)
    {
        Debug.Log("update del estado Moving ship");
        if (currentTime < moveDuration)
        {
            currentTime += Time.deltaTime;
            ship.ship.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        }
        else
        {
            ship.SwitchState(ship.WaterMovingState);
        }
   
        //ship.ship.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

    }


    public override void ExitState(StateManager apple)
    {
        Debug.Log("Se salió del estado: " + this.GetType().Name);
    }
    public override void OnCollisionEnter(StateManager apple)
    {
        //Este estado no usa onCollisionEnter
    }

}
