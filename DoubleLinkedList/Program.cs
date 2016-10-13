using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    class Program
    {
        public static Person _firstPerson = null;

        static void Main(string[] args)
        {
            string st = "";

            while (true)
            {
                Console.Clear();

                Console.WriteLine("1. Вывести все элементы");
                Console.WriteLine("2. Вывести все элементы в обратном порядке");
                Console.WriteLine("3. Добавить элемент по индексу");
                Console.WriteLine("4. Удалить элемент по индексу");
                Console.WriteLine("5. Удалить все элементы с заданной фамилией");
                Console.WriteLine("6. Сортировка элементов по фамилии");
                Console.WriteLine("7. Сохранение списка в файл");
                Console.WriteLine("8. Загрузка списка из файла");

                st = Console.ReadLine();

                switch (st)
                {
                    case "1": showList(); break;
                    case "2": showListRevers();  break;
                    case "3": Console.WriteLine("Введите индекс"); insertElement(Convert.ToInt32(Console.ReadLine())); break;
                    case "4": Console.WriteLine("Введите индекс"); deleteElement(Convert.ToInt32(Console.ReadLine())); break;
                    case "5": Console.WriteLine("Введите фамилию"); deleteElement(Console.ReadLine()); break;
                    case "6": sortList(); break;
                    case "7": saveList(); break;
                    case "8": loadList(); break;
                    default: Console.WriteLine("Введен невенрый номер"); break;
                }

                Console.ReadKey();
                st = "";
            }
        }

        public static void sortList()
        {
            Person _currentPerson = _firstPerson;

            int count = 0;
            int i = 0;

            while (_currentPerson._nextPerson != null)
            {
                string current = _currentPerson._data._surname;
                string next = _currentPerson._nextPerson._data._surname;
                i = 0;

                while (i < next.Length && i < current.Length)
                {
                    if (Convert.ToInt32(current[i]) == Convert.ToInt32(next[i]))
                    {
                        i += 1;
                        continue;
                    }

                    if (Convert.ToInt32(current[i]) > Convert.ToInt32(next[i]))
                    {
                        Person _newPerson = _currentPerson;
                        _currentPerson = _currentPerson._nextPerson;

                        if (_newPerson == _firstPerson)
                        {                           
                            _currentPerson._previousPerson = null;
                            _newPerson._previousPerson = _currentPerson;
                            _newPerson._nextPerson = _currentPerson._nextPerson;
                            _currentPerson._nextPerson._previousPerson = _newPerson;
                            _currentPerson._nextPerson = _newPerson;

                            _firstPerson = _currentPerson;
                        }
                        else
                        {
                            if (_currentPerson._nextPerson != null)
                            {
                                _currentPerson._previousPerson = _newPerson._previousPerson;
                                _newPerson._previousPerson._nextPerson = _currentPerson;
                                _newPerson._previousPerson = _currentPerson;
                                _newPerson._nextPerson = _currentPerson._nextPerson;
                                _currentPerson._nextPerson._previousPerson = _newPerson;
                                _currentPerson._nextPerson = _newPerson;
                                
                            }
                            else
                            {
                                _currentPerson._previousPerson = _newPerson._previousPerson;
                                _newPerson._previousPerson._nextPerson = _currentPerson;
                                _newPerson._previousPerson = _currentPerson;
                                _newPerson._nextPerson = _currentPerson._nextPerson;
                                //_currentPerson._nextPerson._previousPerson = _newPerson;
                                _currentPerson._nextPerson = _newPerson;
                            }
                        }
                        break;

                    }

                    if (Convert.ToInt32(current[i]) < Convert.ToInt32(next[i]))
                    {
                        break;
                    }
                }

                _currentPerson = _currentPerson._nextPerson;
                count += 1;

            }

            _currentPerson = _firstPerson;

            for (int t = 0; t < count; t++)
            {
                while (_currentPerson._nextPerson != null)
                {
                    string current = _currentPerson._data._surname;
                    string next = _currentPerson._nextPerson._data._surname;
                    i = 0;

                    while (i < next.Length && i < current.Length)
                    {
                        if (Convert.ToInt32(current[i]) == Convert.ToInt32(next[i]))
                        {
                            i += 1;
                            continue;
                        }

                        if (Convert.ToInt32(current[i]) > Convert.ToInt32(next[i]))
                        {
                            Person _newPerson = _currentPerson;
                            _currentPerson = _currentPerson._nextPerson;

                            if (_newPerson == _firstPerson)
                            {
                                _currentPerson._previousPerson = null;
                                _newPerson._previousPerson = _currentPerson;
                                _newPerson._nextPerson = _currentPerson._nextPerson;
                                _currentPerson._nextPerson._previousPerson = _newPerson;
                                _currentPerson._nextPerson = _newPerson;

                                _firstPerson = _currentPerson;
                            }
                            else
                            {
                                if (_currentPerson._nextPerson != null)
                                {
                                    _currentPerson._previousPerson = _newPerson._previousPerson;
                                    _newPerson._previousPerson = _currentPerson;
                                    _newPerson._nextPerson = _currentPerson._nextPerson;
                                    _currentPerson._nextPerson._previousPerson = _newPerson;
                                    _currentPerson._nextPerson = _newPerson;
                                }
                                else
                                {
                                    _currentPerson._previousPerson = _newPerson._previousPerson;
                                    _newPerson._previousPerson = _currentPerson;
                                    _newPerson._nextPerson = _currentPerson._nextPerson;
                                    _currentPerson._nextPerson = _newPerson;
                                }
                            }
                            break;

                        }

                        if (Convert.ToInt32(current[i]) < Convert.ToInt32(next[i]))
                        {
                            break;
                        }
                    }

                    _currentPerson = _currentPerson._nextPerson;
                    count += 1;

                }
            }//
            Console.WriteLine("Список отсортирован");
        }

        public static void deleteElement(string _surnameToDelete)
        {
            Person _currentPerson = _firstPerson;
            while(_currentPerson != null)
            {
                if(_currentPerson._data._surname == _surnameToDelete)
                {
                    if(_currentPerson == _firstPerson)
                    {
                        _firstPerson = _currentPerson._nextPerson;
                        _currentPerson._nextPerson._previousPerson = null;
                    }
                    if(_currentPerson._nextPerson == null)
                    {
                        _currentPerson._previousPerson._nextPerson = null;
                    }
                    if(_currentPerson._nextPerson != null && _currentPerson._previousPerson != null)
                    {
                        _currentPerson._previousPerson._nextPerson = _currentPerson._nextPerson;
                        _currentPerson._nextPerson._previousPerson = _currentPerson._previousPerson._nextPerson;
                    }
                }
                _currentPerson = _currentPerson._nextPerson;
            }
            Console.WriteLine("Элементы с фамилией: {0} удалены", _surnameToDelete);
        }

        public static void loadList()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("test.txt");
                string[] _data = lines[0].Split(' ');

                Data _insertData = new Data();
                _insertData._surname = _data[0];
                _insertData._growth = Convert.ToInt32(_data[1]);
                _insertData._bithDate = Convert.ToDateTime(_data[2]);

                Person _currentPerson = new Person(_insertData);
                _firstPerson = _currentPerson;

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] _datas = lines[i].Split(' ');

                    Data _insertDatas = new Data();

                    _insertDatas._surname = _datas[0];
                    _insertDatas._growth = Convert.ToInt32(_datas[1]);
                    _insertDatas._bithDate = Convert.ToDateTime(_datas[2]);

                    Person _newPerson = new Person(_insertDatas);

                    _currentPerson._nextPerson = _newPerson;
                    _newPerson._previousPerson = _currentPerson;
                    _currentPerson = _newPerson;
                }
                Console.WriteLine("Список успешно загружен");
            }
            catch
            { Console.WriteLine("Ошибка загрузки списка"); }

        }

        public static void saveList()
        {
            if (_firstPerson != null)
            {
                using (System.IO.StreamWriter _writer = new System.IO.StreamWriter("test.txt"))
                {
                    string str = "";

                    Person _currentPerson = _firstPerson;
                    while (_currentPerson != null)
                    {
                        str = _currentPerson._data._surname + " " + _currentPerson._data._growth + " " + _currentPerson._data._bithDate.Day + "." +  _currentPerson._data._bithDate.Month + "." +  _currentPerson._data._bithDate.Year;
                        _writer.WriteLine(str);
                        _currentPerson = _currentPerson._nextPerson;
                    }

                    Console.WriteLine("Список сохранен в файл");
                }
            }
            else
                Console.WriteLine("Список пуст");
        }

        public static void showList()
        {
            if (_firstPerson == null)
                Console.WriteLine("Список пуст");
            else
            {
                Person _currentPerson = _firstPerson;
                while (_currentPerson != null)
                {
                    Console.WriteLine(_currentPerson._data._surname + " " + _currentPerson._data._growth + " " + _currentPerson._data._bithDate.Day + "." + _currentPerson._data._bithDate.Month + "." + _currentPerson._data._bithDate.Year);
                    _currentPerson = _currentPerson._nextPerson;
                }
            }
        }

        public static void showListRevers()
        {
            if (_firstPerson == null)
                Console.WriteLine("Список пуст");
            else
            {
                Person _currentPerson = _firstPerson;

                while (_currentPerson._nextPerson != null)
                    _currentPerson = _currentPerson._nextPerson;
                while (_currentPerson != null)
                {
                    Console.WriteLine(_currentPerson._data._surname + " " + _currentPerson._data._growth + " " + _currentPerson._data._bithDate.Day + "." + _currentPerson._data._bithDate.Month + "." + _currentPerson._data._bithDate.Year);
                    _currentPerson = _currentPerson._previousPerson;
                }
            }
        }

        public static void deleteElement(int index)
        {
            if (_firstPerson == null)
                Console.WriteLine("Список пуст");
            else
            {
                if (_firstPerson._nextPerson == null)
                {
                    _firstPerson = null;
                }
                else
                {
                    if (index == 1)
                    {
                        _firstPerson = _firstPerson._nextPerson;
                        _firstPerson._nextPerson._previousPerson = null;
                    }
                    else
                    {
                        Person _currentPerson = _firstPerson;
                        int count = 1;

                        while (_currentPerson._nextPerson != null && index != count)
                        {
                            _currentPerson = _currentPerson._nextPerson;
                            count += 1;
                        }

                        if (_currentPerson._nextPerson == null)
                        {
                            _currentPerson._previousPerson._nextPerson = null;
                        }
                        else
                        {
                            if (index == count)
                            {
                                _currentPerson._previousPerson._nextPerson = _currentPerson._nextPerson;
                                _currentPerson._nextPerson._previousPerson = _currentPerson._previousPerson;
                            }
                        }
                    }
                }
            }
        }
        
        public static void insertElement(int index)
        {
            Console.WriteLine("Введите через пробел Фамилию, рост, дату рождения");
            string[] _data = Console.ReadLine().Split(' ');

            Data _insetData = new Data();

            _insetData._surname = _data[0];
            _insetData._growth = Convert.ToInt32(_data[1]);
            _insetData._bithDate = Convert.ToDateTime(_data[2]);

            Person _insetrPerson = new Person(_insetData);


            if (_firstPerson == null)
            {
                _firstPerson = _insetrPerson;
                _insetrPerson._nextPerson = null;
                _insetrPerson._previousPerson = null;
            }
            else
            {
                if (index == 1 && _firstPerson != _insetrPerson)
                {
                    _insetrPerson._nextPerson = _firstPerson;
                    _firstPerson = _insetrPerson;
                    _insetrPerson._nextPerson._previousPerson = _firstPerson;
                }
                else
                {
                    Person _currentPerson = _firstPerson;
                    int count = 1;

                    while (_currentPerson._nextPerson != null && count != index)
                    {
                        _currentPerson = _currentPerson._nextPerson;
                        count += 1;
                    }


                    if (_currentPerson._nextPerson == null)
                    {
                        _currentPerson._nextPerson = _insetrPerson;
                        _insetrPerson._previousPerson = _currentPerson;
                        _insetrPerson._nextPerson = null;
                    }
                    else
                    {
                        if (count == index)
                        {
                            _currentPerson._previousPerson._nextPerson = _insetrPerson;
                            _insetrPerson._previousPerson = _currentPerson._previousPerson;
                            _currentPerson._previousPerson = _insetrPerson;
                            _insetrPerson._nextPerson = _currentPerson;
                        }
                    }

                }
            }

        }

        public class Person
        {
            public Person _previousPerson;

            public Data _data { get; set; }

            public Person _nextPerson;

            public Person(Data dt)
            {
                this._data = dt;
                this._nextPerson = null;
                this._previousPerson = null;
            }
        }

        public class Data
        {
            public string _surname { get; set; }
            public int _growth { get; set; }
            public DateTime _bithDate { get; set; }
        }
    }
}
