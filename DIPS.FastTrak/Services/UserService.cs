using DIPS.FastTrak.Models;

namespace DIPS.FastTrak.Services;

public interface IUserService
{
    Person CurrentUser { get; }
    StudyCenter? StudyCenter { get; }
}

public class UserService : IUserService
{
    public Person CurrentUser { get; private set; } = new Person { FirstName = "Anne", LastName = "Johanson" };
    public StudyCenter StudyCenter { get; private set; } = new StudyCenter() { CenterName = "Sykehus" };
}
