



public interface IGameEvent {

    void Raise();
    void RegisterListener(GameEventListener listener);
    void UnregisterListener(GameEventListener listener);

}

public interface IMonoEvent
{
    IGameEvent GetGameEvent
    { get; }
}

public class GameEventArgs<T> : System.EventArgs
{
    public T Origin { get; private set; }

    public GameEventArgs(T _orign)
    {
        Origin = _orign;
    }

}
