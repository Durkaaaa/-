﻿using System;
using System.Collections.Generic;

namespace Diplom.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public virtual ReceptionHour ReceptionHour { get; set; }

        // Ссылка на пациентов
        public List<Patient> Patients { get; set; }
        // Ссылка на врачей
        public List<Doctor> Doctors { get; set; }
        // Ссылка на рабочие часы
        public List<ReceptionHour> ReceptionHours { get; set; }
    }
}
