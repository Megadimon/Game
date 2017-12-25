using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum PlayerEnum
//{
//    First,
//    Second
//}

public class ControllerPlayr : MonoBehaviour {
    //public static ControllerPlayr Instance { get; private set; }

    //public PlayerEnum ActivePlayer { get; private set; }

    GameObject bullet;
    public List<GameObject> Players;
    public int ActivePlayerIndex = 0;


    // Update is called once per frame
    void Update() {
        var move = Players[ActivePlayerIndex].GetComponent<HeroMove>();
        var shot = Players[ActivePlayerIndex].GetComponent<Shot>();
        
        if (bullet != null)
        {
            bullet.GetComponent<Shape>().Move();
            if (bullet.GetComponent<Shape>().lifeTime <= 0)
            {
                Destroy(bullet);
                bullet = null;
            }
        }
        foreach (var pla in Players)
            if (pla == null)
            {
                Players.Remove(pla);
                shot.AlreadyShot = false;
                ActivePlayerIndex = (ActivePlayerIndex + 1) % Players.Count;
            }
        if(bullet == null && shot.AlreadyShot)
        {
            shot.AlreadyShot = false;
            ActivePlayerIndex = (ActivePlayerIndex + 1) % Players.Count;
            Players[ActivePlayerIndex].GetComponent<HeroMove>().power = 2;
        }

        move.Move();
        move.Ratation();
        
        if(!shot.AlreadyShot)
            bullet = shot.MakeShot();
    }

    public void Destr(int index)
    {
        Players.Remove(Players[index]);
    }

    //public void SwitchPlayer()
    //{
    //    ActivePlayer = ActivePlayer == PlayerEnum.First ? PlayerEnum.Second : PlayerEnum.First;
    //}
}
