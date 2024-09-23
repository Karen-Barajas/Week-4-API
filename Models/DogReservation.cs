using Microsoft.EntityFrameworkCore;

namespace MSSD_725_Week_4_Project.Models
{
    //Base class
    [Serializable]
    public class DogReservation : IDogReservation
    {
        //Properties
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string DogName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //Constructor
        public DogReservation(string ownerName, string dogName, DateTime checkInDate, DateTime checkOutDate, string email, string phoneNumber)
        {
            OwnerName = ownerName;
            DogName = dogName;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        //Methods

        //Calculate how long stay is
        public int Duration()
        {
            return (CheckOutDate - CheckInDate).Days;
        }

        //Set price per night
        private const int PricePerNight = 40;

        public int CalculateTotalCost()
        {
            int duration = Duration();
            int totalCost = duration * PricePerNight;
            return totalCost;
        }

        //Display confirmation of reservation
        public virtual void Confirmation()
        {
            Console.WriteLine($"\nThank you, {OwnerName} for your reservation for {DogName} at The Maxie Inn. You have booked a stay at The Maxie Inn from {CheckInDate.ToShortDateString()} to {CheckOutDate.ToShortDateString()}. A confirmation email will be sent to {Email} soon. A call will be made to your number, {PhoneNumber}, for additional information. We are looking forward to {DogName}'s stay with us!");
        }
    }

    //Extended base class through inheritance
    public class DogInformation : DogReservation
    {
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public string Weight { get; set; }
        public bool SpayedOrNeutred { get; set; }
        public DogInformation(DateTime dateOfBirth, string age, string breed, string sex, string weight, bool spayedOrNeutred, string ownerName, string dogName, DateTime checkInDate, DateTime checkOutDate, string phoneNumber, string email) : base(ownerName, dogName, checkInDate, checkOutDate, email, phoneNumber)
        {
            DateOfBirth = dateOfBirth;
            Age = age;
            Breed = breed;
            Sex = sex;
            Weight = weight;
            SpayedOrNeutred = spayedOrNeutred;
        }
    }
}
