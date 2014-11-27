using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathSample
{
    public static class ExceptionValidator
    {
        /// <summary>
        /// Shows if the exception <see cref="MyNullException" /> is valid
        /// </summary>
        /// <param name="nullEx"></param>
        /// <returns></returns>
        public static bool IsValid(this MyNullException nullEx)
        {
            return (nullEx.Occurence >= 5);
        }
    }
}
