using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Timers;
using static PPPP.Metodos;

namespace PPPP
{
    public partial class InterfazEdicion : Form
    {
        //private int HojaOriginal1;
        private PictureBox miniaturaHoja;
        PictureBox Hoja;
        double Escala = 0.1;
        int I = 0;

        //private int maxAlturaFila = 0; // Declaración de la variable maxAlturaFila
        private List<Rectangle> posicionesOcupadas = new List<Rectangle>();
        int AuxRecortar = 0;
        Metodos Metodo = new Metodos();//llamar Clase
        
        public StreamReader lector;
        // PictureBox Hoja;

        int Contador = 0;

        PictureBox Imagen = new PictureBox();

        PictureBox ImagenL = new PictureBox();


        int NC = 0,inX=0,inY=0;
        double zoomFactor = 1.0;


        private System.Timers.Timer backupTimer;



        public InterfazEdicion()
        {

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            pnResoluciones1.Visible = false;
            TPHoja();
            VerificarRecorte();
            InicializaListBox();
            LeerRegistro();
            Globales.Registro.Visible = false;;
            pnResoluciones.Visible = false;
            btnEliminar.Visible = false;
            if(Globales.AuxAgregarImagen == 0 )
            {
                NCopias.Enabled = false;
                Recortar.Enabled = false;
                Resolucion.Enabled = false;
                AgregarImg.Enabled = false;
            }

            InitializeBackupTimer();

        }
        private void InitializeBackupTimer()         //  BKUPAUTO
        {
            backupTimer = new System.Timers.Timer();
            backupTimer.Interval = 15000; // Intervalo en milisegundos (60000 ms = 1 minuto)
            backupTimer.Elapsed += BackupTimer_Elapsed;
            backupTimer.AutoReset = true; // Para que se repita automáticamente
            backupTimer.Start();
        }

        private void BackupTimer_Elapsed(object sender, ElapsedEventArgs e)       //  BKUPAUTO
        {
            string fileExtension = ".json";
            string directorioGuardado = @"C:\MiCarpetaDeImagenes"; // Cambia esto a la ruta deseada

            if (Directory.Exists(Globales.BackupDirectory))
            {
                var jsonFiles = Directory.GetFiles(Globales.BackupDirectory, "*" + fileExtension);

                if (jsonFiles.Length >= 10)
                {
                    // Ordena los archivos por fecha de creación y elimina el más antiguo
                    var oldestFile = jsonFiles.OrderBy(f => File.GetCreationTime(f)).First();
                    File.Delete(oldestFile);

                }
                CrearRespaldo();
            }
            else {
                if (Directory.Exists(directorioGuardado))
                {
                    Directory.CreateDirectory(Globales.BackupDirectory);

                    var jsonFiles = Directory.GetFiles(Globales.BackupDirectory, "*" + fileExtension);

                    if (jsonFiles.Length >= 10)
                    {
                        // Ordena los archivos por fecha de creación y elimina el más antiguo
                        var oldestFile = jsonFiles.OrderBy(f => File.GetCreationTime(f)).First();
                        File.Delete(oldestFile);

                    }
                    CrearRespaldo();

                }
                else {
                    Directory.CreateDirectory(directorioGuardado);
                    Directory.CreateDirectory(Globales.BackupDirectory);

                    var jsonFiles = Directory.GetFiles(Globales.BackupDirectory, "*" + fileExtension);

                    if (jsonFiles.Length >= 10)
                    {
                        // Ordena los archivos por fecha de creación y elimina el más antiguo
                        var oldestFile = jsonFiles.OrderBy(f => File.GetCreationTime(f)).First();
                        File.Delete(oldestFile);

                    }
                    CrearRespaldo();
                }
            }
        }


        private void CrearRespaldo()   //  BKUPAUTO
        {
            string backupFileName = $"configuracion_{DateTime.Now:yyyyMMdd_HHmmss}.json";
            string filePath = Path.Combine(Globales.BackupDirectory, backupFileName);
            Globales.GuardarConfiguracion(filePath);
        }

        private void InicializaListBox()
        {
            //desactivo Variables Principales
          
            Globales.Registro.Location = new Point(16, 408); // Establecer la ubicación
            Globales.Registro.Size = new Size(225, 238);    // Establecer el tamaño
            panel1.Controls.Add(Globales.Registro);
         
        }

         private void VerificarRecorte()
            {
            try
            {

                Globales.ImagenGlobalCP = System.Drawing.Image.FromFile(Globales.RutaImagenCP);
                ImageContainer.ImagenRecortada = System.Drawing.Image.FromFile(Globales.RutaImagen); // Carga la imagen
            }catch { 
            }
                                                                               //  Globales.ImagenGlobal = System.Drawing.Image.FromFile(Globales.RutaImagen);
                                                                               // Limpiar cualquier control existente en el panel
                                                                               //pnPrevisualizacion.Controls.Clear();
            Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel

            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;

            Imagen.Image = ImageContainer.ImagenRecortada ??Globales.ImagenGlobalCP; // SI NO NADA EN ImageContainer, usa la ImagenGlobal
            pnPrevisualizacion.Controls.Add(Imagen);
            if (Imagen.Image == null)
                {
                    
                }

            }
        
        private void AbrirImagen()
        {
          
                string RI = null, RICP = null;
                NCopias.Value = 0;
                NC = (int)NCopias.Value;
                inX = 0;
                inY = 0;
                RI = Globales.RutaImagen;
                RICP = Globales.RutaImagenCP;


            try
            {
                openFileDialog1.ShowDialog();
                if (string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    // Si no se seleccionó un archivo, salir del método.
                    MessageBox.Show("No se seleccionó ninguna imagen.");
                    return;
                }

                Globales.RutaImagen = openFileDialog1.FileName;
                Globales.RutaImagenCP = openFileDialog1.FileName;
                Globales.ImagenGlobalCP = System.Drawing.Image.FromFile(Globales.RutaImagen);
            }

            catch
            {
                Globales.RutaImagen = RI;
                Globales.RutaImagenCP = RICP;
                //MessageBox.Show("Error al cargar la imagen. Se restauraron las rutas anteriores.");
                return;
            }

            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = System.Drawing.Image.FromFile(Globales.RutaImagen); // Carga la imagen
            pnPrevisualizacion.Controls.Add(Imagen);

            if (Globales.RutaImagen != null)
            {
                NCopias.Enabled = true;
                Resolucion.Enabled = true;
                Recortar.Enabled = true;
                AgregarImg.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ingresa Una Imagen");
            }
            // Configurar el cursor para el PictureBox de recorte
        }




        private void AgrImgHoj(int nC, double zoomFactor,Image Imagen)
         {
             int hojaAncho =Hoja.Width;
             int hojaAlto = Hoja.Height;

             // Inicializar la lista de espacios libres con el espacio completo de la hoja si es la primera vez
             List<Rectangle> espaciosLibres;
             if (posicionesOcupadas.Count == 0)
             {
                 espaciosLibres = new List<Rectangle>
         {
             new Rectangle(0, 0, hojaAncho, hojaAlto)
         };
             }
             else
             {
                 // Si ya hay posiciones ocupadas, calcular los espacios libres restantes
                 espaciosLibres = CalcularEspaciosLibres(hojaAncho, hojaAlto);
             }

             for (int i = 0; i < nC; i++)
             {
                 // Usar la imagen recortada si está disponible, de lo contrario usar la imagen original
                 //Image imagenAUsar = Imagen.Image;    // MODIFICADO 

                 Size tamanoImagen = new Size((int)(Imagen.Width * zoomFactor), (int)(Imagen.Height * zoomFactor));
                 Rectangle mejorEspacio = Rectangle.Empty;
                 int mejorIndice = -1;

                 // Buscar el mejor espacio para la imagen
                 for (int j = 0; j < espaciosLibres.Count; j++)
                 {
                     Rectangle espacio = espaciosLibres[j];
                     if (tamanoImagen.Width <= espacio.Width && tamanoImagen.Height <= espacio.Height)
                     {
                         if (mejorEspacio == Rectangle.Empty || espacio.Width * espacio.Height < mejorEspacio.Width * mejorEspacio.Height)
                         {
                             mejorEspacio = espacio;
                             mejorIndice = j;
                         }
                     }
                 }

                 // Si no se encuentra un espacio adecuado, salir del bucle
                 if (mejorEspacio == Rectangle.Empty)
                 {
                     MessageBox.Show("No hay suficiente espacio en la hoja para colocar todas las imágenes.");
                     break;
                 }

                 // Crear el PictureBox y ubicarlo en el mejor espacio encontrado
                 PictureBox pictureBox1 = new PictureBox
                 {
                     Image = Imagen,
                     Size = tamanoImagen,
                     Location = new Point(mejorEspacio.X, mejorEspacio.Y),
                     SizeMode = PictureBoxSizeMode.StretchImage
                 };
                 Hoja.Controls.Add(pictureBox1);
                  // Actualizar la lista de posiciones ocupadas
                Rectangle espacioUsado = new Rectangle(mejorEspacio.X, mejorEspacio.Y, tamanoImagen.Width, tamanoImagen.Height);
                 posicionesOcupadas.Add(espacioUsado);

                 // Actualizar la lista de espacios libres
                 espaciosLibres.RemoveAt(mejorIndice);
                 // Agregar los nuevos espacios libres generados por el espacio ocupado
                 espaciosLibres.Add(new Rectangle(espacioUsado.Right, espacioUsado.Top, mejorEspacio.Width - espacioUsado.Width, espacioUsado.Height)); // Espacio a la derecha
                 espaciosLibres.Add(new Rectangle(espacioUsado.Left, espacioUsado.Bottom, espacioUsado.Width, mejorEspacio.Height - espacioUsado.Height)); // Espacio debajo

                 // Eliminar espacios libres que tengan ancho o alto cero
                 espaciosLibres = espaciosLibres.Where(e => e.Width > 0 && e.Height > 0).ToList();
             }
            ActualizarMiniatura();
        }

         public  List<Rectangle> CalcularEspaciosLibres(int hojaAncho, int hojaAlto)
         {
             List<Rectangle> espaciosLibres = new List<Rectangle>
     {
         new Rectangle(0, 0, hojaAncho, hojaAlto)
     };

             foreach (var pos in posicionesOcupadas)
             {
                 for (int i = espaciosLibres.Count - 1; i >= 0; i--)
                 {
                     var espacio = espaciosLibres[i];
                     if (pos.IntersectsWith(espacio))
                     {
                         espaciosLibres.RemoveAt(i);
                         var interseccion = Rectangle.Intersect(pos, espacio);
                         if (interseccion.Top > espacio.Top)
                         {
                             espaciosLibres.Add(new Rectangle(espacio.Left, espacio.Top, espacio.Width, interseccion.Top - espacio.Top));
                         }
                         if (interseccion.Bottom < espacio.Bottom)
                         {
                             espaciosLibres.Add(new Rectangle(espacio.Left, interseccion.Bottom, espacio.Width, espacio.Bottom - interseccion.Bottom));
                         }
                         if (interseccion.Left > espacio.Left)
                         {
                             espaciosLibres.Add(new Rectangle(espacio.Left, interseccion.Top, interseccion.Left - espacio.Left, interseccion.Height));
                         }
                         if (interseccion.Right < espacio.Right)
                         {
                             espaciosLibres.Add(new Rectangle(interseccion.Right, interseccion.Top, espacio.Right - interseccion.Right, interseccion.Height));
                         }
                     }
                 }
             }

             return espaciosLibres;
         }

        private void NCopias_ValueChanged(object sender, EventArgs e)
        {
            NC = (int)NCopias.Value;
            LeerRegistro();
            AgrImgHoj(NC, zoomFactor, Imagen.Image);

        }

        public void LeerRegistro()
        {
            LimpiarHoja();

            for (int i = 0; i < Globales.Registro.Items.Count; i++)
                {
                    string cadena = Globales.Registro.Items[i].ToString();
                    string[] partes = cadena.Split(',');
                    String RutaImagen;
                    int inX, inY,nc;
                
                    if (partes.Length >= 4) // Asegúrate de que haya al menos tres partes
                    {
                         RutaImagen= partes[0];
                         inX = int.Parse(partes[1]);
                         inY =  int.Parse(partes[2]);
                         nc= int.Parse(partes[3]);

                         ImagenL.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
                         ImagenL.SizeMode = PictureBoxSizeMode.StretchImage; // Escala la imagen para ajustarse al PictureBox
                    try { 
                         ImagenL.Image = System.Drawing.Image.FromFile(RutaImagen); // Carga la imagen
                         Metodo.AddImageToPictureBox(RutaImagen, ImagenL, inX, inY);
                         AgrImgHoj(nc,zoomFactor,ImagenL.Image);
                    }catch{

                    }
                }
                else
                    {
                        // El formato de la cadena no es válido
                        Console.WriteLine("Formato de cadena no válido: " + cadena);
                    }
            }
        }

       
        public void LimpiarHoja()
        {
            // Remueve todas las imágenes de la hoja
            Hoja.Controls.Clear();
            posicionesOcupadas.Clear();
            // Limpiar la miniatura
            miniaturaHoja.Image = null;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            // Crear un bitmap del tamaño del PictureBox
            Bitmap bmp = new Bitmap(Hoja.Width, Hoja.Height);

            // Dibujar el contenido del PictureBox en el bitmap
            Hoja.DrawToBitmap(bmp, new Rectangle(0, 0, Hoja.Width, Hoja.Height));
            // Crear un cuadro de diálogo para guardar archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de imagen (*.jpg)|*.jpg|Todos los archivos (*.*)|*.*";
            saveFileDialog.Title = "Guardar como";

            // Si el usuario selecciona una ruta y hace clic en "Guardar"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                bmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                MessageBox.Show("La hoja se ha guardado correctamente en formato JPG.");

            }
              // Liberar los recursos del bitmap
            bmp.Dispose();
        }

        private void Recortar_Click(object sender, EventArgs e)
        {
            I = 1;
            if (Imagen.Image != null)
            {
                AuxRecortar = 100; //REC

                Recorte IR = new Recorte();
                //IR.FormClosed += (s, args) => this.Show();
                IR.Show();
                this.Close();

            }
            else {

                MessageBox.Show("favor de seleccionar Una Foto");
            }

        }

        private void Regist_Click(object sender, EventArgs e)
        {
                Globales.Registro.Visible = !(Globales.Registro.Visible);
                btnEliminar.Visible = !(btnEliminar.Visible);   
        }

        private void Resolucion_Click(object sender, EventArgs e)
        {
            if (Imagen.Image!=null)
            {
                Contador = Contador + 1;
                if (Contador == 1)
                {
                    pnResoluciones.Visible = true;
                }
                else {
                    if (Contador == 2)
                    {
                        pnResoluciones.Visible = false;
                        pnResoluciones1.Visible = true;
                    }
                    else {
                        if (Contador == 3)
                        {
                            pnResoluciones1.Visible = false;
                            Contador = 0;
                        }
                    }
                }
                
            
            }
            else {
                MessageBox.Show("Seleciona Una IMG Primero");
            }

            
        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            AbrirImagen();
            Globales.AuxAgregarImagen = 1;
        }

        private void AgregarImg_Click(object sender, EventArgs e)
        {


            //Reglas Basicas Para Agregar Img A Registro
            if (NC > 0)
            {
                if (inX != 0 && inY != 0)
                {

                    if (!string.IsNullOrEmpty(Globales.RutaImagen))
                    {
                       // LRegistro.Items.Add(openFileDialog1.FileName + ',' + inX.ToString() + ',' + inY.ToString() + ',' + NC);
                        Globales.Registro.Items.Add(Globales.RutaImagen + ',' + inX.ToString() + ',' + inY.ToString() + ',' + NC);
                        LeerRegistro();
                    }
                    else
                    {
                        MessageBox.Show("El nombre del archivo no puede ser nulo o vacío");
                    }

                }
                else
                {
                    MessageBox.Show("Ingresa Un Formato");
                }
            }
            else
            {

                MessageBox.Show("Ingresa un Numero de Copias Valido");
            }

            NCopias.Value = 0;
            NC = (int)NCopias.Value;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            I = 0;
            this.Close();
            InterfazPrincipal IP = new InterfazPrincipal();
            IP.Show();
        }

        private void i5x7_Click(object sender, EventArgs e)
        {

            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 5;
            inY = 7;

            // Usar la imagen recortada si está disponible
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);
            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;
            Contador = 0;
        }


        private void i4x6_Click(object sender, EventArgs e)
        {
            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 4;
            inY = 6;

            // Usar la imagen recortada si está disponible
           
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);

            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;
            Contador = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int selectedIndex = Globales.Registro.SelectedIndex;

            // Verificar si hay un elemento seleccionado
            if (selectedIndex != -1)
            {
                // Eliminar el elemento seleccionado
                Globales.Registro.Items.RemoveAt(selectedIndex);
                LeerRegistro();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void InterfazEdicion_FormClosing(object sender, FormClosingEventArgs e)
        {
            panel1.Controls.Remove(Globales.Registro);
            
            if (I == 0)
                {
                var result = MessageBox.Show("¿Desea guardar el estado del programa?", "Estado del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        saveFileDialog.InitialDirectory = documentsPath;
                        saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                        saveFileDialog.DefaultExt = "json";
                        saveFileDialog.AddExtension = true;
                        saveFileDialog.FileName = $"txt.json";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog.FileName;
                            Globales.GuardarConfiguracion(filePath);
                        }

                    }
                }
                  // Detén el temporizador al salir
                
            }
            
            if (backupTimer != null)
            {
                backupTimer.Stop();
                backupTimer.Dispose();
            }
            this.Dispose();

        }


        private void infantilInvt_Click(object sender, EventArgs e)
        {
            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 2;
            inY = 2;
            // Usar la imagen recortada si está disponible
             // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);
            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones1.Visible = false;
            Contador = 0;
        }

        private void i6x4_Click(object sender, EventArgs e)
        {
            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 6;
            inY = 4;

            // Usar la imagen recortada si está disponible
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);
            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones1.Visible = false;
            Contador=0;

        }

        private void i7x5_Click(object sender, EventArgs e)
        {
            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 7;
            inY = 5;

            // Usar la imagen recortada si está disponible
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);
            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones1.Visible = false;
            Contador = 0;
        }

        private void i8x6_Click(object sender, EventArgs e)
        {
            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 8;
            inY = 6;

            // Usar la imagen recortada si está disponible
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);
            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones1.Visible = false;
            Contador = 0;
        }

        private void i6x8_Click(object sender, EventArgs e)
        {
            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 6;
            inY = 8;

            // Usar la imagen recortada si está disponible


            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);
            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;
            Contador = 0;
        }


        private void infantil_Click(object sender, EventArgs e)
        {

            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 2;
            inY = 2;

            // Usar la imagen recortada si está disponible
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);

            // Mostrar la imagen redimensionada en el PictureBox
            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;
            Contador = 0;
        }

        private void Menos_Click(object sender, EventArgs e)
        {
            if (Escala > 0.11)
            {
                
                PanelPre.Controls.Remove(miniaturaHoja);

                Escala -= 0.1;
                Porcentaje.Text = "Porcentaje " + (Escala * 100) + "%";
                miniaturaHoja = new PictureBox
                {
                    Left = 50,
                    Top = 50, // Ajusta según sea necesario
                    Size = Metodos.AjustarProporcionesHojaC(Hoja, Escala),
                    BackColor = Color.White, // Fondo de la miniatura para diferenciar
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                
                PanelPre.Controls.Add(miniaturaHoja);
                miniaturaHoja.Controls.Clear();
                ActualizarMiniatura();
            }

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            if (Escala < 1) {
                
                PanelPre.Controls.Remove(miniaturaHoja);

                Escala += 0.1;
                Porcentaje.Text = "Porcentaje " + (Escala * 100) + "%";
                miniaturaHoja = new PictureBox
                {
                    Left = 50,
                    Top = 50, // Ajusta según sea necesario
                    Size = Metodos.AjustarProporcionesHojaC(Hoja, Escala),
                    BackColor = Color.White, // Fondo de la miniatura para diferenciar
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                
                PanelPre.Controls.Add(miniaturaHoja);
                miniaturaHoja.Controls.Clear();
                ActualizarMiniatura();
            }
        }

        public void TPHoja()
        {
            Size tamañoHoja;
            switch (Globales.tipoH)
            {
                case 1: // Carta
                    tamañoHoja = new Size(2550, 3300); // Tamaño en píxeles (ancho x alto)
                    break;

                case 2: // Oficio
                    tamañoHoja = new Size(2550, 4200); // Tamaño en píxeles (ancho x alto)
                    break;

                case 3: // A4
                    tamañoHoja = new Size(2490, 3510); // Tamaño en píxeles (ancho x alto)
                    break;

                case 4://A3
                    tamañoHoja = new Size(3510, 4950);
                    break;

                case 5://A2
                    tamañoHoja = new Size(4950, 7020);
                    break;

                case 6:
                    tamañoHoja = new Size(3300, 5100);
                    break;

                default:
                    MessageBox.Show("Tipo de número no válido. Por favor, elija 1 para Carta o 2 para Oficio.");
                    return;
            }

            // funciona con scroll
            Hoja = new PictureBox();
            Hoja.Left = 50;
            Hoja.BackColor = Color.White;
            Hoja.Top = 50;
            Hoja.Size = tamañoHoja; // Tamaño del PictureBox igual al tamaño de la hoja
            Hoja.SizeMode = PictureBoxSizeMode.Zoom; // Escalar la imagen para ajustarse al PictureBox

            //PanelPre.Controls.Add(Hoja);


            miniaturaHoja = new PictureBox
            {
                Left = 50,
                Top = 50, // Ajusta según sea necesario
                Size = Metodos.AjustarProporcionesHojaC(Hoja,Escala),
                BackColor = Color.White, // Fondo de la miniatura para diferenciar
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Agregar la miniatura al formulario
            PanelPre.Controls.Add(miniaturaHoja);

        }


        private void ActualizarMiniatura()
        {
            // Crear una imagen en memoria del tamaño de la hoja original
            Bitmap imagenHoja = new Bitmap(Hoja.Width, Hoja.Height);
            Hoja.DrawToBitmap(imagenHoja, new Rectangle(0, 0, Hoja.Width, Hoja.Height));

            // Asignar la imagen reducida al PictureBox de la miniatura
            miniaturaHoja.Image = new Bitmap(imagenHoja, miniaturaHoja.Size);
        }


    }
}


