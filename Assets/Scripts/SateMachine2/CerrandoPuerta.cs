using UnityEngine;

public class CerrandoPuerta : BS
{
    private GameObject currentPole;
    private float moveDuration = 2.5f;
    private float elapsedTime = 0f;
    public override void EnterState(SM ship)
    {
        currentPole = ship.poles[ship.poleIndex];
        elapsedTime = 0f;
    }
    public override void UpdateState(SM ship)
    {
        if (elapsedTime < moveDuration)
        {
            currentPole.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
            elapsedTime += Time.deltaTime;
        }
        else
        {
            ship.SwitchState(ship.LlenandoAgua);
        }
    }
    public override void ExitState(SM ship)
    {
        elapsedTime = 0f;
        ship.GetNextPole();
        Debug.Log("Puerta Abierta");
    }
}
