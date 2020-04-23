using kolos_APBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos_APBD.Services
{
    public interface IDbService
    {
        public Prescription GetPrescription(int id);

    }
}
