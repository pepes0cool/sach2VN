using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebdotNet.Models
{
    public class Products
    {
        [Key]
        public int ID { get; set; } //if we set this as the 'classname'+'entity' this will be treated as primary key\
        [Required]
        [DisplayName("Product Name")]
        [MaxLength(30)]
        public required string ProductName { get; set; }
        public string Description { get; set; }
        [DisplayName("Manufactorer")]
        public string Manufactorer { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name = "Category Name")]

        public string Category { get; set; }
        [Display(Name = "Link of image")]
        [ValidateNever]
        public string imgUrl { get; set; }


    }   
}
