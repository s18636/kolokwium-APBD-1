using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos_APBD.Models
{
    public class Prescription
    {
           public DateTime Date { get; set; }
           public DateTime DueDate { get; set; }

           public int idPatient { get; set; }
           
           public int idDoctor { get; set; }

           public List<Medicament> Contains { get; set; }
    }
}
