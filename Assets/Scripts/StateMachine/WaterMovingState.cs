using UnityEditor;
using UnityEngine;

public class WaterMovingState : BaseState
{
    private float moveDuration = 2.5f;
    private float elapsedTime = 0f;
    private GameObject currentWater;
    private GameObject currentPole;
    private GameObject boat; 
    private bool isMovingPole = false; // Para saber si estamos moviendo el poste
    private bool isGoingUp = false;
    private bool movingBoat = false;

    public override void EnterState(StateManager ship)
    {
        Debug.Log("Moviendo agua...");
        elapsedTime = 0f;
        isMovingPole = false;
        isGoingUp = false;
        currentWater = ship.GetNextWater(); // Obtener el siguiente agua
        currentPole = ship.GetNextPole(); // Obtener el siguiente poste
        boat = ship.ship;
    }

    public override void UpdateState(StateManager ship)
    {
        if (currentWater == null && currentPole == null)
        {
            ship.SwitchState(ship.ShipMovingState); // Si no hay más agua ni postes, regresa al barco
            return;
        }
        //Agua abajo
        if (!isMovingPole && !isGoingUp) // Mover el agua primero
        {
            if (currentWater != null && elapsedTime < moveDuration)
            {
                currentWater.transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
                elapsedTime += Time.deltaTime;
            }
            else
            {
                Debug.Log("Agua movida, ahora el poste...");
                isMovingPole = true; // Ahora moveremos el poste
                elapsedTime = 0f; // Reiniciamos el tiempo para el poste
            }
        }
        // Poste abajo
        else if(isMovingPole && !isGoingUp) // Mover el poste después del agua
        {
            if (currentPole != null && elapsedTime < moveDuration)
            {
                currentPole.transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
                elapsedTime += Time.deltaTime;
            }
            else
            {
                Debug.Log("Poste movido, volviendo al barco...");
                isGoingUp = true;
                elapsedTime = 0f; // Reiniciamos el tiempo para el agua
                movingBoat = true;
                //ship.SwitchState(ship.ShipMovingState); // Después del poste, vuelve a mover el barco
            }
        }
        if (movingBoat)
        {
            if (boat != null && elapsedTime < moveDuration)
            {
                boat.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                elapsedTime += Time.deltaTime;
            }
            else
            {
                Debug.Log("Barco movido, ahora el agua...");
                movingBoat = false;
                elapsedTime = 0f; // Reiniciamos el tiempo para el agua
            }
        }
        // Poste arriba
        else if(isMovingPole && isGoingUp) // Mover el poste después del agua
        {
            if (currentPole != null && elapsedTime < moveDuration)
            {
                currentPole.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
                elapsedTime += Time.deltaTime;
            }
            else
            {
                Debug.Log("Poste movido, volviendo al barco...");
                isMovingPole = false;
                elapsedTime = 0f;
            }
        }
        else if(!isMovingPole && isGoingUp) // Mover el agua después del poste
        {
            if (currentWater != null && elapsedTime < moveDuration)
            {
                currentWater.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
                boat.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
                elapsedTime += Time.deltaTime;
            }
            else
            {
                Debug.Log("Agua movida, ahora el poste...");
                isGoingUp = false;
                elapsedTime = 0f; // Reiniciamos el tiempo para el poste
                ship.SwitchState(ship.ShipMovingState); // Después del poste, vuelve a mover el barco
            }
        }
    }

    public override void ExitState(StateManager ship)
    {
        Debug.Log("Se terminó de mover el agua y el poste");
    }
}
