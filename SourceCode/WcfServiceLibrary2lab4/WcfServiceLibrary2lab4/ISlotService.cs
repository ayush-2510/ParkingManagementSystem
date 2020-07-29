using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2lab4
{
    [ServiceContract]
    public interface ISlotService
    {

        [OperationContract]
        List<String> available_section();
        [OperationContract]
        List<int> available_floor(string section);
        [OperationContract]
        List<String> available_type(string section, int floor);
        [OperationContract]
        int addSlots(string section, int floor, string type, int normalCharge, int overtimeCharge, int amount);
        [OperationContract]
        int removeSlots(string section, int floor, string type, int amount);
        [OperationContract]
        int showAllSlots(string section, int floor, string type);
        [OperationContract]
        bookingResult bookSlot(string section, int floor, string type, int userid, string vehicleno, DateTime arrivaltime, DateTime exittime);
        [OperationContract]
        int cancelBooking(int bookingId, int userId);
        [OperationContract]
        exitResult exitVehicle(int bookingId, DateTime exitTime);
        [OperationContract]
        int makePayment(int paymentId, string paymentType);
        [OperationContract]
        List<Booking> showBookings(int userId);
        [OperationContract]
        List<Booking1> showAllBookings();
    }
    [DataContract]
    public class bookingResult
    {
        public bookingResult(int Slot_Id, int booking_Id)
        {
            this.Slot_Id = Slot_Id;
            this.Booking_Id = booking_Id;
        }
        [DataMember]
        int Slot_Id { get; set; }
        [DataMember]
        int Booking_Id { get; set; }
    }
    [DataContract]
    public class exitResult
    {
        public exitResult(int paymentId, int Cost)
        {
            this.paymentId = paymentId;
            this.Cost = Cost;
        }
        [DataMember]
        int paymentId { get; set; }
        [DataMember]
        int Cost { get; set; }
    }
    [DataContract]
    public class Booking
    {
        public Booking(int BookingId, int SlotId, string PlateNumber, DateTime Arrival, DateTime Exit)
        {
            this.BookingId = BookingId;
            this.SlotId = SlotId;
            this.PlateNumber = PlateNumber;
            this.Arrival = Arrival;
            this.Exit = Exit;
        }
        [DataMember]
        int BookingId { get; set; }
        [DataMember]
        int SlotId { get; set; }
        [DataMember]
        string PlateNumber { get; set; }
        [DataMember]
        DateTime Arrival { get; set; }
        [DataMember]
        DateTime Exit { get; set; }
    }

    [DataContract]
    public class Booking1
    {
        public Booking1(int BookingId, int SlotId, string PlateNumber, DateTime Arrival, DateTime Exit,string UserId)
        {
            this.BookingId = BookingId;
            this.SlotId = SlotId;
            this.PlateNumber = PlateNumber;
            this.Arrival = Arrival;
            this.Exit = Exit;
            this.UserId = UserId;
        }
        [DataMember]
        int BookingId { get; set; }
        [DataMember]
        int SlotId { get; set; }
        [DataMember]
        string PlateNumber { get; set; }
        [DataMember]
        string UserId { get; set; }
        [DataMember]
        DateTime Arrival { get; set; }
        [DataMember]
        DateTime Exit { get; set; }
    }

}
