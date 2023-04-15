using MimeMapping;

namespace SortEase
{
    public class SortService
    {
        public void SortFiles()
        {
            //validar os arquivos pelo tempo
            //validar os arquivos por tipo
            //mover os arquivos configurados para diretório X
            List<string> compressedExtensions = new() { ".zip", ".rar", ".7z" };

            var path = "C:\\Users\\Arkhandyr\\Downloads";

            var dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            var folders = Directory.GetDirectories(path);

            foreach (var file in files)
            {
                string mimeType = MimeUtility.GetMimeMapping(file.FullName).Split("/")[0];

                if (compressedExtensions.Contains(file.Extension) && file.LastWriteTime > DateTime.Now.AddDays(-7))
                {
                    file.Delete();
                    continue;
                }
                    
                var newDir = Path.Combine(dir.FullName, mimeType);

                if (!Directory.Exists(newDir))
                    Directory.CreateDirectory(newDir);

                File.Move(file.FullName, Path.Combine(newDir, file.Name));
            }

            foreach (var folder in folders) 
            {
                var newDir = Path.Combine(dir.FullName, "folders");

                if (!Directory.Exists("folders"))
                    Directory.CreateDirectory("folders");

                Directory.Move(folder, newDir);
            }
        }
    }
}