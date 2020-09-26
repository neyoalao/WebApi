using System;
using System.Collections.Generic;
using System.Linq;
using NsigVerificationAPI.Models;

namespace NsigVerificationAPI.Data
{
    public class SqlNsigVerificationAPIRepo: INsigVerificationAPIRepo
    {
        private readonly NsigVerificationAPIContext _context;

        public SqlNsigVerificationAPIRepo(NsigVerificationAPIContext context)
        {
            _context = context;
        }

        public void CreateCertificate(Certificate cert)
        {
            if(cert == null)
            {
                throw new ArgumentNullException(nameof(cert));
            }
            _context.Certificates.Add(cert);
        }

        public void DeleteCertificate(Certificate cert)
        {
            if (cert == null)
            {
                throw new ArgumentNullException(nameof(cert));
            }
            _context.Certificates.Remove(cert);
        }

        public IEnumerable<Certificate> GetAllCertificates()
        {
            return _context.Certificates.ToList();
        }

        public Certificate GetCertificateById(int id)
        {
            return _context.Certificates.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCertificate(Certificate cert)
        {
            //nothing is done
        }
    }
}
