namespace Core.Models
{
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User's name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User's Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// User's Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Users's Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Users's Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Users's City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Users's State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Users's Zip
        /// </summary>
        public string Zip { get; set; }
    }
}
