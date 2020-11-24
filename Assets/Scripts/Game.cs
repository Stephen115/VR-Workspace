using Unity.Entities;
using Unity.NetCode;
using Unity.Networking.Transport;
using UnityEngine;

[UpdateInWorld(UpdateInWorld.TargetWorld.Default)]
public class Game : SystemBase
{
    // Singleton component to trigger connections once from a control system
    struct InitGameComponent : IComponentData
    {
    }
    protected override void OnCreate()
    {
        RequireSingletonForUpdate<InitGameComponent>();
        // Create singleton, require singleton for update so system runs once
        EntityManager.CreateEntity(typeof(InitGameComponent));
    }

    protected override void OnUpdate()
    {
        // Destroy singleton to prevent system from running again
        EntityManager.DestroyEntity(GetSingletonEntity<InitGameComponent>());
        foreach (var world in World.All)
        {
            var network = world.GetExistingSystem<NetworkStreamReceiveSystem>();
            if (world.GetExistingSystem<ClientSimulationSystemGroup>() != null)
            {
                Debug.Log("Client trying to connect to: " + "Your IP here");
                NetworkEndPoint.TryParse("Your IP here", 7979, out NetworkEndPoint ep);
                network.Connect(ep);
            }
            else if (world.GetExistingSystem<ServerSimulationSystemGroup>() != null)
            {
                // Server world automatically listens for connections from any host
                Debug.Log("Server listening for connections");
                NetworkEndPoint ep = NetworkEndPoint.AnyIpv4;
                ep.Port = 7979;
                network.Listen(ep);
            }
        }
    }
}

// When client has a connection with network id, go in game and tell server to also go in game
[UpdateInGroup(typeof(ClientSimulationSystemGroup))]
public class GoInGameClientSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityManager entityManager = EntityManager;
        Entities.WithStructuralChanges().WithNone<NetworkStreamInGame>().ForEach((Entity ent, ref NetworkIdComponent id) =>
        {
            entityManager.AddComponent<NetworkStreamInGame>(ent);
            var req = entityManager.CreateEntity();
            entityManager.AddComponent<GoInGameRequest>(req);
            entityManager.AddComponent<GoInGameRequest2>(req);
            entityManager.AddComponent<SendRpcCommandRequestComponent>(req);
            entityManager.SetComponentData(req, new SendRpcCommandRequestComponent { TargetConnection = ent });
        }).Run();
    }
}

//The boilerplate for the RPC
[BurstCompile]
public struct GoInGameRequest : IRpcCommand
{
    public void Deserialize(ref DataStreamReader reader)
    {
    }

    public void Serialize(ref DataStreamWriter writer)
    {
    }
    [BurstCompile]
    private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
    {
        RpcExecutor.ExecuteCreateRequestComponent<GoInGameRequest>(ref parameters);
    }

    static PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);
    public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
    {
        return InvokeExecuteFunctionPointer;
    }
}

//The boilerplate for the RPC
[BurstCompile]
public struct GoInGameRequest2 : IRpcCommand
{
    public void Deserialize(ref DataStreamReader reader)
    {
    }

    public void Serialize(ref DataStreamWriter writer)
    {
    }
}

// The system that makes the RPC request component transfer, this just needs to exist or nothing will happen
public class GoInGameRequestSystem : RpcCommandRequestSystem<GoInGameRequest, GoInGameRequest2>
{
}

// When server receives go in game request, go in game and delete request
[UpdateInGroup(typeof(ServerSimulationSystemGroup))]
public class GoInGameServerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityManager entityManager = EntityManager;
        Entities.WithStructuralChanges().WithNone<SendRpcCommandRequestComponent>().ForEach((Entity reqEnt, ref GoInGameRequest req, ref GoInGameRequest2 req, ref ReceiveRpcCommandRequestComponent reqSrc) =>
        {
            entityManager.AddComponent<NetworkStreamInGame>(reqSrc.SourceConnection);
            UnityEngine.Debug.Log(System.String.Format("Server setting connection {0} to in game", EntityManager.GetComponentData<NetworkIdComponent>(reqSrc.SourceConnection).Value));
            var ghostCollection = GetSingleton<GhostPrefabCollectionComponent>();

            var ghostId = PlayersGhostSerializerCollection.FindGhostType<PilotSnapshotData>();//this is where the names we chose in the ghost collection and ghost authoring component scripts come into play
            var prefab = EntityManager.GetBuffer<GhostPrefabBuffer>(ghostCollection.serverPrefabs)[ghostId].Value;
            var player = entityManager.Instantiate(prefab);
            entityManager.SetComponentData(player, new PilotData { PlayerId = EntityManager.GetComponentData<NetworkIdComponent>(reqSrc.SourceConnection).Value });
            entityManager.AddBuffer<PilotInput>(player);//we will code this later in the tutorial so ether comment out or ignore for now

            entityManager.SetComponentData(reqSrc.SourceConnection, new CommandTargetComponent { targetEntity = player });

            entityManager.DestroyEntity(reqEnt);
            Debug.Log("Spawend Player");
        }).Run();
    }
}