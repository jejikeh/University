﻿
namespace _14lab
{
    class Node
    {
        private int _value;
        private int _index;


        public int GetValue { get { return _value; } }
        public Node(int value, int index)
        {
            _value = value;
            _index = index;
        }
        internal void Print() // Вывод данных узла
        {
            Console.WriteLine("Value -> " + _value + " at " + _index + " index");
        }

        internal void Add(int value) // Добавление значения к узлу
        {
            _value += value;
        }

        public static Node operator +(Node a, int value) =>  new Node(a._value + value, a._index);
    }


    class VectorArray
    {
        public int CurrentSize = -1;
        private int _maxSize;
        public List<Node> Array = new List<Node>();

        public int GetMaxSize{ get { return _maxSize; } }

        public VectorArray(int maxSizeArray) // конструктор
        {
            Array = new Node[maxSizeArray];
            _maxSize = maxSizeArray;
        }

        public Node? Root() // Указатель на корневой элемент
        {
            if(Array[0] != null)
            {
                return Array[0];
            }
            return null;
        }

        public void Add(int value) // добавить новый узел
        {
            CurrentSize++;
            if(CurrentSize < _maxSize)
            {
                Array[CurrentSize] = new Node(value, CurrentSize); // Новый узел
            }
            else
            {
                Console.WriteLine("Max Size");
                System.Environment.Exit(0); // Если масссив переполнен
            }
        }


        // Методы вывода элементов

        public void Print(int index) // Вывод определенного элемента
        {
            if(index <= CurrentSize)
            {
                Array[index].Print();
            }else
            {
                Console.WriteLine("Big number");
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i <= CurrentSize; i++)
            {
                Array[i].Print();
            }
        }

        // Метод добавление значения к каждому элементу

        public void AddValueToAll(int value)
        {
            for (int i = 0; i <= CurrentSize; i++) // прибавление значение к каждому элементу
            {
                Console.WriteLine((Array[i] + value).GetValue);

            }
        }


        // Метод проверки на  неравенство
        internal void CheckEqual()
        {
            int repeatedTimes = 0;
            for(int i = 0; i <= CurrentSize; i++)
            {
                for(int l = 0; l <= CurrentSize; l++)
                {
                    if(Array[i].GetValue == Array[l].GetValue) 
                    {
                        repeatedTimes++; // Считаем сколько раз каждый элемент повторяется в массиве
                    }
                    
                }
                if(repeatedTimes == 1)
                {
                    Console.WriteLine(Array[i].GetValue + " non equal");
                }
                repeatedTimes = 0;
            }
        }

        
    }
}
