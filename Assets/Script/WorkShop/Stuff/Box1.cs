using UnityEngine;

public class Box1 : Stuff,IInteractable
{
    public bool isInteractable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Interact(Player player)
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
}
