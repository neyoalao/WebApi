using System.Collections.Generic;
using NsigVerificationAPI.Models;

namespace NsigVerificationAPI.Data
{
    public class MockNsigVerificationAPIRepo : INsigVerificationAPIRepo
    {
        public void CreateCertificate(Certificate cert)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Certificate> GetAllCertificates()
        {
            var certificates = new List<Certificate>
            {
                new Certificate { Id = 0, FirstName = "Vincent", LastName = "Obigwe" },
                new Certificate { Id = 1, FirstName = "Oladipupo", LastName = "Ajayi" },
                new Certificate { Id = 2, FirstName = "Taiwo", LastName = "Osokoya" },
                new Certificate { Id = 3, FirstName = "Ukeme", LastName = "Bassey" },
                new Certificate { Id = 4, FirstName = "Darlignton", LastName = "Somto" }

        };
            return certificates;
        }

        public Certificate GetCertificateById(int id)
        {
            return new Certificate { Id = 0, FirstName = "Vincent", LastName = "Obigwe" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}