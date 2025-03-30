using UnityEngine;

public class VaciandoAgua : BS
{
    private GameObject currentWater;
    private float moveDuration = 2.5f;
    private float elapsedTime = 0f;
    public override void EnterState(SM ship)
    {
        currentWater = ship.water[ship.waterIndex];
        elapsedTime = 0f;
    }
    public override void UpdateState(SM ship)
    {
        if (elapsedTime < moveDuration)
        {
            currentWater.transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
            elapsedTime += Time.deltaTime;
        }
        else
        {
            ship.SwitchState(ship.AbriendoPuerta);
        }
    }
    public override void ExitState(SM ship)
    {
        elapsedTime = 0f;
        Debug.Log("Agua vaciada");
    }
}
