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
    
    public partial class Assembling
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assembling()
        {
            this.Feedbacks = new HashSet<Feedbacks>();
            this.Orders = new HashSet<Orders>();
        }
    
        public int AssemblyId { get; set; }
        public int CharacteristicId { get; set; }
        public int MonitorId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
    
        public virtual CharacteristicsForPC CharacteristicsForPC { get; set; }
        public virtual Monitors Monitors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedbacks> Feedbacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}