using System;

namespace DCMW.Domain.Deliveries
{
    public class DeliveryDistributor : BaseEntity
    {
        private DeliveryDistributor() { }

        public DeliveryDistributor(Guid id, string fullName, string mobileNumber, string email, string companyName) : base(id)
        {
            _fullName = fullName;
            _mobileNumber = mobileNumber;
            _email = email;
            _companyName = companyName;
        }

        private string _fullName;
        private string _mobileNumber;
        private string _email;
        private string _companyName;

        public string FullName
        {
            get => _fullName;
            set => value = _fullName;
        }

        public string MobileNumber
        {
            get => _mobileNumber;
            set => value = _mobileNumber;
        }

        public string Email
        {
            get => _email;
            set => value = _email;
        }

        public string CompanyName
        {
            get => _companyName;
            set => value = _companyName;
        }
    }
}