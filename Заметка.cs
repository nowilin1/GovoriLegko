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
    
    public partial class Заметка
    {
        public int ID_Заметка { get; set; }
        public Nullable<int> ID_Сотрудник { get; set; }
        public Nullable<int> ID_Клиент { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Заметка1 { get; set; }
    
        public virtual Клиент Клиент { get; set; }
        public virtual Сотрудник Сотрудник { get; set; }
    }
}
