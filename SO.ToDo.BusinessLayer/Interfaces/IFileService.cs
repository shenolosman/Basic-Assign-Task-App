namespace SO.ToDo.BusinessLayer.Interfaces
{
    public interface IFileService
    {

        // Returns back to files virtual path on pdf and byte array on excel
        string ExportPdf<T>(IEnumerable<T> list) where T : class, new();
        Task<byte[]> ExportExcel<T>(IEnumerable<T> list) where T : class, new();
    }
}
