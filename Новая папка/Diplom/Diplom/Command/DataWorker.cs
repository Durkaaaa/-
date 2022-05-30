using Diplom.Model;
using Diplom.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Command
{
    public class DataWorker
    {
        #region[Full table]
        // Вся таблица врачи
        public static List<Doctor> GetAllDoctor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allDoctor = db.Doctors.ToList();
                return allDoctor;
            }
        }
        #endregion
    }
}