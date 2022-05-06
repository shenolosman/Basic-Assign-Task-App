namespace SO.ToDo.BusinessLayer.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Returns back to files virtual path on pdf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string ExportPdf<T>(IEnumerable<T> list) where T : class, new();
        /// <summary>
        /// Returns back to files byte array on excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<byte[]> ExportExcel<T>(IEnumerable<T> list) where T : class, new();
    }
}
