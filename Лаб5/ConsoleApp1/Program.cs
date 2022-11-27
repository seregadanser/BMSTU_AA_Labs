using ConsoleApp1;
using System.Runtime.CompilerServices;

string input = Console.ReadLine();
Queue<Ask> q;
Ask b;
Queue<Ask> exit;



//q = new Queue<Ask>();
//foreach (char c in input)
//{
//    Ask a = new Ask(4, c);
//    a.in_time[0] = DateTime.Now.Ticks;
//    a.state[0] = c;
//    q.Enqueue(a);
//}
//b = new Ask(4, '\0', true);
//b.in_time[0] = DateTime.Now.Ticks;
//b.state[0] = '\0';
//q.Enqueue(b);
//Console.WriteLine(q.Count);
//exit = new Queue<Ask>();
//SerialCode();
//Formatter.FormatOut(exit);

q = new Queue<Ask>();
foreach (char c in input)
{
    Ask a = new Ask(4, c);
    a.in_time[0] = DateTime.Now.Ticks;
    a.state[0] = c;
    q.Enqueue(a);
}
b = new Ask(4, '\0', true);
b.in_time[0] = DateTime.Now.Ticks;
b.state[0] = '\0';
q.Enqueue(b);
Console.WriteLine(q.Count);
exit = new Queue<Ask>();
ParalCode();
Formatter.FormatOut(exit);

q = new Queue<Ask>();
foreach (char c in input)
{
    Ask a = new Ask(4, c);
    a.in_time[0] = DateTime.Now.Ticks;
    a.state[0] = c;
    q.Enqueue(a);
}
b = new Ask(4, '\0', true);
b.in_time[0] = DateTime.Now.Ticks;
b.state[0] = '\0';
q.Enqueue(b);
Console.WriteLine(q.Count);
exit = new Queue<Ask>();
SerialCode();
Formatter.FormatOut(exit);



//string s = "";
//while (exit.Count > 0)
//    s += exit.Dequeue().elem;

//ParalDeCode();
//while (q.Count > 0)
//    s += q.Dequeue().elem;
//Console.WriteLine(s);

void ParalCode()
{
    Thread[] t = new Thread[3];
    Conver[] c = new Conver[3];
  
    c[0] = new Conver(new ConsoleApp1.Action(Crypto.aaa),300, q, 0);
    c[1] = new Conver(new ConsoleApp1.Action(Crypto.aaa), 400, 1);
    c[2] = new Conver(new ConsoleApp1.Action(Crypto.aaa), 500, 2);

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
void SerialCode()
{
    Conver[] c = new Conver[3];

    c[0] = new Conver(new ConsoleApp1.Action(Crypto.aaa), 300, q, 0);
    c[1] = new Conver(new ConsoleApp1.Action(Crypto.aaa), 400, 1);
    c[2] = new Conver(new ConsoleApp1.Action(Crypto.aaa), 500, 2);

    c[0].nextState = c[1].queue;
    c[1].nextState = c[2].queue;
    c[2].nextState = exit;

    c[0].Start();
    c[1].Start();
    c[2].Start();

}
void ParalDeCode()
{
    Thread[] t = new Thread[3];
    Conver[] c = new Conver[3];

    c[0] = new Conver(new ConsoleApp1.Action(Crypto.CodeEncode), -3, exit, 0);
    c[1] = new Conver(new ConsoleApp1.Action(Crypto.Cipher), 4, 1);
    c[2] = new Conver(new ConsoleApp1.Action(Crypto.CodeEncode), -5, 2);

    c[0].nextState = c[1].queue;
    c[1].nextState = c[2].queue;
    c[2].nextState = q;

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
    public long[] in_time, out_time, work_time;
    public char[] state;
    public char elem;
    public bool last;
    public Ask(int n, char elem, bool last = false)
    {
        in_time = new long[n];
        out_time = new long[n];
        work_time = new long[n];
        state = new char[n];
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
            elem.out_time[id] = DateTime.Now.Ticks;
            elem.in_time[id + 1] = DateTime.Now.Ticks;
            lock (nextState)
            { nextState.Enqueue(elem); }
            return state.finish; 
        }
        if (e)
        {
            elem.out_time[id] = DateTime.Now.Ticks;
            long s = DateTime.Now.Ticks;            
            elem.elem = a.Invoke(elem.elem, key); 
            elem.work_time[id] = DateTime.Now.Ticks - s;
            elem.state[id+1] = elem.elem;
          
                elem.in_time[id + 1] = DateTime.Now.Ticks;
                lock (nextState)
                { nextState.Enqueue(elem); }
            
        }
       
        return state.ok;
    }

    public void StartSerial()
    {
        Ask elem = queue.Dequeue();
        elem.out_time[id] = DateTime.Now.Ticks;
        if (elem.last)
            return;
        long s = DateTime.Now.Ticks;
        elem.elem = a.Invoke(elem.elem, key);
        elem.work_time[id] = DateTime.Now.Ticks - s;
        elem.state[id + 1] = elem.elem;
        elem.in_time[id + 1] = DateTime.Now.Ticks;
        nextState.Enqueue(elem);
    }

}