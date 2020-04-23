using kolos_APBD.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace kolos_APBD.Services
{
    public class DbPrescriptionService : IDbService
    {
        private const string ConnectionString = "Data Source=db-mssql;Initial Catalog=s18636;Integrated Security=True";

        public Prescription GetPrescription(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT p.Date, p.DueDate, p.idPatient, idDoctor FROM Prescription p WHERE IdPrescription = @id";
                command.Parameters.AddWithValue("id", id);

                Prescription pr = null;
                connection.Open();
                var dr = command.ExecuteReader();
                if (dr.Read())
                {
                    pr = new Prescription
                    {
                        Date = DateTime.Parse(dr["Date"].ToString()),
                        DueDate = DateTime.Parse(dr["DueDate"].ToString()),
                        idPatient = Int32.Parse(dr["idPatient"].ToString()),
                        idDoctor = Int32.Parse(dr["idDoctor"].ToString())
                };
                }
                dr.Close();

                List<Medicament> medicaments = new List<Medicament>(); 
                command.CommandText = "Select m.Name, m.Description, m.Type FROM Prescription_Medicament pm, Medicament m WHERE pm.IdMedicament = m.IdMedicament AND pm.IdPrescription = @id";

                dr = command.ExecuteReader();

                while (dr.Read()) {
                    medicaments.Add(
                            new Medicament
                            {
                                Name = dr["Name"].ToString(),
                                Description = dr["Description"].ToString(),
                                Type = dr["Type"].ToString()
                            }
                        );
                }

                pr.Contains = medicaments;

                return pr;
            }
        }
    }
}
