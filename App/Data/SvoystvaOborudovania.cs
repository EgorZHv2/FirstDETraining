//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SvoystvaOborudovania
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SvoystvaOborudovania()
        {
            this.ZnacheniyaSvoystvOborudovania = new HashSet<ZnacheniyaSvoystvOborudovania>();
            this.ZnacheniyaSvoystvOborudovaniyaVMassive = new HashSet<ZnacheniyaSvoystvOborudovaniyaVMassive>();
            this.TipiOborudovania = new HashSet<TipiOborudovania>();
        }
    
        public System.Guid Id { get; set; }
        public string Nazvanie { get; set; }
        public int TipZnacheniya { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZnacheniyaSvoystvOborudovania> ZnacheniyaSvoystvOborudovania { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZnacheniyaSvoystvOborudovaniyaVMassive> ZnacheniyaSvoystvOborudovaniyaVMassive { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipiOborudovania> TipiOborudovania { get; set; }
    }
}
