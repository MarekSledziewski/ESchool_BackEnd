using ESchool.Repository;

namespace ESchool.Services
{
    public class ESchoolServices
    {
        ESchoolRepository eSchoolRepository = new ESchoolRepository();
        public string GetUser()
        {
            eSchoolRepository.GetUser();

            return "ok";
        }
    }
}
