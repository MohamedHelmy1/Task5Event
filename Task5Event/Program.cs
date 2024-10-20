namespace Task5Event
{
    class employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
       public DateTime EmployedDate { get; set;}= DateTime.Now;
        public employee(int id,string name,string location)
        {
                this.Id = id;
            this.Name = name;
            this.Location = location;
            this.EmployedDate = DateTime.Now;
        }
       
        public event Action<employee> EmployeeCreated;
        public void OnEmployeeCreated()
        {
            EmployeeCreated?.Invoke(this);
        }
        public override string ToString()
        {
            return $"Employee Id= {Id}\t Employee Name : {Name}\t from({Location}) Emplyed in {EmployedDate}";
        }

    }
    class club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public club(int id,string name,string location)
        {
            this.Id = id;
            this.Name = name;
            this.Location = location;
                
        }
        public void AddEmployeeToClum( employee emp) {
            Console.WriteLine(emp);
            Console.WriteLine($" Employee ( {emp.Name}) is Add to {Name} Club Location{Location} at ({emp.EmployedDate.ToShortTimeString}");
        }
        public override string ToString()
        {
            return $"club name is {Name} in({Location})";
        }
    }
    class socialenSurance
    {
        public int Id { get; set; }
        public string Number { get; set; }
       
        public socialenSurance(int id, string nmber)
        {
            this.Id = id;
            this.Number = nmber;
           

        }
        public void beingsocialenSurance(employee emp)
        {
           
            Console.WriteLine($"Emplyee \t{emp.Name}is Add to socialenSurance Number {Number} at ({emp.EmployedDate} ");
        }
        public override string ToString()
        {
            return $"socialenSurance is {Number} )";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            employee emp = new employee(1, "Ali", "egypt");
            club club=new club(1,"Naser Club","Egypt");
            socialenSurance socialenSurance = new socialenSurance(1, "458");
            emp.EmployeeCreated += club.AddEmployeeToClum;
            emp.EmployeeCreated += socialenSurance.beingsocialenSurance;
            emp.OnEmployeeCreated();


        }
    }
}
