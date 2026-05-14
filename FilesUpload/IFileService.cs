namespace JobMSWebApi.FilesUpload;

public interface IFileService
{
    Task<string> Upload(IFormFile file, string folderName);
    void DeleteFile(string fileNameWithExtension, string folderName);
}

public class FileService : IFileService
{
    private readonly IWebHostEnvironment env;

    public FileService(IWebHostEnvironment env)
    {
        this.env = env;
    }

    // =========================
    // DELETE FILE
    // =========================
    public void DeleteFile(string fileNameWithExtension, string folderName)
    {
        if (string.IsNullOrEmpty(fileNameWithExtension))
            throw new ArgumentNullException(nameof(fileNameWithExtension));

        var webRoot = env.WebRootPath
            ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        var path = Path.Combine(webRoot, folderName, fileNameWithExtension);

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    // =========================
    // UPLOAD FILE (FIXED)
    // =========================
    public async Task<string> Upload(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0)
            return null;

        var webRoot = env.WebRootPath
            ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        var uploadPath = Path.Combine(webRoot, folderName);

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"{folderName}/{fileName}";
    }
}