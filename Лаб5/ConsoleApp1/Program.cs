using ConsoleApp1;
using System.Diagnostics;
using System.Runtime.CompilerServices;

Random r = new Random();
Queue<Ask> q;
Queue<Ask> exit;
Ask b;
const string alfabet = "abcdefghijklmnopqrstuvwxyz";
<<<<<<< HEAD
string[] input = new string[10];
//for(int i =0; i<10;i++)
//{
//    input[i]= Console.ReadLine();
//}
Console.WriteLine("Gen data");
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 20000; j++)
=======
string[] input = new string[1000];
//for (int i = 0; i < 10; i++)
//{
//    input[i] = Console.ReadLine();
//}
Console.WriteLine("Gen data");
for (int i = 0; i < 1000; i++)
{
    for (int j = 0; j < 22500; j++)
>>>>>>> d58ce9f92a3ef6c25dd1c409dae6834765a49f64
        input[i] += alfabet[r.Next(0, 300) % alfabet.Length];
    // Console.WriteLine(i);
}
Console.WriteLine("Done gen");

string[] input1 = new string[10];
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 500; j++)
        input1[i] += alfabet[r.Next(0, 300) % alfabet.Length];
    // Console.WriteLine(i);
}

q = new Queue<Ask>();
foreach (string c in input1)
{
    Ask a = new Ask(4, c);
    a.in_time[0] = DateTime.Now.Ticks;
    a.state[0] = c;
    q.Enqueue(a);
}
b = new Ask(4, "", true);
b.in_time[0] = DateTime.Now.Ticks;
b.state[0] = "";
q.Enqueue(b);
Console.WriteLine(q.Count);
exit = new Queue<Ask>();
SerialCode();


Console.WriteLine("&&@Parallel@&&");
q = new Queue<Ask>();
foreach (string c in input)
{
    Ask a = new Ask(4, c);
    a.in_time[0] = DateTime.Now.Ticks;
    a.state[0] = c;
    q.Enqueue(a);
}
b = new Ask(4, "", true);
b.in_time[0] = DateTime.Now.Ticks;
b.state[0] = "";
q.Enqueue(b);
Console.WriteLine(q.Count);
exit = new Queue<Ask>();
//SerialCode();
ParalCode();
Formatter.FormatOut(exit);

Console.WriteLine("&&@Serial@&&");
q = new Queue<Ask>();
foreach (string c in input)
{
    Ask a = new Ask(4, c);
    a.in_time[0] = DateTime.Now.Ticks;
    a.state[0] = c;
    q.Enqueue(a);
}
b = new Ask(4, "", true);
b.in_time[0] = DateTime.Now.Ticks;
b.state[0] = "";
q.Enqueue(b);
Console.WriteLine(q.Count);
exit = new Queue<Ask>();
//ParalCode();
SerialCode();
Formatter.FormatOut(exit);




//for (int k = 0; k <= 100; k++)
//{
//    string[] ss = new string[10000];
//   // Console.WriteLine("Gen data");
//    for (int i = 0; i < 10000; i++)
//    {
//        for (int j = 0; j < k*20+500; j++)
//            ss[i] += alfabet[r.Next(0, 300) % alfabet.Length];
//        // Console.WriteLine(i);
//    }
//    // Console.WriteLine(k * 20 + 500+",");
//    //q = new Queue<Ask>();
//    //foreach (string c in ss)
//    //{
//    //    Ask a = new Ask(4, c);
//    //    a.in_time[0] = DateTime.Now.Ticks;
//    //    a.state[0] = c;
//    //    q.Enqueue(a);
//    //}
//    //b = new Ask(4, "", true);
//    //b.in_time[0] = DateTime.Now.Ticks;
//    //b.state[0] = "";
//    //q.Enqueue(b);
//    //exit = new Queue<Ask>();
//    //ParalCode();

//    q = new Queue<Ask>();
//    foreach (string c in ss)
//    {
//        Ask a = new Ask(4, c);
//        a.in_time[0] = DateTime.Now.Ticks;
//        a.state[0] = c;
//        q.Enqueue(a);
//    }
//    b = new Ask(4, "", true);
//    b.in_time[0] = DateTime.Now.Ticks;
//    b.state[0] = "";
//    q.Enqueue(b);
//    exit = new Queue<Ask>();
//    SerialCode();
//}


string s = "";
//while (exit.Count > 0)
//    s += exit.Dequeue().elem;

//ParalDeCode();
//while (exit.Count > 0)
//    s += exit.Dequeue().elem;
//Console.WriteLine(s);

void ParalCode()
{
    Thread[] t = new Thread[3];
    Conver[] c = new Conver[3];
  
    c[0] = new Conver(new ConsoleApp1.Action(Crypto.CodeEncode),20, q, 0);
    c[1] = new Conver(new ConsoleApp1.Action(Crypto.Cipher), 10, 1);
    c[2] = new Conver(new ConsoleApp1.Action(Crypto.CodeEncode), 20, 2);

    c[0].nextState = c[1].queue;
    c[1].nextState = c[2].queue;
    c[2].nextState = exit;
    Stopwatch strender = new Stopwatch();
    TimeSpan ts = strender.Elapsed;
  
    for (int i = 0; i < 3; i++)
    {
        t[i] = new Thread(c[i].Start);
        t[i].Start();
    }
    strender.Start();
    foreach (Thread thread in t)
    {
        thread.Join();
    }
    strender.Stop();
   ts = strender.Elapsed;

    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
    Console.WriteLine(elapsedTime);
}
void SerialCode()
{
    Conver[] c = new Conver[3];

    c[0] = new Conver(new ConsoleApp1.Action(Crypto.CodeEncode), 20, q, 0);
    c[1] = new Conver(new ConsoleApp1.Action(Crypto.Cipher), 10, 1);
    c[2] = new Conver(new ConsoleApp1.Action(Crypto.CodeEncode), 20, 2);

    c[0].nextState = c[1].queue;
    c[1].nextState = c[2].queue;
    c[2].nextState = exit;
    Stopwatch strender = new Stopwatch();
    TimeSpan ts = strender.Elapsed;
    int g = q.Count;
    strender.Start();
    c[0].Start();
    c[1].Start();
    c[2].Start(); 
    strender.Stop();
    ts = strender.Elapsed;

    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
              ts.Hours, ts.Minutes, ts.Seconds,
              ts.Milliseconds / 10);
    Console.WriteLine(elapsedTime);
}

class Ask
{
    public long[] in_time, out_time, work_time, work_timeF;
    public string[] state;
    public string elem;
    public bool last;
    public Ask(int n, string elem, bool last = false)
    {
        in_time = new long[n];
        out_time = new long[n];
        work_time = new long[n];
        state = new string[n];
        work_timeF = new long[n];
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
            { e = queue.TryDequeue(out elem);
                elem.out_time[id] = DateTime.Now.Ticks;
            }
        }
        if (e && elem.last)
        {
            
            elem.in_time[id + 1] = DateTime.Now.Ticks;
            lock (nextState)
            { nextState.Enqueue(elem); }
            return state.finish; 
        }
        if (e)
        {
            long s = DateTime.Now.Ticks;            
            elem.elem = a.Invoke(elem, key, id); 
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
        {
            elem.in_time[id + 1] = DateTime.Now.Ticks;
            elem.state[id + 1] = elem.elem;
            nextState.Enqueue(elem);
            return;
        }
        long s = DateTime.Now.Ticks;
        elem.elem = a.Invoke(elem, key, id);
        elem.work_time[id] = DateTime.Now.Ticks - s;
        elem.state[id + 1] = elem.elem;
        elem.in_time[id + 1] = DateTime.Now.Ticks;
        nextState.Enqueue(elem);
    }

}