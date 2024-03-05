namespace ConsoleApp1.classes
{
    public class Accounting : ICloneable
    {
        public int id;
        public string nameOperation;
        public int sum;
        public DateOnly operationDate;
        public bool gain;

        public Accounting(
            int id,
            string nameOperation,
            int sum,
            DateOnly operationDate,
            bool gain
            )
        {
            this.id = id;
            this.nameOperation = nameOperation;
            this.sum = sum;
            this.operationDate = operationDate;
            this.gain = gain;
        }
        
        public object Clone()
        {
            return (Accounting)this.MemberwiseClone();
        }
    }
}

