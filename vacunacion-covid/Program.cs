using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

class Program
{
    static void Main()
    {
        // Generación de los ciudadanos ficticios
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }
        
        // Generación de ciudadanos vacunados con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>(ciudadanos.OrderBy(x => Guid.NewGuid()).Take(75));
        
        // Generación de ciudadanos vacunados con Astrazeneca
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>(ciudadanos.Except(vacunadosPfizer).OrderBy(x => Guid.NewGuid()).Take(75));
        
        // Ciudadanos con ambas vacunas (intersección de conjuntos)
        HashSet<string> vacunadosAmbas = new HashSet<string>(vacunadosPfizer.Intersect(vacunadosAstrazeneca));
        
        // Ciudadanos que no han sido vacunados
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos.Except(vacunadosPfizer).Except(vacunadosAstrazeneca));
        
        // Ciudadanos que recibieron solo Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer.Except(vacunadosAmbas));
        
        // Ciudadanos que recibieron solo Astrazeneca
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca.Except(vacunadosAmbas));
        
        // Generar reporte en PDF
        GenerarReportePDF(noVacunados, vacunadosAmbas, soloPfizer, soloAstrazeneca);
        
        Console.WriteLine("Reporte generado con éxito: ReporteVacunacionCOVID.pdf");
    }
    
    static void GenerarReportePDF(HashSet<string> noVacunados, HashSet<string> vacunadosAmbas, HashSet<string> soloPfizer, HashSet<string> soloAstrazeneca)
    {
        Document doc = new Document();
        PdfWriter.GetInstance(doc, new FileStream("ReporteVacunacionCOVID.pdf", FileMode.Create));
        doc.Open();
        
        doc.Add(new Paragraph("Reporte de Vacunación COVID-19\n\n"));
        
        AgregarSeccion(doc, "Ciudadanos No Vacunados", noVacunados);
        AgregarSeccion(doc, "Ciudadanos con Ambas Vacunas", vacunadosAmbas);
        AgregarSeccion(doc, "Ciudadanos con Solo Vacuna Pfizer", soloPfizer);
        AgregarSeccion(doc, "Ciudadanos con Solo Vacuna Astrazeneca", soloAstrazeneca);
        
        doc.Close();
    }
    
    static void AgregarSeccion(Document doc, string titulo, HashSet<string> lista)
    {
        doc.Add(new Paragraph($"{titulo}: {lista.Count}\n"));
        foreach (var item in lista)
        {
            doc.Add(new Paragraph(item));
        }
        doc.Add(new Paragraph("\n"));
    }
}
