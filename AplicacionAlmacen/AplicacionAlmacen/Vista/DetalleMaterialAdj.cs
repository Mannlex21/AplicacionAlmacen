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
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Net.NetworkInformation;

namespace AplicacionAlmacen.Vista
{
    public partial class DetalleMaterialAdj : DevExpress.XtraEditors.XtraForm
    {
        public DetalleMaterialAdj()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            List<Archivo> a = new List<Archivo>();
            NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
            if (Directory.Exists(CatalogoMateriales.directorio))
            {
                String[] files = Directory.GetFiles(CatalogoMateriales.directorio);
                
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = new FileInfo(files[i]);
                    a.Add(new Archivo
                    {
                        archivo = file.Name
                    });
                }
                
                if (a.Count == 0)
                {
                    Shown += (s, e1) => {
                        Thread t = new Thread(() => Thread.Sleep(1000));
                        t.Start();
                        t.Join();
                        MessageBox.Show("No hay datos adjuntos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    };
                }
                else
                {
                    GridControl.DataSource = a;
                }
                
            }
            else
            {
                Shown += (s, e1) => {
                    Thread t = new Thread(() => Thread.Sleep(1000));
                    t.Start();
                    t.Join();
                    MessageBox.Show("No hay datos adjuntos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            }
            

        }
        class Archivo
        {
            public string archivo { get; set; }
        }
        private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Red();
        }
        private void GridControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int r = Tabla.GetSelectedRows()[0];
                string d = CatalogoMateriales.directorio + "\\" + Tabla.GetRowCellValue(r, "archivo").ToString();
                Process.Start(d);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void Red()
        {
            if (Controlador.Clases.ConexionServidor.verificarConexion())
            {
                GridControl.Enabled = true;
            }
            else
            {
                GridControl.Enabled = false;
            }
        }
        private void DetalleMaterialAdj_Load(object sender, EventArgs e)
        {
            Red();
        }
    }
}