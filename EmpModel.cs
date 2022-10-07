using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDWithDB.Models
{
    public class EmpModel
    {
        private int _empid;
        [Required]
        public int EmployeeID
        {
            get { return _empid; }
            set { _empid = value; }
        }

        private string _lname;

        public string LastName
        {
            //20
            get { return _lname; }
            set { _lname = value; }
        }



        private string _fname;
        [MaxLength(10, ErrorMessage = "Name too long")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be kept blank")]
        public string FirstName
        {

            get { return _fname; }
            set
            {
                if ((value.Length > 10) || (string.IsNullOrEmpty(value)))
                {
                    throw new Exception("First Name too long.. it shud not exceed 10 chars");
                }
                else
                {
                    _fname = value;
                }

            }
        }

        private string _title;

        public string Title
        {
            //30
            get { return _title; }
            set { _title = value; }
        }

        
        private DateTime _birthdate;
        
        //[DataType(DataType.Date, ErrorMessage = "Enter valid date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yyyy}")]
        
        

        public DateTime BirthDate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

    }
}