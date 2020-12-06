using System;

namespace DCMW.Domain.Doctors
{
    public partial class Doctor
    {
        public Doctor(Guid id, string fullName, string mobile, string personalNumber) : base(id)
        {
            _fullName = fullName;
            _mobileNumber = mobile;
            _personalNumber = personalNumber;
        }

        public Doctor ChangeFullName(string fullName)
        {
            _fullName = fullName;
            return this;
        }
        
        public Doctor ChangeMobile(string mobile)
        {
            _mobileNumber = mobile;
            return this;
        }

        public Doctor ChangePersonalNumber(string personalNumber)
        {
            _personalNumber = personalNumber;
            return this;
        }
    }
}