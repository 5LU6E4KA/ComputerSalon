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
    
    public partial class Videocards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Videocards()
        {
            this.CharacteristicsForPC = new HashSet<CharacteristicsForPC>();
        }
    
        public int VideocardId { get; set; }
        public int VideoMemoryCapacity { get; set; }
        public string MemoryType { get; set; }
        public string GraphicsProcessor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CharacteristicsForPC> CharacteristicsForPC { get; set; }
    }
}
