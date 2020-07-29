using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2lab4
{
    public class SlotService : ISlotService
    {
        public static int fourWheelerCost = 20;
        public static int fourWheelerExtraCost = 30;

      
        public List<String> available_section()
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select DISTINCT Section from Slots_Details";
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<String> sections = new List<string>();
                while (rdr.Read())
                {
                    sections.Add(rdr.GetString(0));
                }
                return sections;
            }
        }

        public List<int> available_floor(string section)
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select DISTINCT Floor from Slots_Details where Section = @Section order by Floor";
                cmd.Connection = con;
                SqlParameter parameterSection = new SqlParameter
                {
                    ParameterName = "@Section",
                    Value = section,
                };
                cmd.Parameters.Add(parameterSection);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<int> floor = new List<int>();
                while (rdr.Read())
                {
                    floor.Add(Decimal.ToInt32(rdr.GetDecimal(0)));
                }
                return floor;
            }
        }


        public List<String> available_type(string section, int floor)
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select DISTINCT TypeOfVehicle from Slots_Details where Section=@Section and Floor=@Floor";
                cmd.Connection = con;
                SqlParameter parameterSection = new SqlParameter
                {
                    ParameterName = "@Section",
                    Value = section,
                };
                cmd.Parameters.Add(parameterSection);
                SqlParameter parameterFloor = new SqlParameter
                {
                    ParameterName = "@Floor",
                    Value = floor,
                };
                cmd.Parameters.Add(parameterFloor);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<String> type = new List<string>();
                while (rdr.Read())
                {
                    type.Add(rdr.GetString(0));
                }
                return type;
            }
        }





        public int addSlots(string section, int floor, string type, int normalCharge, int overtimeCharge, int amount)
        {
            int i = 0;

            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Slots_Details (Section , Floor , TypeOfVehicle, NormalCharge, OvertimeCharge) values(@Section,@Floor,@TypeOfVehicle,@NormalCharge, @OvertimeCharge)";
                cmd.Connection = con;
                SqlParameter parameterSection = new SqlParameter
                {
                    ParameterName = "@Section",
                    Value = section,
                };
                cmd.Parameters.Add(parameterSection);
                SqlParameter parameterNormalCharge = new SqlParameter
                {
                    ParameterName = "@NormalCharge",
                    Value = normalCharge,
                };
                cmd.Parameters.Add(parameterNormalCharge);
                SqlParameter parameterOvertimeCharge = new SqlParameter
                {
                    ParameterName = "@OvertimeCharge",
                    Value = overtimeCharge,
                };
                cmd.Parameters.Add(parameterOvertimeCharge);
                SqlParameter parameterFloor = new SqlParameter
                {
                    ParameterName = "@Floor",
                    Value = floor,
                };
                cmd.Parameters.Add(parameterFloor);
                SqlParameter parameterTypeOfVehicle = new SqlParameter
                {
                    ParameterName = "@TypeOfVehicle",
                    Value = type,
                };
                cmd.Parameters.Add(parameterTypeOfVehicle);

                con.Open();
                for (i = 0; i < amount; i++)
                {
                    cmd.ExecuteNonQuery();
                }

            }
            return i;
        }
        public int removeSlots(string section, int floor, string type, int amount)
        {
            int deletedSlots = 0;
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Slot_Id from Slots_Details where Section = @Section and Floor = @Floor and TypeOfVehicle = @TypeOfVehicle";
                cmd.Connection = con;
                SqlParameter parameterSection = new SqlParameter
                {
                    ParameterName = "@Section",
                    Value = section,
                };
                cmd.Parameters.Add(parameterSection);
                SqlParameter parameterFloor = new SqlParameter
                {
                    ParameterName = "@Floor",
                    Value = floor,
                };
                cmd.Parameters.Add(parameterFloor);
                SqlParameter parameterTypeOfVehicle = new SqlParameter
                {
                    ParameterName = "@TypeOfVehicle",
                    Value = type,
                };
                cmd.Parameters.Add(parameterTypeOfVehicle);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    using (SqlConnection con2 = new SqlConnection(cs))
                    {
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = con2;
                        cmd2.CommandText = "select * from Latest_Booking where Slot_Id = @Slot_Id";
                        SqlParameter parameterslotId = new SqlParameter
                        {
                            ParameterName = "@Slot_Id",
                            Value = rdr["Slot_Id"]
                        };
                        cmd2.Parameters.Add(parameterslotId);
                        con2.Open();
                        SqlDataReader rdr1 = cmd2.ExecuteReader();
                        if (rdr1.Read())
                        {
                            continue;
                        }
                    }
                    using (SqlConnection con1 = new SqlConnection(cs))
                    {

                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "delete from Slots_Details where Slot_Id = @Slot_Id";
                        cmd1.Connection = con1;
                        SqlParameter parameterId = new SqlParameter
                        {
                            ParameterName = "@Slot_Id",
                            Value = rdr["Slot_Id"]
                        };
                        cmd1.Parameters.Add(parameterId);
                        try
                        {
                            con1.Open();

                            cmd1.ExecuteNonQuery();
                        }
                        catch (Exception e) {
                            return -2;
                        }
                        deletedSlots++;
                        if (deletedSlots >= amount)
                        {
                            break;
                        }
                    }
                }
            }
            return deletedSlots; ;
        }
        public int showAllSlots(string section, int floor, string type)
        {
            int Slots = 0;
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Slot_Id from Slots_Details where Section = @Section and Floor = @Floor and TypeOfVehicle = @TypeOfVehicle";
                cmd.Connection = con;
                SqlParameter parameterSection = new SqlParameter
                {
                    ParameterName = "@Section",
                    Value = section,
                };
                cmd.Parameters.Add(parameterSection);
                SqlParameter parameterFloor = new SqlParameter
                {
                    ParameterName = "@Floor",
                    Value = floor,
                };
                cmd.Parameters.Add(parameterFloor);
                SqlParameter parameterTypeOfVehicle = new SqlParameter
                {
                    ParameterName = "@TypeOfVehicle",
                    Value = type,
                };
                cmd.Parameters.Add(parameterTypeOfVehicle);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Slots++;
                }
            }
            return Slots;
        }
        public bookingResult bookSlot(string section, int floor, string type, int userid, string vehicleno, DateTime arrivaltime, DateTime exittime)
        {
            if (arrivaltime < DateTime.Now || exittime < DateTime.Now || exittime <= arrivaltime)
            {
                return new bookingResult(-2, -2);
            }
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select Slot_Id from Slots_Details where Section = @Section and Floor = @Floor and TypeOfVehicle = @TypeOfVehicle";
                SqlParameter parameterSection = new SqlParameter
                {
                    ParameterName = "@Section",
                    Value = section,
                };
                cmd.Parameters.Add(parameterSection);
                SqlParameter parameterFloor = new SqlParameter
                {
                    ParameterName = "@Floor",
                    Value = floor,
                };
                cmd.Parameters.Add(parameterFloor);
                SqlParameter parameterTypeOfVehicle = new SqlParameter
                {
                    ParameterName = "@TypeOfVehicle",
                    Value = type,
                };
                cmd.Parameters.Add(parameterTypeOfVehicle);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int test_slot = (int)rdr["Slot_Id"];
                    using (SqlConnection con1 = new SqlConnection(cs))
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = con1;
                        cmd1.CommandText = "select Booking_Id from Latest_Booking where Slot_Id = @slot_Id and (( (ArrivalTime <= @arrivalTime) and (@arrivalTime <= ExitTime) ) or ( (ArrivalTime <= @exitTime) and (@exitTime <= ExitTime) ))";
                        SqlParameter parameterslotId = new SqlParameter
                        {
                            ParameterName = "@slot_Id",
                            Value = test_slot
                        };
                        cmd1.Parameters.Add(parameterslotId);
                        SqlParameter parameterArrivalTime = new SqlParameter
                        {
                            ParameterName = "@arrivalTime",
                            Value = arrivaltime
                        };
                        cmd1.Parameters.Add(parameterArrivalTime);
                        SqlParameter parameterExitTime = new SqlParameter
                        {
                            ParameterName = "@exitTime",
                            Value = exittime
                        };
                        cmd1.Parameters.Add(parameterExitTime);
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();
                        if (rdr1.Read())
                        {
                            continue;
                        }
                        using (SqlConnection con2 = new SqlConnection(cs))
                        {
                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.Connection = con2;
                            cmd2.CommandText = "insert into Booking_Details (Slot_Id, UserId, VehicleNo, ArrivalTime, ExitTime) values (@Slot_Id, @User_Id,  @VehicleNo, @Arrivaltime, @Exittime) select SCOPE_IDENTITY()";
                            SqlParameter parameterSlotId = new SqlParameter
                            {
                                ParameterName = "@Slot_Id",
                                Value = test_slot
                            };
                            cmd2.Parameters.Add(parameterSlotId);
                            SqlParameter parameterUserId = new SqlParameter
                            {
                                ParameterName = "@User_Id",
                                Value = userid
                            };
                            cmd2.Parameters.Add(parameterUserId);
                            SqlParameter parameterVehicleNo = new SqlParameter
                            {
                                ParameterName = "@VehicleNo",
                                Value = vehicleno,
                            };
                            cmd2.Parameters.Add(parameterVehicleNo);
                            SqlParameter parameterArrivaltime = new SqlParameter
                            {
                                ParameterName = "@ArrivalTime",
                                Value = arrivaltime,
                            };
                            cmd2.Parameters.Add(parameterArrivaltime);
                            SqlParameter parameterExittime = new SqlParameter
                            {
                                ParameterName = "@ExitTime",
                                Value = exittime,
                            };
                            cmd2.Parameters.Add(parameterExittime);
                            con2.Open();
                            object obj = cmd2.ExecuteScalar();
                            int bookingId = Int32.Parse(obj.ToString());
                            con2.Close();
                            cmd2.CommandText = "insert into Latest_Booking (Slot_Id, Booking_Id, ArrivalTime, ExitTime) values (@slotid, @BookingId, @arrival_time, @exit_time)";
                            SqlParameter pslotId = new SqlParameter
                            {
                                ParameterName = "@slotid",
                                Value = test_slot
                            };
                            cmd2.Parameters.Add(pslotId);
                            SqlParameter parrivalTime = new SqlParameter
                            {
                                ParameterName = "@arrival_time",
                                Value = arrivaltime
                            };
                            cmd2.Parameters.Add(parrivalTime);
                            SqlParameter pexitTime = new SqlParameter
                            {
                                ParameterName = "@exit_time",
                                Value = exittime
                            };
                            cmd2.Parameters.Add(pexitTime);
                            SqlParameter parameterBookingId = new SqlParameter
                            {
                                ParameterName = "@BookingId",
                                Value = bookingId
                            };
                            cmd2.Parameters.Add(parameterBookingId);
                            con2.Open();
                            cmd2.ExecuteNonQuery();
                            con2.Close();
                            return new bookingResult(test_slot, bookingId);
                        }
                    }
                }
                return new bookingResult(-1, -1);
            }

        }
        public int cancelBooking(int bookingId, int userId)
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Booking_Details where Booking_Id = @bookingId and UserId = @userId";
                cmd.Connection = con;
                SqlParameter parameterbookingId = new SqlParameter
                {
                    ParameterName = "@bookingId",
                    Value = bookingId
                };
                cmd.Parameters.Add(parameterbookingId);
                SqlParameter parameteruserId = new SqlParameter
                {
                    ParameterName = "@userId",
                    Value = userId
                };
                cmd.Parameters.Add(parameteruserId);
                try
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        if ((DateTime)rdr["ArrivalTime"] > DateTime.Now.AddMinutes(30))
                        {
                            using (SqlConnection con1 = new SqlConnection(cs))
                            {
                                SqlCommand cmd1 = new SqlCommand();
                                cmd1.CommandText = "delete from Latest_Booking where Booking_Id = @booking_Id1";
                                cmd1.Connection = con1;
                                SqlParameter parameterbookingId1 = new SqlParameter
                                {
                                    ParameterName = "@booking_Id1",
                                    Value = bookingId
                                };
                                cmd1.Parameters.Add(parameterbookingId1);
                                try
                                {
                                    con1.Open();
                                    cmd1.ExecuteNonQuery();
                                    return 1;
                                }
                                catch (Exception e)
                                {
                                    return -2;
                                }
                            }
                        }
                        return -4;
                    }
                }
                catch (Exception e)
                {
                    return -3;
                }
            }
            return -1;
        }

        public List<Booking> showBookings(int userId)
        {
            List<Booking> booking = new List<Booking>();
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Booking_Details where UserId = @userId";
                cmd.Connection = con;
                SqlParameter parameteruserId = new SqlParameter
                {
                    ParameterName = "@userId",
                    Value = userId,
                };
                cmd.Parameters.Add(parameteruserId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    using (SqlConnection con1 = new SqlConnection(cs))
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select * from Latest_Booking where Booking_Id = @bookingId";
                        cmd1.Connection = con1;
                        SqlParameter parameterbookingId = new SqlParameter
                        {
                            ParameterName = "@bookingId",
                            Value = rdr["Booking_Id"],
                        };
                        cmd1.Parameters.Add(parameterbookingId);
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();
                        if (rdr1.Read())
                        {
                            booking.Add(new Booking(Convert.ToInt32(rdr["Booking_Id"]), Convert.ToInt32(rdr["Slot_Id"]), rdr["VehicleNo"].ToString(), (DateTime)rdr["ArrivalTime"], (DateTime)rdr["ExitTime"]));

                        }
                    }
                }

            }

            return booking;
        }

        public List<Booking1> showAllBookings()
        {
            List<Booking1> booking = new List<Booking1>();
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Booking_Details where Booking_Id not in (select Booking_Id from Latest_Booking)";
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    booking.Add(new Booking1(Convert.ToInt32(rdr["Booking_Id"]), Convert.ToInt32(rdr["Slot_Id"]), rdr["VehicleNo"].ToString(), (DateTime)rdr["ArrivalTime"], (DateTime)rdr["ExitTime"], rdr["UserId"].ToString()));
                }

            }

            return booking;
        }



        public exitResult exitVehicle(int bookingId, DateTime exitTime)
        {

            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete from Latest_Booking where Booking_Id = @booking_Id";
                cmd.Connection = con;
                SqlParameter parameterbookingId = new SqlParameter
                {
                    ParameterName = "@booking_Id",
                    Value = bookingId
                };
                cmd.Parameters.Add(parameterbookingId);
                try
                {
                    con.Open();
                    int temp = cmd.ExecuteNonQuery();
                    if (temp == 0) { return new exitResult(-2, -2); }
                }
                catch (Exception e)
                {
                    return new exitResult(-1, -1);
                }
            }
            int normalCharge = 0;
            int overtimeCharge = 0;
            int slotId = -1;
            int normalHours = 0;
            int overtimeHours = 0;
            int paymentId = -1;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Booking_Details where Booking_Id = @Booking_Id";
                cmd.Connection = con;
                SqlParameter parameterbookingId = new SqlParameter
                {
                    ParameterName = "@Booking_Id",
                    Value = bookingId
                };
                cmd.Parameters.Add(parameterbookingId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    DateTime arrival = (DateTime)rdr["ArrivalTime"];
                    DateTime exit = (DateTime)rdr["ExitTime"];
                    TimeSpan ts = exit - arrival;
                    normalHours = (int)Math.Ceiling(ts.TotalHours);
                    if (exit < exitTime)
                    {
                        ts = exitTime - exit;
                        overtimeHours = (int)Math.Ceiling(ts.TotalHours);
                    }
                    slotId = Int32.Parse(rdr["Slot_Id"].ToString());
                }
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select NormalCharge, OvertimeCharge from Slots_Details where Slot_Id = @Slot_Id";
                cmd.Connection = con;
                SqlParameter parameterslotId = new SqlParameter
                {
                    ParameterName = "@Slot_Id",
                    Value = slotId
                };
                cmd.Parameters.Add(parameterslotId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    normalCharge = Int32.Parse(rdr["NormalCharge"].ToString());
                    overtimeCharge = Int32.Parse(rdr["OvertimeCharge"].ToString());
                }
            }
            int cost = (normalCharge * normalHours) + (overtimeCharge * overtimeHours);
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Payment_Details (Booking_Id, ExitTime, Cost) values (@Booking_Id, @ExitTime, @Cost)  select SCOPE_IDENTITY()";
                cmd.Connection = con;
                SqlParameter parameterBookingId = new SqlParameter
                {
                    ParameterName = "@Booking_Id",
                    Value = bookingId
                };
                cmd.Parameters.Add(parameterBookingId);
                SqlParameter parameterExitTime = new SqlParameter
                {
                    ParameterName = "@ExitTime",
                    Value = exitTime
                };
                cmd.Parameters.Add(parameterExitTime);
                SqlParameter parameterCost = new SqlParameter
                {
                    ParameterName = "@Cost",
                    Value = cost
                };
                cmd.Parameters.Add(parameterCost);
                con.Open();
                object obj = cmd.ExecuteScalar();
                paymentId = Int32.Parse(obj.ToString());
            }
            return new exitResult(paymentId, cost);
        }
        public int makePayment(int paymentId, string paymentType)
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update Payment_Details set Payment_Type = @Payment_Type where Payment_Id = @Payment_Id";
                cmd.Connection = con;
                SqlParameter parameterpayment_Type = new SqlParameter
                {
                    ParameterName = "@Payment_Type",
                    Value = paymentType
                };
                cmd.Parameters.Add(parameterpayment_Type);
                SqlParameter parameterpayment_Id = new SqlParameter
                {
                    ParameterName = "@Payment_Id",
                    Value = paymentId
                };
                cmd.Parameters.Add(parameterpayment_Id);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
            return 1;
        }
    }
}
