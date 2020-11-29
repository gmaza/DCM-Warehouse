namespace DCMW.Domain.Distributors
{
    public partial class Distributor : BaseEntity
    {
        private string _fullName;
        private string _mobileNumber;
        private string _email;
        private string _companyName;

        public string FullName
        {
            get => _fullName;
        }

        public string MobileNumber
        {
            get => _mobileNumber;
        }

        public string Email
        {
            get => _email;
        }

        public string CompanyName
        {
            get => _companyName;
        }
    }
}