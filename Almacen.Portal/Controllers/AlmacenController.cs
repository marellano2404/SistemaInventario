using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static iTextSharp.text.Font;

namespace Almacen.Portal.Controllers
{
    public class AlmacenController : Controller
    {
        private IHostingEnvironment hostingEnv;
        public AlmacenController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _AgregarSalidaInventario()
        {
            return PartialView();
        }

        public FileResult GenerarSalidaAlmacen([FromForm] IFormCollection SalidaAlmacen)
        {

            var Clave = SalidaAlmacen["Clave"].ToString();
            var Descripcion = SalidaAlmacen["Descripcion"].ToString();
            var TipoCatalogo = SalidaAlmacen["TipoCatalogo"].ToString();
            var ExistenciaUnidad = SalidaAlmacen["ExistenciaUnidad"].ToString();

            var PDF = new iTextSharp.text.Document(PageSize.LETTER, 50, 50, 50, 50);

            PDF.AddTitle("Salidas de Almacén");
            PDF.AddCreator("Hospital Gomez Maza");

            var ruta = Path.Combine(hostingEnv.WebRootPath, "Files\\SalidaAlmacen");
            var rutaImagen = Path.Combine(hostingEnv.WebRootPath, "Content\\Imgs");

            PdfWriter.GetInstance(PDF, new FileStream(ruta + $"/Prueba" + ".pdf", FileMode.Create));
            PDF.Open();

            /*Fuentes*/
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontNegrita14 = new iTextSharp.text.Font(FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontPrivacidad = new iTextSharp.text.Font(FontFamily.TIMES_ROMAN, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            //ENCABEZADO DEL DOCUMENTO
            string Ficha = "Holamundo: ";
            Paragraph FichaExamenP = new Paragraph(Ficha, _standardFont);
            FichaExamenP.Alignment = Element.ALIGN_RIGHT;
            PDF.Add(FichaExamenP);

            string Terminacion = "Gracias por concluir tu proceso de inscripción. Tus datos han sido registrados de forma correcta. En breve iniciaremos el curso de inducción para tí. " +
                                  "Sera Importante que este muy pendiente de los avisos que realizaremos en la página web del Colegio de Bachilleres de Chiapas. https://www.cobach.edu.mx";

            Paragraph TextoPie = new Paragraph(Terminacion, _standardFont);
            TextoPie.Alignment = Element.ALIGN_JUSTIFIED;

            PDF.Add(TextoPie);

            PDF.Add(Chunk.NEWLINE);

            string privacidad = "El Colegio de Bachilleres de Chiapas protegerá y tratará los datos personales contenidos en documentación oficial dentro de los términos establecidos en la " +
                "Ley de Proteccion de Datos Personales en Poseción de Sujetos Obligados del Estado de Chiapas (LPDPPSOCHIS) y demas normativas aplicables. Para mayor información puede consultar nuestro" +
                "aviso de privacidad, mecanismos, medios y procedimientos disponibles para ejecutar sus derechos ARCO a través de https://www.cobach.edu.mx/avisos-de-privacidad.html";

            Paragraph TextoPrivacidad = new Paragraph(privacidad, _standardFontPrivacidad);
            TextoPie.Alignment = Element.ALIGN_JUSTIFIED;

            PDF.Add(TextoPrivacidad);

            PDF.Close();

            try
            {
                var DocumentoByte = StreamFile(ruta + $"/Prueba"+".pdf");
                var file = ruta + $"\\Prueba"+".pdf";


                if (System.IO.File.Exists(file))
                {
                    System.IO.File.Delete(file);
                }
                return File(DocumentoByte, System.Net.Mime.MediaTypeNames.Application.Octet, "Prueba" + ".pdf");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw new Exception("Error al descargar", ex);
            }
        }

        private byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return ImageData; //return the byte data
        }
    }
}
