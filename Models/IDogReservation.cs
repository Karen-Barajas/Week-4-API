namespace MSSD_725_Week_4_Project.Models
{
    public interface IDogReservation
    {
        string OwnerName { get; set; }
        string DogName { get; set; }
        DateTime CheckInDate { get; set; }
        DateTime CheckOutDate { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }

        int Duration();
        int CalculateTotalCost();
        void Confirmation();
    }
}
