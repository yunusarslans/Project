using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)    //data mesaj ve işlem sonucunu geçtiği
        {
        }

        public SuccessDataResult(T data) : base(data, true)                         //data ve işlem sonucu geçtilen durum
        {

        }

        public SuccessDataResult(string message) : base(default, true, message)         //sadece mesaj geçmek 
        {

        }

        public SuccessDataResult() : base(default, true)                              //hiçbir mesaj verme
        {
        }
    }
}
