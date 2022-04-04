namespace IntelPro
{
    public partial class ModuleGasLimit
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Tool { get; set; }
        public int GasLine { get; set; }
        public string GasName { get; set; }
        public int LowerLimit { get; set; }
        public int Target { get; set; }
        public int UpperLimit { get; set; }
    }
}