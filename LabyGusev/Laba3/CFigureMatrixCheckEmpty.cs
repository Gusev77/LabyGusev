using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrix3
{
    // Реализация интерфейса IMatrixChekEmpty для класса Figure
    class CFigureMatrixCheckEmpty : IMatrixCheckEmpty<Figure>
    {
        // В качестве пустного элемента возвращаем NULL
        public Figure getEmptyElement()
        {
            return null;
        }

        //Проверка, что переданный параметр =null
        public bool CheckEmptyElement(Figure Element)
        {
            bool Result = false;
            if (Element == null)
            {
                Result = true;
            }
            return Result;
        }
    }
}
