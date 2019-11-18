using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrix3
{ //Уже вкл. в NameSpace. Using не нужен.
    class CSparseMatrix<T> //Обобщенные данные (с++ -- шаблоны)
    {
        //Делаем словарь. Слоаврь -- это пары "ключ-значение"
        Dictionary<string, T> _Matrix = new Dictionary<string, T>();
        //Ключем словаря будет строка "Х_У", Х и У -- индексы

        //Кол-во эл. по ширине (кол-во столбцов, макс Х)
        int maxX;
        //Кол-во эл. по длине (кол-во строк, макс У)
        int maxY;
        //Кол-во эл. по высоте (кол-во строк, макс У)
        int maxZ;


        // Реализация интерфейса для проверки пустого элемента
        IMatrixCheckEmpty<T> CheckEmpty;

        //Конструктор
        public CSparseMatrix(int forX, int forY, int forZ, IMatrixCheckEmpty<T> forCheckEmpty)
        {
            this.maxX = forX;
            this.maxY = forY;
            this.maxZ = forZ;
            this.CheckEmpty = forCheckEmpty; //В объект класса передаем интерфейс для работы с пустыми данными
        }

        //Индексатор для доступа к данным матрицы
        public T this[int X, int Y, int Z]
        {
            set
            {
                CheckBound(X, Y, Z); //Проверка границ.
                string Key = dictKey(X, Y, Z); //Формируем строку из целых индексов. Х_У
                this._Matrix.Add(Key, value);
            }

            get
            {
                CheckBound(X, Y, Z); //Проверка границ.
                string Key = dictKey(X, Y, Z); //Формируем строку из целых индексов. Х_У
                if (this._Matrix.ContainsKey(Key)) //Даём ключ. Определяет "есть/нет" в словаре такой ключ.
                {
                    return this._Matrix[Key]; //Обращение к словарю через ключ. Возвращается значение (value)
                }
                else
                {
                    return this.CheckEmpty.getEmptyElement();
                }
            }
        }

        //Проверка границ
        void CheckBound(int X, int Y, int Z)
        {
            bool ofX = X < 0 || X >= this.maxX;
            bool ofY = Y < 0 || Y >= this.maxY;
            bool ofZ = Z < 0 || Z >= this.maxZ;
            //Проверка выхода за границы
            if (ofX)
            {
                throw new ArgumentOutOfRangeException("Неверный X: " + "X = " + X + ", что выходит за границы!");
            }
            if (ofY)
            {
                throw new ArgumentOutOfRangeException("Неверный Y: " + "Y = " + Y + ", что выходит за границы!");
            } 
            if (ofZ)
            {
                throw new ArgumentOutOfRangeException("Неверный Z: " + "Z = " + Z + ", что выходит за границы!");
            }
        }

        //Формируем ключ.
        string dictKey(int X, int Y, int Z)
        {
            return X.ToString() + "_" + Y.ToString() + "_" + Z.ToString();
        }

        ///ПЕЧАТЬ (Формирование строки для печати)
        public override string ToString()
        { //Будем использовать StringBuilder для улучшения производительности.
            StringBuilder sBuild = new StringBuilder(); //Формируем сложную строку.
            for (int k = 0; k < this.maxZ; k++)
            {
                sBuild.Append("\n\n Слой Z = " + k + "\n"); //Добавляет строку в сложную строку

                for (int i = 0; i < this.maxY; i++)
                {
                    sBuild.Append("[\t"); //Добавляет строку в сложную строку

                    for (int j = 0; j < this.maxX; j++)
                    {
                        if (j > 0)
                        {
                            sBuild.Append("\t"); //Между элементами матрицы будет табуляция.
                        }

                        //Если текущий элемент НЕ пустой.
                        if (!this.CheckEmpty.CheckEmptyElement(this[i, j, k]))
                        {
                            //Добавить к текущей строке приведенный элемент
                            sBuild.Append(this[i, j, k].ToString());
                        }
                        else
                        {
                            //Иначе добавить признак пустого значения
                            sBuild.Append("\tN/A\t");
                        }
                    }
                    sBuild.Append("\t]\n");
                }
            }
            return sBuild.ToString(); //Сложную строку преобразуем к нормальному виду.
        }

    }
}
