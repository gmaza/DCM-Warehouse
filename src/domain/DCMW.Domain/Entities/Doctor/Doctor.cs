using System;

namespace DCMW.Domain.Doctor
{
    public partial class Doctor
    {
        public Doctor(Guid id, string fullName, string mobile, string personalNumber) : base(id)
        {
            _fullName = fullName;
            _mobileNumber = mobile;
            _personalNumber = personalNumber;
        }
    }
}