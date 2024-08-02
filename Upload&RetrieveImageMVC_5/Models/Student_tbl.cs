//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Upload_RetrieveImageMVC_5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class Student_tbl
    {
        public int Id { get; set; }

        [DisplayName("Student Name")]
        [Required(ErrorMessage ="Student Name is Required")]
        public string Name { get; set; }

        [DisplayName("Student Class")]
        [Required(ErrorMessage ="Student Name is Required")]
        public int Standard { get; set; }

        [DisplayName("Choose Image")]
        [Required(ErrorMessage = "Choose Image is Required")]
        public string Image_Path { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }    
    }
}
