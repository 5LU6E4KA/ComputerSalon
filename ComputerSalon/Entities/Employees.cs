//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComputerSalon.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public string PersonalCode { get; set; }
        public int UserId { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
