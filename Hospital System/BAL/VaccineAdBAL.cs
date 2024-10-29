using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
    public class VaccineAdBAL
    {
        VacineDAL vacineDAL=new VacineDAL();

        //list

        public List<VaccineDo> VaccineListAdmin()
        {
            return vacineDAL.VaccineListAdmin();
        }

        //Add vaccine 

        public List<VaccineDo> AddVaccine(VaccineDo vaccineDo)
        {
            List<VaccineDo> vaccineDos= new List<VaccineDo>();
            vaccineDos = vacineDAL.AddVaccine(vaccineDo);
            return vaccineDos;
        }

        //Vaccine edit
        public VaccineDo VaccineEdit(int PatientId)
        {
            VaccineDo vaccineDos = vacineDAL.VaccineEdit(PatientId);

            return vaccineDos;
        }
        //Vaccine delete
        public List<VaccineDo> VaccineDelete(int PatientId)
        {
            List<VaccineDo> vaccineDos = vacineDAL.VaccineDelete(PatientId);
            return vaccineDos;
        }
    }
}