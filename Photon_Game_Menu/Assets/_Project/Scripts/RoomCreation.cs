using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreation : MonoBehaviour
{
    
}

public struct GameRoomInfo
{
    public readonly string roomName;
    public readonly int roomCapacity;
    public readonly string roomRegion;
    public readonly bool isPrivate;
    public readonly string password;

    public GameRoomInfo(string newRoomName, int roomCapacity, string region, bool isPrivate, string password = "")
    {
        this.roomName = newRoomName;
        this.roomCapacity = roomCapacity;
        this.roomRegion = region;
        this.isPrivate = isPrivate;
        this.password = password;
    }
}