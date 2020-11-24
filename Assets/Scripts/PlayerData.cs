using Unity.Entities;
using Unity.NetCode;

[GenerateAuthoringComponent]
public struct PlayerData : IComponentData
{
    [GhostField]//this makes sure that the ID is synced over the network
    public int PlayerId;
    public bool clientHasAuthority;//This is an optional helper variable that I added, we do not want to sync this one.
}