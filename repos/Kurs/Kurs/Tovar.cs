//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurs
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tovar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tovar()
        {
            this.Pokupka = new HashSet<Pokupka>();
        }
    
        public int Tovar_ID { get; set; }
        public string T_name { get; set; }
        public double T_price { get; set; }
        public string T_country { get; set; }
        public string T_type { get; set; }
        public string T_brand { get; set; }
        public Nullable<int> P_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pokupka> Pokupka { get; set; }
        public virtual Postavshik Postavshik { get; set; }
    }
}
