using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Wpf.Controllers.Cadastros.Core.Interfaces
{
    /// <summary>
    /// Interface Controller
    /// </summary>
    public interface IControllerRegister
    {
        /// <summary>
        /// New record
        /// </summary>
        /// <returns></returns>
        bool New();
        /// <summary>
        /// Save record
        /// </summary>
        /// <returns></returns>
        bool Save();
        /// <summary>
        /// Cancela edition or new record
        /// </summary>
        /// <returns></returns>
        bool Cancel();
        /// <summary>
        /// Delete record
        /// </summary>
        /// <returns></returns>
        bool Delete();
        /// <summary>
        /// Go to the previous record
        /// </summary>
        void Previous();
        /// <summary>
        /// Go to the next record
        /// </summary>
        void Next();
        /// <summary>
        /// Go to the first record
        /// </summary>
        void First();
        /// <summary>
        /// Go to the last record
        /// </summary>
        void Last();
    }
}