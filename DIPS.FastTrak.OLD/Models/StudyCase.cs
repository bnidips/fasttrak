namespace DIPS.FastTrak.Models
{
    public interface IStudyCase
    {
        public Person Person { get; }
        public Study Study { get; }
    }

    public class StudyCase : IStudyCase
    {
        public Person Person { get; private set; }

        public Study Study { get; private set; }

        public StudyCase(Person person, Study study)
        {
            Person = person;
            Study = study;  
        }
    }
}