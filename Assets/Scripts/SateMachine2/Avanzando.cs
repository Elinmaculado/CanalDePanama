using UnityEngine;

public class Avanzando : BS
{
    private GameObject boat;
    private float moveDuration = 2.5f;
    private float elapsedTime = 0f;
    public override void EnterState(SM ship)
    {
        Debug.Log("Avanzando");
        boat = ship.ship;
    }
    public override void UpdateState(SM ship)
    {
        if(ship.poleIndex == 3)
        {
            if (elapsedTime < moveDuration)
            {
                boat.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                elapsedTime += Time.deltaTime;
            }
            else
            {
                ship.SwitchState(ship.StandBy);
            }
        }
        else if (elapsedTime < moveDuration)
        {
            boat.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
            elapsedTime += Time.deltaTime;
        }
        else
        {
            ship.SwitchState(ship.CerrandoPuerta);
        }
    }
    public override void ExitState(SM ship)
    {
        elapsedTime = 0f;
    }
}