using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace HelperMethods.Models
{
    [MetadataType(typeof(PersonMetaData))]
    //[DisplayName("New Person")]
    public partial class Person
    {
        //[HiddenInput(DisplayValue = false)]
        //[ScaffoldColumn(false)]
        public int PersonId { get; set; }

        //[Display(Name = "First")]
        //[UIHint("MultilineText")]
        public string FirstName { get; set; }

        //[Display(Name = "Last")]
        public string LastName { get; set; }

        //[Display(Name = "Home Address")]
        public Address HomeAddress { get; set; }

        //[Display(Name = "Birth Date")]
        //[DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        //[Display(Name = "Approved")]
        public bool IsApproved { get; set; }

        public Role Role { get; set; }


    }

    public class Address
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string PostalCode { get; set; }
    }

    public enum Role
    {
        Admin,
        User,
        Guest
    }
}