using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrix3
{
    public interface IMatrixCheckEmpty<T>
    {
        T getEmptyElement(); //Этот метод возвращает пустой элемент.
        bool CheckEmptyElement(T Element); //Проверка на пустотность элемента.
    }
}
