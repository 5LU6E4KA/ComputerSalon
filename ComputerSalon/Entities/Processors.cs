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
    
    public partial class Processors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Processors()
        {
            this.CharacteristicsForPC = new HashSet<CharacteristicsForPC>();
        }
    
        public int ProcessorId { get; set; }
        public string Model { get; set; }
        public string Socket { get; set; }
        public int CountOfCores { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CharacteristicsForPC> CharacteristicsForPC { get; set; }
    }
}