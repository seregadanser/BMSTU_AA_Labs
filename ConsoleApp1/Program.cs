using ConsoleApp1;
using System.Runtime.CompilerServices;

string input = Console.ReadLine();
Queue<Ask> q = new Queue<Ask>();

foreach (char c in input)
    q.Enqueue(new Ask(4, c));
q.Enqueue(new Ask(3, '\0', true));
Console.WriteLine(q.Count);
Queue<Ask> exit = new Queue<Ask>();
Paral();
Console.WriteLine(exit.Count);

void Paral()
{
    Thread[] t = new Thread[3];
    Conver[] c = new Conver[3];
  
    c[0] = new Conver(new ConsoleApp1.Action(Crypto.CodeEncode),3, q, 0);
    c[1] = new Conver(new ConsoleApp1.Action(Crypto.Cipher), 4, 1);
    c[2] = new Conver(new ConsoleApp1.Action(Crypto.CodeEncode), 5, 2);

    c[0].nextState = c[1].queue;
    c[1].nextState = c[2].queue;
    c[2].nextState = exit;

    for (int i = 0; i < 3; i++)
    {
        t[i] = new Thread(c[i].Start);
        t[i].Start();
    }

    foreach (Thread thread in t)
    {
        thread.Join();
    }
}


class Ask
{
    public long[] in_time, out_time;
    public char elem;
    public bool last;
    public Ask(int n, char elem, bool last = false)
    {
        in_time = new long[n];
        out_time = new long[n];
        this.elem = elem;
        this.last = last;
    }
}

enum state { finish, empty, ok };
class Conver
{
    ConsoleApp1.Action a;
    int id;
    public Queue<Ask> nextState;
    public Queue<Ask> queue;
    int key;

    public Conver(ConsoleApp1.Action a, int key, int id)
    {
        this.a = a;
        queue = new Queue<Ask>();
        this.key = key;
        this.id = id;
    }
    public Conver(ConsoleApp1.Action a, int key, Queue<Ask> q, int id) : this(a, key, id)
    {
        queue = q;
    }

    public void Start()
    {
        state s = state.ok;
        while(s!=state.finish)
        {
            s = Process();
        }
    }

    public state Process()
    {
         Ask elem = null;
        bool e = false;
        lock (queue)
        {
            if (queue.Count > 0)
                e = queue.TryDequeue(out elem);
        }
        if (e && elem.last)
        {
            elem.in_time[id + 1] = DateTime.Now.Ticks;
            lock (nextState)
            { nextState.Enqueue(elem); }
            return state.finish; }
        if (e)
        {
            elem.elem = a.Invoke(elem.elem, key);
            lock (nextState)
            {
                elem.in_time[id + 1] = DateTime.Now.Ticks;
                nextState.Enqueue(elem);
            }
        }
       
        return state.ok;
    }

  
}