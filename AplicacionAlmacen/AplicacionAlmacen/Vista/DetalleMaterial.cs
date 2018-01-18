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
using DevExpress.LookAndFeel;

namespace AplicacionAlmacen.Vista
{
    public partial class DetalleMaterial : DevExpress.XtraEditors.XtraForm
    {
        static Controlador.MaterialesControlador s = new Controlador.MaterialesControlador();
        public DetalleMaterial()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            CatalogoMateriales m = new CatalogoMateriales();
            boxImg.Image= s.imagen(CatalogoMateriales.imgNombre);
            boxImg.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}