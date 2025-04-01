using UnityEditor;
using UnityEngine;

public class LlenandoAgua : BS
{
    private GameObject currentWater;
    private GameObject boat;
    private float moveDuration = 2.5f;
    private float elapsedTime = 0f;
    public override void EnterState(SM ship)
    {
        Debug.Log("Llenando");
        currentWater = ship.water[ship.waterIndex];
        boat = ship.ship;
        elapsedTime = 0f;
        if (ship.waterIndex == 1)
        {
            ship.atTop = true;
        }
    }
    public override void UpdateState(SM ship)
    {
        if (ship.atTop)
        {
            ship.SwitchState(ship.AbriendoPuerta);
        }
        if (elapsedTime < moveDuration)
        {
            boat.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
            currentWater.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
            elapsedTime += Time.deltaTime;
        }
        else
        {
            ship.SwitchState(ship.VaciandoAgua);
        }
    }
    public override void ExitState(SM ship)
    {
        elapsedTime = 0f;
        ship.GetNextWater();
    }
}
