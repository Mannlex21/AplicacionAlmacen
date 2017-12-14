using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AplicacionAlmacen.Vista
{
    public partial class CatalogoMateriales : DevExpress.XtraEditors.XtraForm
    {
        static Controlador.CatalogoMateriales s = new Controlador.CatalogoMateriales();
        public CatalogoMateriales()
        {
            InitializeComponent();
            GridControlMateriales.DataSource = s.GetAllMateriales();
        }
    }
}