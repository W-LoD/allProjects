//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pokupka
    {
        public int Pokupka_ID { get; set; }
        public int ID_M { get; set; }
        public int ID_S { get; set; }
        public int ID_P { get; set; }
        public int ID_T { get; set; }
        public int Kolvo { get; set; }
        public int ID_Pok { get; set; }
    
        public virtual Magazin Magazin { get; set; }
        public virtual Pokupatel Pokupatel { get; set; }
        public virtual Sotrudnik Sotrudnik { get; set; }
        public virtual Tovar Tovar { get; set; }
    }
}
