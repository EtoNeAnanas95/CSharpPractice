namespace ConsoleApp1.clients
{
    internal interface ICRUD
    {
        public void Display<T>(T obj);
        public void Read(int userIndex);
        public void Search();
        public void Create();
        public void Update<T>(T obj, int num);
        public void Delete<T>(T obj, int num);
    }
}
