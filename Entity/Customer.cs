using Entity.Enums;

namespace Entity
{
    public class Customer : User
    {
        public string? Address;
        public required string NIN;

        public Customer() : base()
        {
        }
        internal static Customer FormatLine(string custStr)
        {
            string[] props = custStr.Split('\t');
            return new Customer
            {
                Id = Guid.Parse(props[0]),
                FirstName = props[1],
                LastName = props[2],
                Password = props[3],
                Phone = props[4],
                Address = props[5],
                NIN = props[6],
                Gender = (Gender)Enum.Parse(typeof(Gender), props[7])
            };
        }
        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{Password}\t{Phone}\t{Address}\t{NIN}\t{nameof(Gender)}";
        }
    }
}