//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GovoriLegko
{
    using System;
    using System.Collections.Generic;
    
    public partial class Посещаемость
    {
        public int ID_Посещаемости { get; set; }
        public Nullable<int> ID_Клиента { get; set; }
        public Nullable<int> ID_Урока { get; set; }
        public string Статус { get; set; }
    
        public virtual Клиент Клиент { get; set; }
        public virtual Уроки Уроки { get; set; }
    }
}
