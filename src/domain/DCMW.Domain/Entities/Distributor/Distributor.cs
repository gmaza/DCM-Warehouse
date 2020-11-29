namespace DCMW.Domain.Distributor {
    public class Distributor{
        public Distributor(Guid id, string fullname, string mobile, string email, string company) : base(id)
        {
            _fullName = fullname;
            _mobileNumber = mobile;
            _companyName = company;
            _email = email;
        }
    }
}