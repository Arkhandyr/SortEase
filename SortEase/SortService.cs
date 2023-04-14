namespace SortEase
{
    public class SortService
    {
        public void SortFiles()
        {
            //validar os arquivos pelo tempo
            //validar os arquivos por tipo
            //mover os arquivos configurados para diretório X
            //deletar os arquivos configurados
            List<string> compressedExtensions = new() { ".zip", ".rar", ".7z" };

            var dir = new DirectoryInfo("C:\\Users\\Arkhandyr\\Downloads");
            FileInfo[] files = dir.GetFiles();

            foreach (var file in files)
            {
                if (compressedExtensions.Contains(file.Extension)) //&& file.LastWriteTime > DateTime.Now.AddDays(-7))
                    file.Delete();
            }
        }
    }
}