namespace ConsoleApp1.classes
{
    internal class Employee : ICloneable
    {
        public int id;
        public string name;
        public string surname;
        public string middlename;
        public DateOnly birthDate;
        public int passportSeriesAndNunmber;
        public int wage;
        public int post;

        public Employee(int id, string name, string surname, string middlename, DateOnly birthDate, int passportSeriesAndNunmber, int wage, int post)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.middlename = middlename;
            this.birthDate = birthDate;
            this.passportSeriesAndNunmber = passportSeriesAndNunmber;
            this.wage = wage;
            this.post = post;
        }
        
        public object Clone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }
}

