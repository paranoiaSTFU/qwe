using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KonovalovArtemUpISP41
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DB.UPkonovalovEntities Context { get; } = new DB.UPkonovalovEntities();
        public static DB.User UserContext = null;
    }
}
