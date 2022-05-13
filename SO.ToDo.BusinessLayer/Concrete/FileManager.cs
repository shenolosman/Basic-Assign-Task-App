using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using SO.ToDo.BusinessLayer.Interfaces;
using System.Data;

namespace SO.ToDo.BusinessLayer.Concrete
{
    public class FileManager : IFileService
    {
        public string ExportPdf<T>(IEnumerable<T> list) where T : class, new()
        {
            //pdf download --- iTextSharp asp core
            DataTable dataTable = new DataTable();
            //ObjectReader download FastMember pack!
            dataTable.Load(ObjectReader.Create(list));

            //pdf files must saves first on the server then user can download not like Excel!
            var fileName = DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + "_" + Guid.NewGuid() + ".pdf";
            var returnPath = "/documents/" + fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);

            var stream = new FileStream(path, FileMode.Create);

            //Addin Arial font for PDF Export but if no arial font on computer gonna crash
            var arialTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(arialTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(baseFont, 12, Font.NORMAL);

            var document = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            try
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                PdfPTable pdfPTable = new PdfPTable(dataTable.Columns.Count);
                for (var i = 0; i < dataTable.Columns.Count; i++)
                {
                    pdfPTable.AddCell(new Phrase(dataTable.Columns[i].ColumnName, font));
                }

                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (var j = 0; j < dataTable.Columns.Count; j++)
                    {
                        pdfPTable.AddCell(new Phrase(dataTable.Rows[i][j].ToString(), font));
                    }
                }
                document.Add(pdfPTable);
            }
            catch (DocumentException dex)
            {
                throw (dex);
            }
            catch (IOException ioex)
            {
                throw (ioex);
            }
            finally
            {
                document.Close();
            }
            return returnPath;
        }

        public async Task<byte[]> ExportExcel<T>(IEnumerable<T> list) where T : class, new()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            //excel download --- EPPlus 6
            var excelPackage = new ExcelPackage();
            var excelBlank = excelPackage.Workbook.Worksheets.Add("Report1");

            excelBlank.Cells["A1"].LoadFromCollection(list, true, TableStyles.Light15);
            return await excelPackage.GetAsByteArrayAsync();

            // File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + "" + ".xlsx");
        }
    }
}
