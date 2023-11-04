using System.Diagnostics;

namespace ConsoleGenerics
{
    class DataStore<T>
    {
        public T Data { get; set; }
    }
    class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
    class Printer<T>
    {
        public void Print(T data)
        {
            Console.WriteLine(data);
        }

        public T Add(T n1, T n2)
        {
            dynamic a = n1;
            dynamic b = n2;
            return a + b;
        }
    }

    public interface IActivity
    {
        void Process(string str);
    }

    public class Enumeration
    {
        public enum ModuleName
        {
            ReportGenerator = 1,
            ReportAnalyser = 2
        }
    }

    public class ReportGenerator : IActivity
    {
        public void Process(string str)
        {
            Console.WriteLine("{0} from Report Generator: ", str);
        }
    }

    public class ReportAnalyser : IActivity
    {
        public void Process(string str)
        {
            Console.WriteLine("{0} from Report Analzyer: ", str);
        }
    }

    public class FactoryPattern<K, T>
        where T : class, K, new()
    {
        public static K CreateInstance()
        {
            K objK;

            objK = new T();

            return objK;
        }
    }

    public class FactoryClass
    {
        public IActivity CreateInstance(Enumeration.ModuleName enumModuleName)
        {
            IActivity objActivity = null;

            switch (enumModuleName)
            {
                case Enumeration.ModuleName.ReportGenerator:
                    /* Old coding ...
                    objActivity = new ReportGenerator(); 
                    */
                    objActivity = FactoryPattern<IActivity,
              ReportGenerator>.CreateInstance();
                    break;
                case Enumeration.ModuleName.ReportAnalyser:
                    /* Old coding ...
                    objActivity = new ReportAnalyser();
                    */
                    objActivity = FactoryPattern<IActivity,
                  ReportAnalyser>.CreateInstance();
                    break;
                default:
                    break;
            }
            return objActivity;
        }
    }





    class NewDataStore<T>
    {
        private T[] _data = new T[10];

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T);
        }
    }

    public class Print<T>
    {
        public T Add(T n1, T n2)
        {
            dynamic a=n1;
            dynamic b = n2;
            return a + b;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {   
            var s = new Print<int>();
            Console.WriteLine(s.Add(150, 20));
            
            //FactoryClass f = new FactoryClass();
            //IActivity instance = f.CreateInstance(Enumeration.ModuleName.ReportAnalyser);
            //instance.Process("hello");

            //Printer<int> print = new Printer<int>();
            //print.Print("Test");
            //Console.WriteLine($"10+30={print.Add(10, 30)}");

            //FactoryPattern<IActivity, ReportAnalyser> pattern; = new FactoryPattern<IActivity, ReportAnalyser>();
            //IActivity objActivity = pattern.CreateInstance();
            //objActivity.Process("hello");


            //DataStore<string> store = new DataStore<string>();
            //KeyValuePair<string, int> keyPair = new KeyValuePair<string, int>();
            //keyPair.Key = "Word";
            //keyPair.Value = 25;
            //Console.WriteLine($"{keyPair.Key}/{keyPair.Value}");
            //store.Data = "Hello";
            //Console.WriteLine(store.Data);
            Console.ReadKey();
        }

        static int Add(int n1, int n2)
        {
            return n1 + n2;
        }
    }
}