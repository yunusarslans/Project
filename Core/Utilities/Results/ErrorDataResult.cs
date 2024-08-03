using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)    //data mesaj ve işlem sonucunu geçtiği
        {

        }

        public ErrorDataResult(T data) : base(data, false)        //data ve işlem sonucu geçtilen durum
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)   //sadece mesaj geçmek
        {

        }

        public ErrorDataResult() : base(default, false)       //hiçbir mesaj verme
        {

        }
    }
}
