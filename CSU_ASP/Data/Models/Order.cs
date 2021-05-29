using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        
        [Display(Name="Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Поле не заполнено")]
        public string name { get; set; }
        
        [Display(Name = "Введите фамилию")]
        [StringLength(25)]
        [Required(ErrorMessage = "Поле не заполнено")]
        public string surname { get; set; }
        
        [Display(Name = "Адрес")]
        [StringLength(45)]
        [Required(ErrorMessage = "Поле не заполнено")]
        public string address { get; set; }
        
        [Display(Name = "Номер телефона")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Поле не заполнено")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required(ErrorMessage = "Поле не заполнено")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
