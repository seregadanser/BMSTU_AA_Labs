
Console.WriteLine("Hello, World!");




delegate char Action(char a, int key);

class Conver
{
    Action a;
    Conver nextState;
    Queue<char> queue;
    int key;
    public void Start()
    {

    }

    public void Process()
    {
        char elem = '\0';
        bool e = false;
        if (queue.Count > 0)
            e = queue.TryDequeue(out elem);

        if(e)
        {
            a.Invoke(elem, key);
            nextState.Add(elem);
        }

    }

    public void Add(char c)
    {
        queue.Enqueue(c);
    }
}