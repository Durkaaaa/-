﻿using Diploma.Command;
using Diploma.Model;
using Diploma.View;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Diploma.ViewModel
{
    public class DataEditTicketVM : ViewModelBase
    {
        public static Ticket SelectedTicket { get; set; }
        public static DateTime Date { get; set; }
        public static ReceptionHour SelectedReceptionHour { get; set; }
        public static int IndexReceptionHour { get; set; }
        public static Speciality SelectedSpeciality { get; set; }
        public static int IndexSpeciality { get; set; }

        public DataEditTicketVM(Ticket selectedTicket)
        {
            SelectedTicket = selectedTicket;
            Date = SelectedTicket.Date;
            IndexReceptionHour = DataWorker.GetIndexReceptionHour(SelectedTicket.ReceptionHourId);
            IndexSpeciality = DataWorker.GetIndexSpecialityByDoctor(SelectedTicket.DoctorId);
        }

        private List<ReceptionHour> _allReceptionHour = DataWorker.GetAllReceptionHour();
        public List<ReceptionHour> AllReceptionHour
        {
            get { return _allReceptionHour; }
            set
            {
                _allReceptionHour = value;
                NotifyPropertyChanged("AllReceptionHour");
            }
        }

        private List<Speciality> _allSpeciality = DataWorker.GetAllSpeciality();
        public List<Speciality> AllSpeciality
        {
            get { return _allSpeciality; }
            set
            {
                _allSpeciality = value;
                NotifyPropertyChanged("AllSpeciality ");
            }
        }

        public RelayCommand EditTicketDateTime
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 0, 0, 0);
                    DateTime dateTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 7, 0, 0, 0);
                    if (Date <= dateTime ||
                        Date >= dateTime1 ||
                        SelectedSpeciality == null ||
                        SelectedReceptionHour == null)
                    {
                        if (Date <= dateTime || Date > dateTime1)
                            ShowMessageToUser("Не правильная дата");

                        if (SelectedReceptionHour == null)
                            ShowMessageToUser("Не выбрано время");

                        if (SelectedSpeciality == null)
                            ShowMessageToUser("Не выбрана специальность");
                    }
                    else
                    {
                        var patient = DataWorker.GetPatientForTicket(Date, SelectedReceptionHour);
                        patient = DataWorker.AddPatient(SelectedTicket, patient);
                        var doctor = DataWorker.GetDoctorForTicket(Date, SelectedReceptionHour, SelectedSpeciality);
                        doctor = DataWorker.AddDoctor(SelectedTicket, doctor);
                        if (doctor.Count == 0)
                        {
                            ShowMessageToUser("На эту дату и время свободных врачей нет");
                        }
                        else
                        {
                            EditTicketPatientDoctorWindow editTicketPatientDoctorWindow = new EditTicketPatientDoctorWindow(SelectedTicket, patient, doctor, Date, SelectedReceptionHour, window);
                            SetCenterPositionAndOpen(editTicketPatientDoctorWindow);
                            SelectedSpeciality = null;
                            SelectedReceptionHour = null;
                        }
                    }
                });
            }
        }
    }
}
