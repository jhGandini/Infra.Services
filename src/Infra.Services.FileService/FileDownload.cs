namespace Infra.Services.FileService;
public class FileDownload
{
    public string FileName { get; private set; }
    public string ContentType { get; private set; }
    public MemoryStream Data { get; private set; }

    public FileDownload(string fileName, string contentType, MemoryStream data)
    {
        FileName = fileName;
        ContentType = contentType;
        Data = data;
    }

}
