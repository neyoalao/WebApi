using System.Collections.Generic;
using NsigVerificationAPI.Models;

namespace NsigVerificationAPI.Data
{
    public interface INsigVerificationAPIRepo
    {
        bool SaveChanges();

        //returns an enumerable of all the certificates
        IEnumerable<Certificate> GetAllCertificates();

        // returns the certicate of the provided id number
        Certificate GetCertificateById(int id);

        void CreateCertificate(Certificate cert); 
    }
}