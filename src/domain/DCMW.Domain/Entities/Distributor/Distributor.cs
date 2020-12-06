using System;

namespace DCMW.Domain.Distributors
{
    public partial class Distributor
    {
        public Distributor(Guid id, string fullname, string mobile, string email, string company) : base(id)
        {
            _fullName = fullname;
            _mobileNumber = mobile;
            _companyName = company;
            _email = email;
        }

        public Distributor ChangeFullName(string fullname)
        {
            _fullName = fullname;
            return this;
        }

        public Distributor CHangeMobile(string mobile)
        {
            _mobileNumber = mobile;
            return this;
        }

        public Distributor ChangeCompanyName(string companyName)
        {
            _companyName = companyName;
            return this;
        }

        public Distributor ChangeEmail(string email)
        {
            _email = email;
            return this;
        }
    }
}