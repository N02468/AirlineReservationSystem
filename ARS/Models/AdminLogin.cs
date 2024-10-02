using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ARS.Models
{
    [Table("TblAdminLogin")]
    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage ="User Name Required")]
        [Display(Name ="User Name")]
        [MinLength(3, ErrorMessage = "Min 3 char Req"), MaxLength(10, ErrorMessage = "Max 10 char allow")]


        public string AdminName { get; set; }



        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage ="Min 3 char Req"),MaxLength(10,ErrorMessage ="Max 10 char allow")]


        public string Password { get; set; }
    }
    [Table("TblUserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        [MaxLength(40, ErrorMessage ="Max40  char allow"),MinLength(5,ErrorMessage ="Min 5 char req")]

        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        [MaxLength(40, ErrorMessage = "Max 40  char allow"), MinLength(5, ErrorMessage = "Min 5 char req")]

        public string LastName { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Email ID Required")]
        [MaxLength(30, ErrorMessage = "Max 30  char allow"), MinLength(5, ErrorMessage = "Min 5 char req")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }




        [Display(Name = " Password ")]
        [Required(ErrorMessage = "Password Required")]
        [MaxLength(20, ErrorMessage = "Max  20char allow"), MinLength(5, ErrorMessage = "Min 5 char req")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Display(Name = "Confirm Password ")]
        [Required(ErrorMessage = "Password not matched")]
        [MaxLength(20, ErrorMessage = "Max  20char allow"), MinLength(5, ErrorMessage = "Min 5 char req")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }



        [Required(ErrorMessage = "Age Required")]
        [Range(18,120,ErrorMessage ="Min 18 years has book the flight")]

        public string Age { get; set; }



        [Display(Name = "Phoneno ")]
        [Required(ErrorMessage = "Phoneno   req")]
        //[MaxLength(20, ErrorMessage = "Max  20char allow"), MinLength(5, ErrorMessage = "Min 5 char req")]
        [DataType(DataType.Password)]



        public string Phoneno { get; set; }


        [Display(Name = "NIC No ")]
        //[Required(ErrorMessage = "NIC No req"),RegularExpression (@"^([0-9]{13})$",ErrorMessage ="Invalid NIC No")]
        //[MaxLength(40, ErrorMessage = "Max  40char allow"), MinLength(5, ErrorMessage = "Min 5 char required")]
        [StringLength(13)]
        public string NICNo { get; set; }
    }
    public class AdminPlane
    {
     
    }

    public class AeroPlaneInfo
    {
        [Key]
        public int Planeid { get; set; }

        [Display(Name = "Aero Plane Name Required")]
        [Required(ErrorMessage = "Aeroplane name  required")]
        [MaxLength(30, ErrorMessage = "Max  30 char allow"), MinLength(3, ErrorMessage = "Min 3  char req")]


        public string  Aplane { get; set; }
        [Required(ErrorMessage = "Capacity required")]
        [Display (Name="Seating Capacity")]

        public int SeatingCapacity { get; set; }

        [Required(ErrorMessage = "Price required")]
        public float Price { get; set; }

        public virtual ICollection<TicketReserve_tbl>TicketReserve_tbls { get; set; }

    }

    [Table("TblFlightBook")]
    public class Flightbooking
    {
        [Key]
        public int Bid { get; set; }

        [Required,Display(Name ="Customer name")]
       public string bCusName { get; set; }

        [Required,Display(Name ="Customer Address")]

        public String bCusAddress { get; set; }

        [Required,Display(Name ="Customer Email")]
        public string bCusEmail { get; set; }

        [Required, Display(Name = "No of seat")]
        public string bCusSeat { get; set; }

        [Required, Display(Name = "phone number")]
        public string bCusPhoneNum { get; set; }

        [Required, Display(Name = "CNIC")]
        public string bCusCnic { get; set; }

        [Required, Display(Name = "RES ID")]
        public int ResID { get; set; }


        [Display(Name="Departure Date")]
        [DataType(DataType.Date)]
        public DateTime DDate { get; set; }





        [Display(Name="Departure Time")]
        [StringLength(15)]
        public string Dtime { get; set; }


        public virtual TicketReserve_tbl TicketReserve_tbls { get; set; }



    }
    public class TicketReserve_tbl
    {
        [Key]
        
        public string ResID { get; set; }

        [Required, Display(Name = "From City:")]
        public string Resfrom { get; set; }

        [Required, Display(Name = "To City:")]
        public string Resto { get; set; }

        [Required, Display(Name = "Departure Date")]

        public string ResDepDate { get; set; }

        [Required, Display(Name = "Flight time:")]
        public string ResTime { get; set; }

        [Required, Display(Name = "plane No:")]
        public int PlaneId{ get; set; }

        public virtual AeroPlaneInfo Plane_tbls { get; set; }

        [Required, Display(Name = "Seats Avalaible:")]
        public int Planeseat { get; set; }

        [Required, Display(Name = "Price:")]
        public float ResTicketPrice { get; set; }

        [Required, Display(Name = "Plane Type:")]
        public string ResPlaneType { get; set; }

        public virtual ICollection<Flightbooking>tblFlightbookings { get; set; }
    }

}
