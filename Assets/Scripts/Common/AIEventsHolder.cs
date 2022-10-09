using System;

public static class AIEventsHolder
{
    public static event Action<AIAgent> GameEnded;

    public static void SendGameEnded(AIAgent agent)
    {
        GameEnded?.Invoke(agent);
    }
}
