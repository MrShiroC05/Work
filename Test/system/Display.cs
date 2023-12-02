namespace Test.system
{
    public class Display
    {
        Display()
        {
            sv = new();
        }
        public Service sv { get; set; }
        public void Test()
        {
            sv.Display();
        }
    }
}
