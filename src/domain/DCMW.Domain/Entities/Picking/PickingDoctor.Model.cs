using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Pickings
{
    public class PickingDoctor : BaseEntity
    {
        public PickingDoctor(Guid id, Guid doctorID, string fullName, string mobileNumber, string personalNumber) : base(id)
        {
            FullName = fullName;
            MobileNumber = mobileNumber;
            PersonalNumber = personalNumber;
            DoctorID = doctorID;
        }

        private Guid _doctorID;
        private string _fullName;
        private string _mobileNumber;
        private string _personalNumber;

        public Guid DoctorID { get => _doctorID; set => _doctorID = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public string MobileNumber { get => _mobileNumber; set => _mobileNumber = value; }
        public string PersonalNumber { get => _personalNumber; set => _personalNumber = value; }
    }
}
