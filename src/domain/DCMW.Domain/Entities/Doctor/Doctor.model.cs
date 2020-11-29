namespace DCMW.Domain.Doctor
{
    public partial class Doctor : BaseEntity
    {
        private string _fullName;
        private string _mobileNumber;
        private string _personalNumber;

        public string FullName
        {
            get => _fullName;
        }

        public string MobileNumber
        {
            get => _mobileNumber;
        }

        public string PersonalNumber
        {
            get => _personalNumber;
        }
    }
}